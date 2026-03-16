using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using WebQywy;

public partial class search_word : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string name = Data_Public.getQueryStringToStr("w");
            if (string.IsNullOrEmpty(name)) Response.Redirect("/search/default.aspx");

            if (!Data_System.IsOnlyContainsChinese(name))
            {
                //非全部中文，不能搜索！！调至词搜索页！
                Data_Public.AlertToLocation(this, "有非中文字符", "/search/default.aspx");
            }
            else
            {
                int num = search.Search_word_OfWord(Data_System.IsChinese(name));
                if (num > 0)
                    Response.Redirect("/word.aspx?c=" + num);
                else
                {
                    lit_Name.Text = lbl_Name.Text = name;
                    BinderWordType();
                    BinderDdpWordList();
                }
            }            
        }
    }

    private void BinderDdpWordList()
    {
        DataTable dt = words.Show_User_WordList(uc.UserID);        
        this.ddpwordlist.DataSource = dt;
        this.ddpwordlist.DataTextField = "name";
        this.ddpwordlist.DataValueField = "wl_id";
        this.ddpwordlist.DataBind();
        if (dt.Rows.Count <= 0)
            this.Panel1.Visible = false;
    }

    private void BinderWordType()
    {
        DataTable dt = words.WordTypeList();
        string nameList = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            nameList += "<a href=\"javascript:void(0);\" onclick=\"SelType(" + dt.Rows[i]["t_id"].ToString() + ",'"+ dt.Rows[i]["name"].ToString()+"');\" style='height:35px; margin-right:12px;  color:#000;'>" + dt.Rows[i]["name"].ToString() + "</a>";
        }
        lit_wordTypeList.Text = nameList;        
    }

    protected void btn_Addwl_Click(object sender, EventArgs e)
    {
        string name = lbl_Name.Text;
        int wlid = int.Parse(this.ddpwordlist.SelectedValue);
        words.WordList_Add(name, wlid, uc.UserID);
        Response.Redirect("/wordlist.aspx?w=" + wlid);
    }

    protected void ImgBtn_AddColl_Click(object sender, ImageClickEventArgs e)
    {
        string name = lbl_Name.Text;
        string errorMsg = "";
        bool solu = words.Word_Collection(name, uc.UserID, out errorMsg);
        Response.Redirect("/user/collection.aspx");
    }
}

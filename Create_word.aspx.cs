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
public partial class Create_word : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (uc.UserID <= 0)
            {
                Data_Public.AlertToLocation(this, "登录后才能继续操作！", Data_Public.GetConfig("LoginUrl"), true);
            }
            int w = Data_Public.getQueryStringToInt("w");
            Binder_WordList(w);
        }
    }

    private void Binder_WordList(int w)
    {
        DataTable dt = words.Show_Info_WordList_One(w);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["adduserid"].ToString() == uc.UserID.ToString())
            {
                this.txt_name.Value = dt.Rows[0]["name"].ToString();
                this.txt_content.Value = dt.Rows[0]["content"].ToString();

                Imgbtn_Submit.ImageUrl = "/images/word/word_40.gif";
                img_show.Src = "/images/word/word_33.png";
                lit_titleName.Text = "编辑";
                Panel1.Visible = true;
            }
            else
            {
                Server.Transfer("/error.aspx");
            }
        }
    }

    protected void Imgbtn_Submit_Click(object sender, ImageClickEventArgs e)
    {
        string name = txt_name.Value.Trim();
        string content = txt_content.Value;
        if (!string.IsNullOrEmpty(name + content) && words.KillDog(name + content))
        {
            Response.Redirect("/error.aspx");
            Response.End();
        }
        int w = Data_Public.getQueryStringToInt("w");
        if (w > 0)
        {
            int num = words.WordList_Edit(name, content, uc.UserID, w);
            if (num > 0)
                Response.Redirect("/wordlist.aspx?w=" + w.ToString());
            else
                Data_Public.Alert(this, "修改失败！请重新再试！");
        }
        else
        {            
            int num = words.WordList_Create(name, content, uc.UserID);
            if (num > 0)
                Response.Redirect("/wordlist.aspx?w=" + num.ToString());
            else
                Data_Public.Alert(this, "创建失败！请重新再试！");
        }
    }
}

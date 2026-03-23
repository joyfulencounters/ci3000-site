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
public partial class user_Default : BasePage
{
    public int uid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        uid = Data_Public.getQueryStringToInt("u");
        if (uid <= 0) uid = uc.UserID;
        if (!IsPostBack)
        {
            Show_UserInfo_newword(uid);
            Show_User_WordList_Page(1, uid);
            Show_Word_Collection_Page(1, uid);
            Show_WWl_Remark_New_Page(1, uid);
        }
    }

    #region 获取用户基本信息
    private void Show_UserInfo_newword(int uid)
    {
        DataTable dt = Users.Show_UserInfo_newword(uid);
        if (dt.Rows.Count > 0)
        {
            this.img_user.NavigateUrl = "/user/default.aspx?u=" + dt.Rows[0]["userid"].ToString();
            this.img_user.ImageUrl = dt.Rows[0]["avater"].ToString();
            this.lit_name.Text = "<a href=\"/user/default.aspx?u=" + dt.Rows[0]["userid"].ToString() + "\">" + dt.Rows[0]["realname"].ToString() + "</a>";            
            this.lit_titleName.Text = dt.Rows[0]["realname"].ToString();                        
            this.lit_cr.Text = dt.Rows[0]["wordlist"].ToString();
            this.lit_co.Text = dt.Rows[0]["coll"].ToString();
            this.lit_r.Text = dt.Rows[0]["wlamount"].ToString();
            this.lit_x.Text = dt.Rows[0]["addword"].ToString();
            if (!string.IsNullOrEmpty(dt.Rows[0]["feeling"].ToString()))
                this.lit_feeling.Text = dt.Rows[0]["feeling"].ToString();
            else
            {
                if (uc.UserID == uid && uid > 0)
                    this.lit_feeling.Text = "懒家伙，什么感言都没有留下...点击书写此刻心情！";
            }
            if (uc.UserID == uid && uid > 0)
            {
                if (int.Parse(dt.Rows[0]["wordlist"].ToString()) == 0 && int.Parse(dt.Rows[0]["coll"].ToString()) == 0 && int.Parse(dt.Rows[0]["addword"].ToString()) == 0)
                {
                    Response.Redirect("/master.aspx");
                }
                MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                MultiView1.ActiveViewIndex = 1;
                if (uc.UserID <= 0)
                {
                    this.lit_Index.Text = "<a href=\"/member/signin.aspx?returnpage=" + Server.UrlEncode(Request.Url.ToString()) + "\"><span class=\"Name\">登录</span></a>后即可看到您与<span class=\"Name\">" + dt.Rows[0]["realname"].ToString() + "</span>的契合指数";
                }
                else
                {
                    decimal dec = Users.Show_SameIndexUU(uc.UserID, uid);
                    this.lit_Index.Text = "您与<span class=\"Name\">" + dt.Rows[0]["realname"].ToString() + "</span>的契合指数为<span class=\"Red\">" + dec.ToString() + "</span>";
                }
            }
        }
        else
        {
            Response.Redirect(Data_Public.GetConfig("LoginUrl"));
        }
    }
    #endregion

    #region 用户已有词单列表
    private void Show_User_WordList_Page(int pageIndex, int uid)
    {
        int pageSize = 10;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = words.Show_User_WordList_Page(pageIndex, pageSize, uid, out rowCount, out pageCount);
        this.rep_worlist.DataSource = dt;
        this.rep_worlist.DataBind();

        if (dt.Rows.Count <= 0) lit_nullMsg.Visible = true;
        if(dt.Rows.Count >= 10)  {
            hypelnk_wlmore.Visible = true;
            hypelnk_wlmore.NavigateUrl = "/user/wordlist.aspx?u=" + uid;
        }
    }
    #endregion

    #region 用户收藏列表
    private void Show_Word_Collection_Page(int pageIndex, int uid)
    {
        int pageSize = 20;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = words.Show_Word_Collection_Page(pageIndex, pageSize, uid, out rowCount, out pageCount);
        this.rep_coll.DataSource = dt;
        this.rep_coll.DataBind();
        if (dt.Rows.Count >= 20)
        {
            hypeLnk_more.Visible = true;
            hypeLnk_more.NavigateUrl = "/user/collection.aspx?u=" + uid;
        }
    }
    #endregion

    #region 用户最新评论
    private void Show_WWl_Remark_New_Page(int pageIndex, int uid)
    {
        int pageSize = 10;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = words.Show_WWl_Remark_New_Page(pageIndex, pageSize, uid, out rowCount, out pageCount);
        this.rep_NewRk.DataSource = dt;
        this.rep_NewRk.DataBind();
    }
    #endregion

    #region 此词单评论处理    
    protected void rep_NewRk_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dv = (DataRowView)e.Item.DataItem;
        Literal lit_content = (Literal)e.Item.FindControl("lit_content");        
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string cont = dv["content"].ToString();
            if (dv["r_type"].ToString() == "-1") //词单评论
                cont = "<a href=\"/wordlist.aspx?w=" + dv["cid"].ToString() + "#remark \">" + Data_Public.ClearHtml(cont) + "</a>";
            else if (dv["r_type"].ToString() == "1")//造句词            
                cont = "<a href=\"/word.aspx?c=" + dv["cid"].ToString() + "\">" + cont.Replace("@" + dv["name"].ToString() + "@","<font color=\"red\">" + dv["name"].ToString() + "</font>") + "</a>";
            else
                cont = "<a href=\"/word.aspx?c=" + dv["cid"].ToString() + "\">" + Data_Public.ClearHtml(cont) + "</a>";

            lit_content.Text = cont;
        }
    }
    #endregion
    protected void rep_worlist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "wlDel"){
            int wlid = int.Parse(e.CommandArgument.ToString());
            words.WordList_Delete(wlid);
        }
        Server.Transfer("default.aspx?u=" + uid.ToString());
    }
    protected void rep_coll_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "cwDel")
        {
            int wid = int.Parse(e.CommandArgument.ToString());
            words.Word_Collection(wid, uc.UserID);
        }
        Server.Transfer("default.aspx?u=" + uid.ToString());
    }
    
}

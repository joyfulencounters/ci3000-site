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
public partial class user_wordlist : BasePage
{
    public int uid = 0;
    DataTable dt = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        uid = Data_Public.getQueryStringToInt("u");
        if (uid <= 0) uid = uc.UserID;
        if (!IsPostBack)
        {
            Show_UserInfo_newword(uid);
            Show_User_WordList_Page(1, uid);
            Show_User_WordListR_Page(1, uid);
            Show_User_Remark_WL(uid);
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
        int pageSize = 20;
        int rowCount = 0;
        int pageCount = 0;
        dt = words.Show_User_WordList_Page(pageIndex, pageSize, uid, " addtime desc", out rowCount, out pageCount);
        this.rep_worlist.DataSource = dt;
        this.rep_worlist.DataBind();

        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        int uid = Data_Public.getQueryStringToInt("u");
        if (uid <= 0)
            uid = uc.UserID;
        Show_User_WordList_Page(e.NewPageIndex, uid);
    }

    private void Show_User_WordListR_Page(int pageIndex, int uid)
    {
        int pageSize = 20;
        int rowCount = 0;
        int pageCount = 0;
        dt = words.Show_User_WordList_Page(pageIndex, pageSize, uid, " lastrmktime desc", out rowCount, out pageCount);
        this.rep_wordlistR.DataSource = dt;
        this.rep_wordlistR.DataBind();

        this.AspNetPager2.PageSize = pageSize;
        this.AspNetPager2.RecordCount = rowCount;
    }

    protected void AspNetPager2_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        int uid = Data_Public.getQueryStringToInt("u");
        if (uid <= 0)
            uid = uc.UserID;
        Show_User_WordListR_Page(e.NewPageIndex, uid);
    }
    #endregion

    #region 最新词单评论
    private void Show_User_Remark_WL(int uid)
    {
        int num = 10;
        DataTable dtD = words.Show_User_RemarkWL(num, uid);
        this.rep_remark_wl.DataSource = dtD;
        this.rep_remark_wl.DataBind();
    }
    #endregion

    protected void rep_worlist_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int wlid = int.Parse(e.CommandArgument.ToString());
        if (e.CommandName == "wlDel")
            words.WordList_Delete(wlid);
        else if (e.CommandName == "wlDel2")
            words.WordList_Delete(wlid);

        Server.Transfer("wordlist.aspx?u=" + uid.ToString());
    }
}

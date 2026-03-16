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
public partial class user_comment : BasePage
{
    public int uid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        uid = Data_Public.getQueryStringToInt("u");
        if (uid <= 0) uid = uc.UserID;
        if (!IsPostBack)
        {
            Show_UserInfo_newword(uid);
            Show_WWl_Remark_Uid_Page(1, uid);
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
            this.lit_nm.Text = dt.Rows[0]["realname"].ToString();
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

    #region 用户词和词单评论列表
    private void Show_WWl_Remark_Uid_Page(int pageIndex, int uid)
    {
        int pageSize = 20;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = words.Show_WWl_Remark_Uid_Page(pageIndex, pageSize, uid, out rowCount, out pageCount);
        this.rep_wwl_remark.DataSource = dt;
        this.rep_wwl_remark.DataBind();

        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        int uid = Data_Public.getQueryStringToInt("u");
        if (uid <= 0)
            uid = uc.UserID;

        Show_WWl_Remark_Uid_Page(e.NewPageIndex, uid);
    }

    protected void rep_wwl_remark_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dv = (DataRowView)e.Item.DataItem;
        Literal lit_del = (Literal)e.Item.FindControl("lit_del");
        Literal lit_content = (Literal)e.Item.FindControl("lit_content");
        Literal lit_remark = (Literal)e.Item.FindControl("lit_remark");
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string cont = dv["content"].ToString();
            if (dv["r_type"].ToString() == "-1") //评论词单
                lit_remark.Text = "评论[" + dv["tname"] + "] <a href=\"/wordlist.aspx?w="+dv["cid"].ToString()+"\"><span class=\"Word\">" + dv["name"].ToString() + "</span></a>";
            else if (dv["r_type"].ToString() == "1")//造句词
            {
                lit_remark.Text = "对[" + dv["tname"] + "] <a href=\"/word.aspx?c=" + dv["cid"].ToString() + "\"><span class=\"Word\">" + dv["name"].ToString() + "</span></a> 造句";
                cont = dv["content"].ToString().Replace("@" + dv["name"].ToString() + "@", "<font color=\"red\">" + dv["name"].ToString() + "</font>");
            }
            else
                lit_remark.Text = "评论[" + dv["tname"] + "] <a href=\"/word.aspx?c=" + dv["cid"].ToString() + "\"><span class=\"Word\">" + dv["name"].ToString() + "</span></a> ";

            lit_content.Text = cont;
            if (dv["userid"].ToString() == uc.UserID.ToString())
            {
                lit_del.Text = "<!--<a href=\"javascript:Remark_Del(" + dv["id"].ToString() + "," + dv["rcid"].ToString() + ",'" + dv["tname"].ToString() + "');\"><img src=\"images/word/word_32.gif\" width=\"36\" height=\"12\" border=\"0\" /></a>-->";
                lit_del.Visible = true;
            }
        }
    }
    protected void rep_wwl_remark_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        int rcid = int.Parse(e.CommandArgument.ToString());
        HiddenField rtype = (HiddenField)e.Item.FindControl("hidetype");
        if (e.CommandName == "remarkDel")
        {
            if (rtype.Value == "-1") //删除词单评论
                words.WordListRemark_Delete(rcid);
            else
                words.WordRemark_Delete(rcid);
        }
        Server.Transfer("comment.aspx?u=" + uid.ToString());
    }    
    #endregion
}

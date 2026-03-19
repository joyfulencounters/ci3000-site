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

public partial class wordlist : BasePage
{
    public int wlid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        wlid = Data_Public.getQueryStringToInt("w");
        if(!IsPostBack)
        {
            Show_UserInfo_wordlist(wlid);
            Show_wordTypeList();
            Show_Info_WordList_One(wlid);
            RemarkList(1, wlid);
        }
    }
    
    #region 获取用户基本信息	
    private void Show_UserInfo_wordlist(int wlid)
    {
        DataTable dt = Users.Show_UserInfo_wordlist(wlid);
        if (dt.Rows.Count > 0)
        {
            this.img_user.NavigateUrl = "/user/default.aspx?u=" + dt.Rows[0]["userid"].ToString();
            this.img_user.ImageUrl = dt.Rows[0]["avater"].ToString();
            this.lit_name.Text = "<a href=\"/user/default.aspx?u=" + dt.Rows[0]["userid"].ToString() + "\">" + dt.Rows[0]["realname"].ToString() + "</a>";
            if (!string.IsNullOrEmpty(dt.Rows[0]["feeling"].ToString()))
                this.lit_feeling.Text = dt.Rows[0]["feeling"].ToString();

            this.lit_cr.Text = "<a href=\"/user/wordlist.aspx?u=" + dt.Rows[0]["userid"].ToString() + "\"><div class=\"WordlistRightA1\"><img src=\"images/word/word_26.gif\"/></div><div>创建<span class=\"Red\">" + dt.Rows[0]["wordlist"].ToString() + "</span>词单</div></a>";
            this.lit_co.Text = "<a href=\"/user/collection.aspx?u=" + dt.Rows[0]["userid"].ToString() + "\"><div class=\"WordlistRightA1\"><img src=\"images/word/word_29.gif\"/></div><div>收藏<span class=\"Red\">" + dt.Rows[0]["coll"].ToString() + "</span>词</div></a>";
            this.lit_r.Text = "<a href=\"/user/comment.aspx?u=" + dt.Rows[0]["userid"].ToString() + "\"><div class=\"WordlistRightA1\"><img src=\"images/word/word_28.gif\"/></div><div>评论<span class=\"Red\">" + dt.Rows[0]["wlamount"].ToString() + "</span>条</div></a>";
            this.lit_x.Text = "<a href=\"/user/word.aspx?u=" + dt.Rows[0]["userid"].ToString() + "\"><div class=\"WordlistRightA1\"><img src=\"images/word/word_27.gif\"/></div><div>添加<span class=\"Red\">" + dt.Rows[0]["addword"].ToString() + "</span>词</div></a>";

            if (uc.UserID.ToString() == dt.Rows[0]["userid"].ToString())   {
                string sign = "懒家伙，什么感言都没有留下...点击写下心情，快点！";
                if (!string.IsNullOrEmpty(dt.Rows[0]["feeling"].ToString())) sign = dt.Rows[0]["feeling"].ToString();
                this.lit_feeling.Text = "<span id=\"sp_sign\" onclick=\"CkSign(" + uc.UserID.ToString() + ")\">" + dt.Rows[0]["feeling"].ToString() + "</span>";

                MultiView1.ActiveViewIndex = 0;                
                pane_addwl.Visible = true;
                hypelnk_edit.Visible = true;
                hypelnk_edit.NavigateUrl = "/Create_word.aspx?w=" + wlid.ToString();
            }
            else {
                MultiView1.ActiveViewIndex = 1;
                if (uc.UserID <= 0)   {   
                    this.lit_Index.Text = "<a href=\"/member/signin.aspx?returnpage=" + Server.UrlEncode(Request.Url.ToString()) + "\"><span class=\"Name\">登录</span></a>后即可看到您与<span class=\"Name\">" + dt.Rows[0]["realname"].ToString() + "</span>的契合指数";
                }
                else         {
                    decimal dec = Users.Show_SameIndexUU(uc.UserID, int.Parse(dt.Rows[0]["userid"].ToString()));
                    this.lit_Index.Text = "您与<span class=\"Name\">" + dt.Rows[0]["realname"].ToString() + "</span>的契合指数为<span class=\"Red\">" + dec.ToString() + "</span>";
                }
                pane_addwl.Visible = false;
            }
        }
        else
        {
            Server.Transfer("/error.aspx");
        }
    }
    #endregion

    #region 某词单信息词列表
    private void Show_Info_WordList_One(int wlid)
    {
        DataTable dt = words.Show_Info_WordList_One(wlid);
        if (dt.Rows.Count > 0)
        {
            this.lit_titleName.Text = this.lit_wname.Text = dt.Rows[0]["name"].ToString();
            this.lit_content.Text = dt.Rows[0]["content"].ToString();
            this.lit_ctime.Text = dt.Rows[0]["addtime"].ToString();
            this.lit_rnum.Text = dt.Rows[0]["r_amount"].ToString();
            this.lit_cnum.Text = dt.Rows[0]["wordnum"].ToString();
            this.lit_rtime.Text = string.IsNullOrEmpty(dt.Rows[0]["lastrmktime"].ToString()) ? "" : ("最后评论时间 " + dt.Rows[0]["lastrmktime"].ToString());
        }
    }

    #endregion

    //词类型列表
    private void Show_wordTypeList()
    {
        DataTable dt = words.WordTypeList();
        string nameList = "";
        int wlid = Data_Public.getQueryStringToInt("w");
        for(int i=0;i<dt.Rows.Count;i++)
        {
            nameList += "<a href=\"javascript:void(0);\" onclick=\"WordAdd (" + uc.UserID + "," + dt.Rows[i]["t_id"].ToString() + "," + wlid + ");\" style='background:#f6f6f6; font-size:12px; color:#000; margin-right:10px; height:35px;'>" + dt.Rows[i]["name"].ToString() + "</a>";
        }
        lit_wordTypeList.Text = nameList;
    }

    #region 评论绑定    
    private void RemarkList(int pageIndex,int wlid)
    {
        int pageSize = 20;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = words.Show_WordList_Remark_Page(pageIndex,pageSize,wlid,out rowCount,out pageCount);            
        this.rep_RemarkWl.DataSource = dt;
        this.rep_RemarkWl.DataBind();

        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
        if (dt.Rows.Count <= 0) lit_NoMess.Visible = true;
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        RemarkList(e.NewPageIndex, Data_Public.getQueryStringToInt("w"));
    }

    //添加词单评论
    protected void Imgbtn_Ok_Click(object sender, EventArgs e)
    {
        string content = txt_ContentR.Value;
        int wlid = Data_Public.getQueryStringToInt("w");
        words.WordList_Remark(content, uc.UserID, wlid);
        RemarkList(1,wlid);
        Response.Redirect("/wordlist.aspx?w=" + wlid.ToString());
    }
    #endregion
}

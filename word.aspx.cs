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

public partial class word : BasePage
{
    public int wid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        wid = Data_Public.getQueryStringToInt("c");
        if (!IsPostBack)
        {   
            Show_Info_Word(wid);
            Show_Word_OfWordList(wid);
            Show_Word_Tags(wid);
            Show_Words_likeTag(wid);
            RemarkList(1,wid);
            Show_User_WordList(uc.UserID);            
        }
    }

    #region 当前登录用户的词单列表
    private void Show_User_WordList(int uid)
    {
        DataTable dt = words.Show_User_WordList(uid);
        string li = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            //li += "<li><a href=\"javascript:word_add(" + dt.Rows[i]["wl_id"].ToString() + ")\">" + dt.Rows[i]["name"].ToString() + "</a></li>";
            li += " <li style=\"cursor:pointer;\" onclick=\"word_add(" + dt.Rows[i]["wl_id"].ToString() + ")\" ><img src=\"images/word/gif-0464.gif\" /> " + dt.Rows[i]["name"].ToString() + "</li>";
        }
        lit_li.Text = li;
    }
    #endregion

    #region 词Tag
    private void Show_Word_Tags(int wid)
  {
      DataTable dt = words.Show_Word_Tags(wid);
      string li = "";
      for (int i = 0; i < dt.Rows.Count; i++)
      {
          li += "<a class=\"MeaningWordTag\" href=\"/search/wordTagSear.aspx?sear="
              + Server.UrlEncode(dt.Rows[i]["name"].ToString()) + "\">"
              + dt.Rows[i]["name"].ToString() + "</a>";
      }
      lit_TagList.Text = li;
  }

    #endregion    

    #region 与该词类似的词
    private void Show_Words_likeTag(int wid)
    {
        DataTable dt = words.Show_Words_likeTag(wid);        
        string strTag = "";
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            strTag += "<a href=\"/word.aspx?c="+dt.Rows[i]["w_id"].ToString()+"\">"+ dt.Rows[i]["name"].ToString()+"</a>　";
        }
        lit_tagWord.Text = strTag;

        if (dt.Rows.Count > 10)
        {
            hplnk_LikeWord.Visible = true;
            hplnk_LikeWord.NavigateUrl = "/morewords.aspx?c=" + wid.ToString();
        }
        else if (dt.Rows.Count <= 0)
            lit_tagWord.Text = "还没有类似的词";
    }
    #endregion

    #region 词基本信息
    private void Show_Info_Word(int wid)
    {
        DataTable dt = words.Show_Info_Word_One(wid,uc.UserID);
        if (dt.Rows.Count > 0)
        {
            this.lit_num.Text = dt.Rows[0]["inwlnum"].ToString();
            this.lit_cnum.Text = dt.Rows[0]["addword"].ToString();
            this.lit_realname.Text = "<a href=\"/user/default.aspx?u=" + dt.Rows[0]["userid"].ToString() + "\">" + dt.Rows[0]["realname"].ToString() + "</a>";
            lit.Text = lit_titleName.Text = lit_thisname.Text = this.lit_cname.Text = dt.Rows[0]["name"].ToString();
            this.lit_addtime.Text = dt.Rows[0]["addtime"].ToString();
            if (dt.Rows[0]["coll"].ToString() == "0")
            {
                this.hplnk_collection.ImageUrl = "/images/word/2.gif";
                this.hplnk_collection.NavigateUrl = "javascript:word_collection(" + wid + ")";
            }
            else
            {
                this.ImgHeart.Visible = true;
                this.hplnk_collection.NavigateUrl = "javascript:word_collection(" + wid + ")";
                this.hplnk_collection.ImageUrl = "/images/word/3.gif";
            }
            //获取flickr图片
            //string str = new Qywyxml().ShowFlickrImg(dt.Rows[0]["name"].ToString());
            //lit_flickr.Text = string.IsNullOrEmpty(str) ? (Data_Public.RandomSalutationS() + "<br/><br/>暂时没有相关图片显示") : str;
            lit_flickr.Text = "暂时关闭相关图片加载";       
        }
        else
        {
            Server.Transfer("/error.aspx");
        }
    }
    #endregion

    #region 这个词加入了以下词单
    private void Show_Word_OfWordList(int wid)
    {
        DataTable dt = words.Show_Word_OfWordList(wid);
        this.rep_WofWl.DataSource = dt;
        this.rep_WofWl.DataBind();
        if(dt.Rows.Count == 4)
            this.lit_more.Text = "<div class=\"MoreWrap\"><a href=\"/search/wordSear.aspx?sear=" + Server.UrlEncode(this.lit_cname.Text.Trim()) + "\" class=\"WordListMoreLink\">查看更多</a></div>";
    }
    #endregion

    #region 词评论
    private void RemarkList(int pageIndex, int wid)
    {
        int pageSize = 20;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = words.Show_Word_Remark_Page(pageIndex, pageSize, wid, out rowCount, out pageCount);
        this.rep_word_remark.DataSource = dt;
        this.rep_word_remark.DataBind();
        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
        if (dt.Rows.Count <= 0) lit_word_remark.Visible = true;
    }

    protected void rep_word_remark_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dv = (DataRowView)e.Item.DataItem;        
        Literal lit_content = (Literal)e.Item.FindControl("lit_content");
        Literal lit_remark = (Literal)e.Item.FindControl("lit_remark");
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (dv["r_type"].ToString() == "False") //评论
                lit_remark.Text = "评论 <span class=\"Word\">" + dv["name"].ToString() + "</span>";
            else//造句
                lit_remark.Text = "对 <span class=\"Word\">" + dv["name"].ToString() + "</span> 造句";
            
            lit_content.Text = dv["content"].ToString().Replace("@" + this.lit_cname.Text + "@", "<font color=\"red\">" + lit_cname.Text + "</font>");            
        }
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        RemarkList(e.NewPageIndex, wid);
    }
    
    protected void Imgbtn_submit_Click(object sender, EventArgs e)
    {
        string content = txt_ContentR.Value;
        string name = this.lit_cname.Text;
        if (!string.IsNullOrEmpty(name + content) && words.KillDog(name + content))
        {
            Response.Redirect("/error.aspx");
            Response.End();
        }
        bool zj = false;
        if (content.LastIndexOf("@" + name + "@") >= 0) //是该词的造句形势
            zj = true;

        words.Word_Remark(content, uc.UserID, zj, wid);
        Response.Redirect("/word.aspx?c=" + wid.ToString());
    }
    #endregion
}

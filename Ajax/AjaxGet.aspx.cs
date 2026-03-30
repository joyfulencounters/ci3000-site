using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using WebQywy;
public partial class Ajax_AjaxGet : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string str = Data_Public.getQueryStringToStr("Action");
            switch (str.ToLower())
            {
                case "chkem": //检测用户名
                    Chk_UserName();
                    break;
                case "chkwdn": //检测词
                    Chk_WordName();
                    break;
                case "wdcoll": //收藏词
                    Word_Collection();
                    break;
                case "wdadd":  //词添加
                    Word_Add();
                    break;
                case "remarkwl_del": //删除词单评论
                    WordListRemark_Delete();
                    break;
                case "remarkw_del": //删除词评论
                    WordRemark_Delete();
                    break;
                case "wordlist_wordpage": //某词单下词列表
                    Show_WordList_Word_Page();
                    break;
                case "word_del": //删除词
                    WordListW_Del();
                    break;
                case "wordlist_del": //删除词单
                    WordList_Del();
                    break;
                case "random_word": // 小程序随机取词
                    Random_Word();
                    break;
                case "random_wordlist": // 小程序随机词单
                    Random_WordList();
                    break;
                default:
                    Response.Write("False");
                    break;
            }
        }
    }

    #region 检测email
    /// <summary>
    /// return true 可以使用 false 不能
    /// </summary>
    private void Chk_UserName()
    {
        string email = Data_Public.getQueryStringToStr("email");
        Response.Write(Users.Chk_UserName(email));
    }
    #endregion

    #region 检测词
    /// <summary>
    /// string
    /// </summary>
    private void Chk_WordName()
    {
        string name = Data_Public.getQueryStringToStr("name");
        int uid = Data_Public.getQueryStringToInt("uid");
        int wlID = Data_Public.getQueryStringToInt("wlid");
        string str = words.Word_Check(name,uid,wlID);
        Response.Write(str);
    }
    #endregion

    #region 添加词到词单
    /// <summary>
    /// 添加词到词单
    /// </summary>
    private void Word_Add()
    {
        int wid = Data_Public.getQueryStringToInt("wID");
        int wlid = Data_Public.getQueryStringToInt("wlID");
        int uid = Data_Public.getQueryStringToInt("uID");
        int num = words.WordList_Add(wid,wlid, uid);
        Response.Write(num);
    }
    #endregion

    #region 收藏词
    /// <summary>
    /// string
    /// </summary>
    private void Word_Collection()
    {
        int wid = Data_Public.getQueryStringToInt("wID");
        int uid = Data_Public.getQueryStringToInt("uID");
        int num = words.Word_Collection(wid, uid);
        Response.Write(num);
    }
    #endregion

    #region 1（true） 排列显示，0（false） 列表显示
    
    private void Show_WordList_Word_Page()
    {
        int pageIndex = Data_Public.getQueryStringToInt("PageIndex") == 0 ? 1 : Data_Public.getQueryStringToInt("PageIndex");
        int wlid = Data_Public.getQueryStringToInt("Wlid");
        string type = Data_Public.getQueryStringToStr("Type");
        int pageSize = 10;
        if (type == "true")
            pageSize = 60;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = words.Show_WordList_Word_Page(pageIndex, pageSize, wlid, (type == "true" ? true : false), out rowCount, out pageCount);
        System.Text.StringBuilder strb = new System.Text.StringBuilder();
        strb.AppendFormat("<div id=\"pagecount\" style=\"display:none\">{0}</div>", pageCount);
        if (type == "true")
        {
            strb.Append("<div class=\"CreateWordlistD\"><ul class=\"BlackWordList\">");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strb.AppendFormat("<li onmouseover=\"wlconmouseover({0})\" onmouseout=\"wlconmouseout({0})\"><a href=\"/word.aspx?c={0}\" >{1}</a>", dt.Rows[i]["w_id"].ToString(), dt.Rows[i]["name"].ToString());
                
                if(uc.UserID.ToString() == dt.Rows[i]["uid"].ToString())
                    strb.AppendFormat("<a id=\"showaid_{0}\" href=\"javascript:wlcDel({0},{1},{2})\" style=\"display:none;color:#999;font-size:16px;margin-left:5px;\">×</a>",
                        dt.Rows[i]["w_id"].ToString(), dt.Rows[i]["wl_id"].ToString(), uc.UserID.ToString());
                strb.Append("</li>");
            }
            strb.Append("</ul></div>");
        }
        else
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strb.Append("<div class=\"CommentsText\">");
                strb.Append("<div class=\"CreateWordlistD2\" style=\"position:relative;\">");
                strb.Append("<div class=\"WordListItemContent\">");
                strb.AppendFormat("<a href=\"/word.aspx?c={0}\" ><span class=\"BlackWord\">{1}</span></a>　　<a href=\"/user/default.aspx?u={2}\" ><span class=\"Name\">{3}</span></a> 添加于{4}　　被列入<span class=\"Red\">{5}</span>词单中", dt.Rows[i]["w_id"].ToString(), dt.Rows[i]["name"].ToString(),dt.Rows[i]["adduserid"].ToString(), dt.Rows[i]["realname"].ToString(), Convert.ToDateTime(dt.Rows[i]["adtime"]).ToString("yyyy-MM-dd HH:mm"), dt.Rows[i]["wlcount"].ToString());
                strb.Append("</div>");
                if (uc.UserID.ToString() == dt.Rows[i]["uid"].ToString())
                    strb.AppendFormat("<a href=\"javascript:wlcDel({0},{1})\" class=\"WordListDelBtn\">×</a>",dt.Rows[i]["w_id"].ToString(),dt.Rows[i]["wl_id"].ToString());
                strb.Append("</div>");
                strb.AppendFormat("<div class=\"Gray\">针对{0}，{1}说道：{2}</div>", dt.Rows[i]["name"].ToString(), dt.Rows[i]["realname"].ToString(), dt.Rows[i]["content"].ToString());
                strb.Append("</div>");
            }
        }
        Response.Write(strb.ToString());
    }

    #endregion

    #region 删除词评论
    /// <summary>
    /// string
    /// </summary>
    private void WordRemark_Delete()
    {
        int cid = Data_Public.getQueryStringToInt("Cid");
        int num = words.WordRemark_Delete(cid);
        Response.Write(num);
    }
    #endregion

    #region 删除词单评论
    /// <summary>
    /// 删除词单评论
    /// </summary>
    private void WordListRemark_Delete()
    {
        int cid = Data_Public.getQueryStringToInt("Cid");
        int num = words.WordListRemark_Delete(cid);
        Response.Write(cid);
    }
    #endregion

    #region 删除词单中的词
    /// <summary>
    /// 删除词单中的词
    /// </summary>
    private void WordListW_Del()
    {
        int wid = Data_Public.getQueryStringToInt("wID");
        int wlid = Data_Public.getQueryStringToInt("wlID");
        int uid = Data_Public.getQueryStringToInt("uID");
        int num = words.WordList_Delete(wid, wlid, uid);
        Response.Write(num);
    }
    #endregion

    #region 删除词单
    /// <summary>
    /// 删除词单
    /// </summary>
    private void WordList_Del()
    {
        int wlid = Data_Public.getQueryStringToInt("wlID");
        int num = words.WordList_Delete(wlid);
        Response.Write(num);
    }
    #endregion
    
#region 小程序随机取词
private void Random_Word()
{
    // 1. 随机取一个词ID
    int wid = words.Show_WordID_Random();

    // 2. 查词信息
    DataTable dtWord = words.Show_Info_Word_One(wid);

    // 3. 查tag
    DataTable dtTag = words.Show_Word_Tags(wid);

    // 4. 查同tag词
    DataTable dtLike = words.Show_Words_likeTag(wid);

    System.Text.StringBuilder json = new System.Text.StringBuilder();

    json.Append("{");

    // 当前词
    if (dtWord.Rows.Count > 0)
    {
        json.AppendFormat("\"word\":{{\"id\":{0},\"name\":\"{1}\"}},",
            dtWord.Rows[0]["w_id"],
            dtWord.Rows[0]["name"].ToString().Replace("\"", "")
        );
    }
    else
    {
        json.Append("\"word\":{\"id\":0,\"name\":\"\"},");
    }

    // tags 数组
    json.Append("\"tags\":[");
    for (int i = 0; i < dtTag.Rows.Count; i++)
    {
        json.AppendFormat("\"{0}\"", dtTag.Rows[i]["name"].ToString().Replace("\"", ""));
        if (i != dtTag.Rows.Count - 1)
            json.Append(",");
    }
    json.Append("],");

    // 为兼容旧前端，保留一个主 tag
    if (dtTag.Rows.Count > 0)
    {
        json.AppendFormat("\"tag\":\"{0}\",",
            dtTag.Rows[0]["name"].ToString().Replace("\"", "")
        );
    }
    else
    {
        json.Append("\"tag\":\"\",");
    }

    // 相关词
    json.Append("\"related\":[");
    for (int i = 0; i < dtLike.Rows.Count; i++)
    {
        json.AppendFormat("{{\"id\":{0},\"name\":\"{1}\"}}",
            dtLike.Rows[i]["w_id"],
            dtLike.Rows[i]["name"].ToString().Replace("\"", "")
        );

        if (i != dtLike.Rows.Count - 1)
            json.Append(",");
    }
    json.Append("]");

    json.Append("}");

    Response.Write(json.ToString());
}
#endregion

#region 小程序随机词单
private void Random_WordList()
{
    DataTable dtWordList = words.Show_WordList_Random();
    System.Text.StringBuilder json = new System.Text.StringBuilder();

    json.Append("{");

    if (dtWordList != null && dtWordList.Rows.Count > 0)
    {
        int wlid = Convert.ToInt32(dtWordList.Rows[0]["wl_id"]);
        string wlname = dtWordList.Rows[0]["name"].ToString().Replace("\"", "");
       string wlcontent = dtWordList.Rows[0]["content"] == DBNull.Value 
    ? "" 
    : dtWordList.Rows[0]["content"].ToString().Replace("\"", "").Trim();

wlcontent = wlcontent == "请简单说明这个词单的主题" ? "" : wlcontent;

        DataTable dtWords = words.Show_WordList_Words_All(wlid);

        json.AppendFormat("\"wordlist\":{{\"id\":{0},\"name\":\"{1}\",\"content\":\"{2}\",\"count\":{3}}},",
    wlid,
    wlname,
    wlcontent,
    dtWords.Rows.Count
);
        json.Append("\"words\":[");

        int max = dtWords.Rows.Count > 24 ? 24 : dtWords.Rows.Count;

        for (int i = 0; i < max; i++)
        {
            json.AppendFormat(
                "{{\"id\":{0},\"name\":\"{1}\"}}",
                dtWords.Rows[i]["w_id"],
                dtWords.Rows[i]["name"].ToString().Replace("\"", "")
            );

            if (i != max - 1)
                json.Append(",");
        }

        json.Append("]");
    }
    else
    {
        json.Append("\"wordlist\":{\"id\":0,\"name\":\"\"},\"words\":[]");
    }

    json.Append("}");

    Response.Write(json.ToString());
}
#endregion

}


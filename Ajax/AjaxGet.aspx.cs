using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient; 
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using WebQywy;
using WebQywyBusiness;
using System.Collections.Generic;
using System.Text;
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
                case "wx_login": //公众号登录                    
                    Wx_Login();
                    break;
                case "add_tag": //小程序加tag
                    Add_Tag();
                    break;
                case "get_word_comments":
                    Get_Word_Comments();
                    break;
                case "add_word_comment":
                    Add_Word_Comment();
                    break;
                case "get_wordlist_comments":
                    Get_WordList_Comments();
                    break;
                case "add_wordlist_comment":
                    Add_WordList_Comment();
                    break;    
                case "random_wordlist": // 小程序随机词单
                    Random_WordList();
                    break;
                case "getwordsbytag": // 小程序按感觉(tag)查词
                    GetWordsByTag();
                    break;
                case "getwordbyid":
                    GetWordById();
                    break;
                    case "getwordlistbyid":
                    GetWordListById();
                    break;
                case "get_wordlists_by_word":
                    GetWordListsByWord();
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
            JsonSafe(dtWord.Rows[0]["name"].ToString())
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
        json.AppendFormat("\"{0}\"", JsonSafe(dtTag.Rows[i]["name"].ToString()));
        if (i != dtTag.Rows.Count - 1)
            json.Append(",");
    }
    json.Append("],");

    // 为兼容旧前端，保留一个主 tag
    if (dtTag.Rows.Count > 0)
    {
        json.AppendFormat("\"tag\":\"{0}\",",
            JsonSafe(dtTag.Rows[0]["name"].ToString())
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
            JsonSafe(dtLike.Rows[i]["name"].ToString())
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
        string wlname = JsonSafe(dtWordList.Rows[0]["name"].ToString());
string wlcontent = dtWordList.Rows[0]["content"] == DBNull.Value
    ? ""
    : JsonSafe(dtWordList.Rows[0]["content"].ToString().Trim());

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
    JsonSafe(dtWords.Rows[i]["name"].ToString())
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

#region 小程序按感觉(tag)查词
private void GetWordsByTag()
{
    string tag = Data_Public.getQueryStringToStr("tag").Trim();
    int page = Data_Public.getQueryStringToInt("page");
    int pageSize = Data_Public.getQueryStringToInt("pagesize");

    if (page <= 0) page = 1;
    if (pageSize <= 0) pageSize = 37;
    if (pageSize > 60) pageSize = 60;

    System.Text.StringBuilder json = new System.Text.StringBuilder();

    if (string.IsNullOrEmpty(tag))
    {
        json.Append("{");
        json.Append("\"status\":0,");
        json.Append("\"msg\":\"tag不能为空\",");
        json.Append("\"tag\":\"\",");
        json.Append("\"rowCount\":0,");
        json.Append("\"pageCount\":0,");
        json.Append("\"list\":[]");
        json.Append("}");

        Response.Write(json.ToString());
        return;
    }

    int rowCount = 0;
    int pageCount = 0;
    DataTable dt = search.Search_word_OfTag_Page(page, pageSize, tag, out rowCount, out pageCount);

    json.Append("{");
    json.Append("\"status\":1,");
    json.Append("\"msg\":\"success\",");
    json.AppendFormat("\"tag\":\"{0}\",", JsonSafe(tag));
    json.AppendFormat("\"rowCount\":{0},", rowCount);
    json.AppendFormat("\"pageCount\":{0},", pageCount);
    json.Append("\"list\":[");

    if (dt != null && dt.Rows.Count > 0)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i > 0) json.Append(",");

            string wid = dt.Rows[i]["w_id"].ToString();
            string name = dt.Rows[i]["name"].ToString();
            string content = dt.Rows[i]["content"] == DBNull.Value ? "" : dt.Rows[i]["content"].ToString();

            json.Append("{");
            json.AppendFormat("\"id\":{0},", string.IsNullOrEmpty(wid) ? "0" : wid);
            json.AppendFormat("\"name\":\"{0}\",", JsonSafe(name));
            json.AppendFormat("\"content\":\"{0}\"", JsonSafe(content));
            json.Append("}");
        }
    }

    json.Append("]");
    json.Append("}");

    Response.Write(json.ToString());
}
#endregion

private string JsonSafe(string text)
{
    if (string.IsNullOrEmpty(text))
        return "";

    return text.Replace("\\", "\\\\")
               .Replace("\"", "\\\"")
               .Replace("\r", "")
               .Replace("\n", " ");
}

#region 小程序按ID取词
private void GetWordById()
{
    int wid = Data_Public.getQueryStringToInt("id");

    System.Text.StringBuilder json = new System.Text.StringBuilder();
    json.Append("{");

    if (wid <= 0)
    {
        json.Append("\"status\":0,");
        json.Append("\"msg\":\"id不能为空\",");
        json.Append("\"word\":{\"id\":0,\"name\":\"\"},");
        json.Append("\"tags\":[],");
        json.Append("\"tag\":\"\",");
        json.Append("\"related\":[]");
        json.Append("}");

        Response.Write(json.ToString());
        return;
    }

    DataTable dtWord = words.Show_Info_Word_One(wid);
    DataTable dtTag = words.Show_Word_Tags(wid);
    DataTable dtLike = words.Show_Words_likeTag(wid);

    json.Append("\"status\":1,");
    json.Append("\"msg\":\"success\",");

    if (dtWord != null && dtWord.Rows.Count > 0)
    {
        json.AppendFormat("\"word\":{{\"id\":{0},\"name\":\"{1}\"}},",
            dtWord.Rows[0]["w_id"],
            JsonSafe(dtWord.Rows[0]["name"].ToString())
        );
    }
    else
    {
        json.Append("\"word\":{\"id\":0,\"name\":\"\"},");
    }

    json.Append("\"tags\":[");
    if (dtTag != null && dtTag.Rows.Count > 0)
    {
        for (int i = 0; i < dtTag.Rows.Count; i++)
        {
            if (i > 0) json.Append(",");
            json.AppendFormat("\"{0}\"", JsonSafe(dtTag.Rows[i]["name"].ToString()));
        }
    }
    json.Append("],");

    if (dtTag != null && dtTag.Rows.Count > 0)
    {
        json.AppendFormat("\"tag\":\"{0}\",", JsonSafe(dtTag.Rows[0]["name"].ToString()));
    }
    else
    {
        json.Append("\"tag\":\"\",");
    }

    json.Append("\"related\":[");
    if (dtLike != null && dtLike.Rows.Count > 0)
    {
        for (int i = 0; i < dtLike.Rows.Count; i++)
        {
            if (i > 0) json.Append(",");
            json.AppendFormat("{{\"id\":{0},\"name\":\"{1}\"}}",
                dtLike.Rows[i]["w_id"],
                JsonSafe(dtLike.Rows[i]["name"].ToString())
            );
        }
    }
    json.Append("]");

    json.Append("}");

    Response.Write(json.ToString());
}
#endregion

private void GetWordListsByWord()
{
    int wid = Data_Public.getQueryStringToInt("id");

    StringBuilder json = new StringBuilder();
    json.Append("{");

    if (wid <= 0)
    {
        json.Append("\"list\":[]}");
        Response.Write(json.ToString());
        return;
    }

    DataTable dt = words.Show_Word_OfWordList(wid);

    json.Append("\"list\":[");

    if (dt != null && dt.Rows.Count > 0)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            if (i > 0) json.Append(",");

            json.AppendFormat(
                "{{\"id\":{0},\"name\":\"{1}\"}}",
                dt.Rows[i]["wl_id"],
                JsonSafe(dt.Rows[i]["name"].ToString())
            );
        }
    }

    json.Append("]}");

    Response.Write(json.ToString());
}


#region 小程序按ID取词单
private void GetWordListById()
{
    int wlid = Data_Public.getQueryStringToInt("id");
    System.Text.StringBuilder json = new System.Text.StringBuilder();

    json.Append("{");

    if (wlid <= 0)
    {
        json.Append("\"status\":0,");
        json.Append("\"msg\":\"id不能为空\",");
        json.Append("\"wordlist\":{\"id\":0,\"name\":\"\",\"content\":\"\",\"count\":0},");
        json.Append("\"words\":[]");
        json.Append("}");

        Response.Write(json.ToString());
        return;
    }

    DataTable dtWordList = words.Show_Info_WordList_One(wlid);

    if (dtWordList == null || dtWordList.Rows.Count == 0)
    {
        json.Append("\"status\":0,");
        json.Append("\"msg\":\"未找到该词单\",");
        json.Append("\"wordlist\":{\"id\":0,\"name\":\"\",\"content\":\"\",\"count\":0},");
        json.Append("\"words\":[]");
        json.Append("}");

        Response.Write(json.ToString());
        return;
    }

    string wlname = JsonSafe(dtWordList.Rows[0]["name"].ToString());
    string wlcontent = dtWordList.Rows[0]["content"] == DBNull.Value
        ? ""
        : JsonSafe(dtWordList.Rows[0]["content"].ToString().Trim());

    wlcontent = wlcontent == "请简单说明这个词单的主题" ? "" : wlcontent;

    DataTable dtWords = words.Show_WordList_Words_All(wlid);

    int wordCount = dtWords == null ? 0 : dtWords.Rows.Count;

    json.Append("\"status\":1,");
    json.Append("\"msg\":\"success\",");
    json.AppendFormat(
        "\"wordlist\":{{\"id\":{0},\"name\":\"{1}\",\"content\":\"{2}\",\"count\":{3}}},",
        wlid,
        wlname,
        wlcontent,
        wordCount
    );

    json.Append("\"words\":[");

    if (dtWords != null && dtWords.Rows.Count > 0)
    {
        int max = dtWords.Rows.Count > 24 ? 24 : dtWords.Rows.Count;

        for (int i = 0; i < max; i++)
        {
            if (i > 0) json.Append(",");

            json.AppendFormat(
                "{{\"id\":{0},\"name\":\"{1}\"}}",
                dtWords.Rows[i]["w_id"],
                JsonSafe(dtWords.Rows[i]["name"].ToString())
            );
        }
    }

    json.Append("]");
    json.Append("}");

    Response.Write(json.ToString());
}
#endregion


#region 小程序微信登录（简化版）
private void Wx_Login()
{
    string code = Request["code"];
    System.Text.StringBuilder json = new System.Text.StringBuilder();

    if (string.IsNullOrEmpty(code))
    {
        Response.Write("{\"success\":false,\"msg\":\"code为空\"}");
        return;
    }

    string appid = "wxb2cc272cc83de34c";
    string secret = "806f808fd155ca9fdcf124c0301dfd08";

    string url = "https://api.weixin.qq.com/sns/jscode2session?appid=" + appid
        + "&secret=" + secret
        + "&js_code=" + code
        + "&grant_type=authorization_code";

    string wxResult = "";

    try
    {
        System.Net.WebRequest request = System.Net.WebRequest.Create(url);
        request.Method = "GET";

        using (System.Net.WebResponse response = request.GetResponse())
        {
            using (System.IO.Stream stream = response.GetResponseStream())
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream, System.Text.Encoding.UTF8))
                {
                    wxResult = reader.ReadToEnd();
                }
            }
        }
    }
    catch (Exception ex)
    {
        Response.Write("{\"success\":false,\"msg\":\"请求微信接口失败：" + ex.Message.Replace("\"", "'") + "\"}");
        return;
    }

    if (string.IsNullOrEmpty(wxResult))
    {
        Response.Write("{\"success\":false,\"msg\":\"微信返回为空\"}");
        return;
    }

    string openid = "";
    try
    {
        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
        var dic = js.Deserialize<Dictionary<string, object>>(wxResult);

        if (dic.ContainsKey("openid"))
        {
            openid = dic["openid"].ToString();
        }
        else
        {
            string errMsg = wxResult.Replace("\"", "'");
            Response.Write("{\"success\":false,\"msg\":\"微信登录失败\",\"wx\":\"" + errMsg + "\"}");
            return;
        }
    }
    catch (Exception ex)
    {
        Response.Write("{\"success\":false,\"msg\":\"解析微信返回失败：" + ex.Message.Replace("\"", "'") + "\"}");
        return;
    }

    string sql = "SELECT Userid FROM aml_users WHERE openid=@openid";

    SqlParameter[] pars = {
        new SqlParameter("@openid", SqlDbType.VarChar,100)
    };
    pars[0].Value = openid;

    DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, sql, pars);

    int userid = 0;

    if (ds.Tables[0].Rows.Count > 0)
    {
        userid = Convert.ToInt32(ds.Tables[0].Rows[0]["Userid"]);
    }
    else
    {
        string randomName = "wx用户" + DateTime.Now.Ticks.ToString().Substring(10);

        string insertUserSql = @"
        INSERT INTO aml_users(email,password,realname,avater,openid,LoginTimes,createDate,lastDate)
        VALUES(@email,'',@name,'/images/avatar/wx.png',@openid,0,GETDATE(),GETDATE());
        SELECT @@IDENTITY;
        ";

        SqlParameter[] pars2 = {
            new SqlParameter("@email", SqlDbType.VarChar,50),
            new SqlParameter("@name", SqlDbType.VarChar,50),
            new SqlParameter("@openid", SqlDbType.VarChar,100)
        };

        pars2[0].Value = openid + "@wx.com";
        pars2[1].Value = randomName;
        pars2[2].Value = openid;

        object obj = DataBusiness.RunReturnScalar(CommandType.Text, insertUserSql, pars2);
        userid = Convert.ToInt32(obj);
    }

    json.Append("{\"success\":true,\"openid\":\"" + openid + "\",\"userid\":" + userid + "}");
    Response.Write(json.ToString());
}
#endregion

#region 添加共鸣签
private void Add_Tag()
{
    string wid = Request["wid"];
    string tag = Request["tag"];
    string userid = Request["userid"];

    if (string.IsNullOrEmpty(wid) || string.IsNullOrEmpty(tag) || string.IsNullOrEmpty(userid))
    {
        Response.Write("{\"success\":false}");
        return;
    }

    // 简单清洗
    tag = tag.Trim().Replace("\"", "");

    if (tag.Length < 2 || tag.Length > 8)
    {
        Response.Write("{\"success\":false,\"msg\":\"长度需2-8字\"}");
        return;
    }

    string sql = @"
    INSERT INTO Aml_wordtag(name,addtime,userid,w_id)
    VALUES(@name,GETDATE(),@userid,@wid)
    ";

    SqlParameter[] pars = {
        new SqlParameter("@name", SqlDbType.VarChar,50),
        new SqlParameter("@userid", SqlDbType.Int),
        new SqlParameter("@wid", SqlDbType.Int)
    };

    pars[0].Value = tag;
    pars[1].Value = Convert.ToInt32(userid);
    pars[2].Value = Convert.ToInt32(wid);

    DataBusiness.RunReturnInt(CommandType.Text, sql, pars);

    Response.Write("{\"success\":true}");
}
#endregion

#region 获取词评论
private void Get_Word_Comments()
{
    string wid = Request["wid"];

    if (string.IsNullOrEmpty(wid))
    {
        Response.Write("{\"success\":false,\"list\":[]}");
        return;
    }

    string sql = @"
    SELECT TOP 30 rw_id, content, addtime, userid
    FROM aml_remarkw
    WHERE w_id=@wid
    ORDER BY rw_id DESC
    ";

    SqlParameter[] pars = {
        new SqlParameter("@wid", SqlDbType.Int)
    };
    pars[0].Value = Convert.ToInt32(wid);

    DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, sql, pars);

    System.Text.StringBuilder json = new System.Text.StringBuilder();
    json.Append("{\"success\":true,\"list\":[");

    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    {
        DataRow dr = ds.Tables[0].Rows[i];

        if (i > 0) json.Append(",");

        string content = JsonSafe(dr["content"].ToString());
        string addtime = JsonSafe(dr["addtime"].ToString());
        string userid = dr["userid"].ToString();

        json.Append("{");
        json.Append("\"id\":" + dr["rw_id"].ToString() + ",");
        json.Append("\"content\":\"" + content + "\",");
        json.Append("\"addtime\":\"" + addtime + "\",");
        json.Append("\"userid\":" + userid + ",");
        json.Append("\"nickname\":\"" + JsonSafe("用户" + userid) + "\"");
        json.Append("}");
    }

    json.Append("]}");
    Response.Write(json.ToString());
}
#endregion


#region 发表词评论
private void Add_Word_Comment()
{
    string wid = Request["wid"];
    string content = Request["content"];
    string userid = Request["userid"];

    if (string.IsNullOrEmpty(wid) || string.IsNullOrEmpty(content) || string.IsNullOrEmpty(userid))
    {
        Response.Write("{\"success\":false,\"msg\":\"参数不完整\"}");
        return;
    }

    content = content.Trim().Replace("\"", "");

    if (content.Length < 2 || content.Length > 100)
    {
        Response.Write("{\"success\":false,\"msg\":\"评论长度需2-100字\"}");
        return;
    }

    string sql = @"
    INSERT INTO aml_remarkw(content,addtime,userid,r_type,w_id)
    VALUES(@content,GETDATE(),@userid,0,@wid)
    ";

    SqlParameter[] pars = {
        new SqlParameter("@content", SqlDbType.VarChar,500),
        new SqlParameter("@userid", SqlDbType.Int),
        new SqlParameter("@wid", SqlDbType.Int)
    };

    pars[0].Value = content;
    pars[1].Value = Convert.ToInt32(userid);
    pars[2].Value = Convert.ToInt32(wid);

    DataBusiness.RunReturnInt(CommandType.Text, sql, pars);

    Response.Write("{\"success\":true}");
}
#endregion


#region 获取词单评论
private void Get_WordList_Comments()
{
    string wlid = Request["wlid"];

    if (string.IsNullOrEmpty(wlid))
    {
        Response.Write("{\"success\":false,\"list\":[]}");
        return;
    }

    string sql = @"
    SELECT TOP 30 rwl_id, content, addtime, user_id
    FROM aml_remarkwl
    WHERE wl_id=@wlid
    ORDER BY rwl_id DESC
    ";

    SqlParameter[] pars = {
        new SqlParameter("@wlid", SqlDbType.Int)
    };
    pars[0].Value = Convert.ToInt32(wlid);

    DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, sql, pars);

    System.Text.StringBuilder json = new System.Text.StringBuilder();
    json.Append("{\"success\":true,\"list\":[");

    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
    {
        DataRow dr = ds.Tables[0].Rows[i];

        if (i > 0) json.Append(",");

        string content = JsonSafe(dr["content"].ToString());
        string addtime = JsonSafe(dr["addtime"].ToString());
        string userid = dr["user_id"].ToString();

        json.Append("{");
        json.Append("\"id\":" + dr["rwl_id"].ToString() + ",");
        json.Append("\"content\":\"" + content + "\",");
        json.Append("\"addtime\":\"" + addtime + "\",");
        json.Append("\"userid\":" + userid + ",");
        json.Append("\"nickname\":\"" + JsonSafe("用户" + userid) + "\"");
        json.Append("}");
    }

    json.Append("]}");
    Response.Write(json.ToString());
}
#endregion



#region 发表词单评论
private void Add_WordList_Comment()
{
    string wlid = Request["wlid"];
    string content = Request["content"];
    string userid = Request["userid"];

    if (string.IsNullOrEmpty(wlid) || string.IsNullOrEmpty(content) || string.IsNullOrEmpty(userid))
    {
        Response.Write("{\"success\":false,\"msg\":\"参数不完整\"}");
        return;
    }

    content = content.Trim().Replace("\"", "");

    if (content.Length < 2 || content.Length > 100)
    {
        Response.Write("{\"success\":false,\"msg\":\"评论长度需2-100字\"}");
        return;
    }

    string sql = @"
    INSERT INTO aml_remarkwl(content,addtime,user_id,wl_id)
    VALUES(@content,GETDATE(),@userid,@wlid)
    ";

    SqlParameter[] pars = {
        new SqlParameter("@content", SqlDbType.VarChar,500),
        new SqlParameter("@userid", SqlDbType.Int),
        new SqlParameter("@wlid", SqlDbType.Int)
    };

    pars[0].Value = content;
    pars[1].Value = Convert.ToInt32(userid);
    pars[2].Value = Convert.ToInt32(wlid);

    DataBusiness.RunReturnInt(CommandType.Text, sql, pars);

    Response.Write("{\"success\":true}");
}
#endregion


}


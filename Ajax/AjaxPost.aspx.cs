using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using WebQywy;

public partial class Ajax_AjaxPost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string str = Data_Public.getFormStringToStr("Action");
            switch (str.ToLower())
            {
                case "wdnin": //添加词
                    Word_In();
                    break;                  
                case "wdnadd": //添加词（词单）
                    Word_add();
                    break;
                case "wordcoll": //添加词（收藏）
                    Word_collection();
                    break;
                case "chkwordcoll": //收藏词(检测)
                    Check_Word_collection();
                    break;
                case "feeledt": //更新心情
                    Feeling_Edt();
                    break;
                case "tagadd": //tag 添加
                    Tag_Create();
                    break;
                case "wdltcreate": //创建词单
                    wdltcreate();
                    break;
                case "winwdlt": //存在的词入词单
                    InWordListAdd();
                    break;
                default:
                    Response.Write("False");
                    break;
            }
        }
    }

    #region 添加词
    private void Word_In()
    {
        string name = Data_Public.getFormStringToStr("name");
        string content = Data_Public.getFormStringToStr("txtCont");
        int type = Data_Public.getFormStringToInt("tID");
        int uid = Data_Public.getFormStringToInt("uID");
        string errorMsg = "";
        bool solu = words.Word_Create(name, content, uid, type, out errorMsg);
        Response.Write(solu.ToString());
    }
    #endregion

    #region 添加词（词单）
    private void Word_add()
    {
        string name = Data_Public.getFormStringToStr("name");
        string content = Data_Public.getFormStringToStr("txtCont");
        int type = Data_Public.getFormStringToInt("tID");
        int uid = Data_Public.getFormStringToInt("uID");
        int wlid = Data_Public.getFormStringToInt("wlID");
        string errorMsg = "";
        bool solu = words.Word_Create(name, content, uid, type, wlid, out errorMsg);
        Response.Write(solu.ToString());
    }
    #endregion

    #region 添加词（收藏）
    private void Word_collection()
    {
        string name = Data_Public.getFormStringToStr("name");
        string content = Data_Public.getFormStringToStr("txtCont");
        int type = Data_Public.getFormStringToInt("tID");
        int uid = Data_Public.getFormStringToInt("uID");
        string errorMsg = "";
        bool solu = words.Word_Collection(name, content, uid, type, out errorMsg);
        Response.Write(solu.ToString());
    }
    #endregion

    #region 收藏词（检测）
    private void Check_Word_collection()
    {
        string name = Data_Public.getFormStringToStr("name");
        int uid = Data_Public.getFormStringToInt("uID");
        string errorMsg = "";
        bool solu = words.Word_Collection(name, uid, out errorMsg);
        Response.Write(errorMsg);
    }
    #endregion

    #region 更新心情
    private void Feeling_Edt()
    {
        string feel = Data_Public.getFormStringToStr("txtCont");
        int uid = Data_Public.getFormStringToInt("uID");
        Users.Users_feeling_Edit(feel, uid);
    }
    #endregion

    #region 添加Tag    
    private void Tag_Create()
    {
        string name = Data_Public.getFormStringToStr("name");
        int uid = Data_Public.getFormStringToInt("uID");
        int wID = Data_Public.getFormStringToInt("wID");
        int num = words.Words_Tag_Create(name, uid, wID);
        Response.Write(num);
    }
    #endregion

    #region 创建词单
    private void wdltcreate()
    {
        string name = Data_Public.getFormStringToStr("Name");
        string content = Data_Public.getFormStringToStr("txtCont");
        int uid = Data_Public.getFormStringToInt("uID");
        int num = words.WordList_Create(name, content, uid);
        Response.Write(num);
    }
    #endregion

    #region 存在的词入词单
    private void InWordListAdd()
    {
        string name = Data_Public.getFormStringToStr("Name");
        int wlid = Data_Public.getFormStringToInt("wlid");
        int uid = Data_Public.getFormStringToInt("uID");
        int num = words.WordList_Add(name, wlid, uid);
        Response.Write(num);
    }
    #endregion
}

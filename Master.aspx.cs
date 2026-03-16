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
using System.Text;
using WebQywy;
public partial class Master : BasePage
{    
    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!IsPostBack)
        {
            if (uc.UserID <= 0)
                Response.Redirect("/");
            
            Show_UserInfo_newword(uc.UserID);
            RecommendWL();
        }
    }

    #region 获取用户基本信息
    private void Show_UserInfo_newword(int uid)
    {
        DataTable dt = Users.Show_UserInfo_newword(uid);
        if (dt.Rows.Count > 0)
        {
            this.img_user.Src = dt.Rows[0]["avater"].ToString();
            this.lit_titleName.Text = this.lit_name.Text = dt.Rows[0]["realname"].ToString();
            if (!string.IsNullOrEmpty(dt.Rows[0]["feeling"].ToString()))
                this.lit_feeling.Text = dt.Rows[0]["feeling"].ToString();
            
            if (int.Parse(dt.Rows[0]["wordlist"].ToString()) > 0 || int.Parse(dt.Rows[0]["coll"].ToString()) > 0 || int.Parse(dt.Rows[0]["addword"].ToString()) > 0)
            {
                Response.Redirect("/user/");
            }
        }
        else
        {
            Response.Redirect("/");
        }
    }
    #endregion

    #region 推荐词单
    private void RecommendWL()
    {
        StringBuilder strB = new StringBuilder();
        DataSet ds = words.Show_wordlist_commend();
        DataTable dt1 = ds.Tables[0];
        DataTable dt2 = ds.Tables[1];
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            strB.Append("<li style=\"height:230px;\">");
            strB.AppendFormat("<div class=\"WordTxt\"><div class=\"WordTxt1\"><div class=\"Autographedphotos\"><a href=\"/user/default.aspx?u={0}\"><img src=\"{1}\" /></a></div>", dt1.Rows[i]["userid"].ToString(), dt1.Rows[i]["avater"].ToString());
            strB.AppendFormat("<div class=\"photosTxt\"><a href=\"/user/default.aspx?u={0}\"><span class=\"Name\">{1}</span></a> 创建</div>", dt1.Rows[i]["userid"].ToString(), dt1.Rows[i]["realname"].ToString());
            strB.AppendFormat("<div class=\"photosTxt\" style=\"text-overflow:ellipsis; white-space:nowrap; overflow:hidden; \"><a href=\"/wordlist.aspx?w={0}\"><h3>{1}</h3></a></div>", dt1.Rows[i]["wl_id"].ToString(), dt1.Rows[i]["name"].ToString());
            strB.AppendFormat("<div class=\"photosTxt\"><img src=\"images/index/index_25.gif\" /></div></div>");

            var rela = (from n in dt2.AsEnumerable() where n.Field<int>("wl_id") == int.Parse(dt1.Rows[i]["wl_id"].ToString()) select n);
            if (rela.Count() > 0)
            {
                DataTable dt = rela.CopyToDataTable();
                string wdlist = "";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    wdlist += "<a href=\"/word.aspx?c=" + dt.Rows[j]["w_id"].ToString() + "\">" + dt.Rows[j]["name"].ToString() + "</a>  | ";
                    if (j > 6) break;
                }
                strB.AppendFormat("<div class=\"SeparateWords\" style=\"white-space:normal; \">{0}</div>", wdlist.Substring(0, wdlist.Length - 2));
            }
            strB.Append("</div></li>");
        }
        this.lit_Content.Text = strB.ToString();
    }
    #endregion
}

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
public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Show_WordComm();
            Show_Users_News();
            Show_Word_CollectionMost();
            Show_Word_CMost();
            try
            {
                Show_WWl_Remark_Index();
            }
            catch
            {
                // 忽略错误，继续加载其他模块
            }
            Show_wordlist_first_Index();
            Show_NCNC_Index();
        }
    }

    #region 首页最新词，词单，==
    private void Show_NCNC_Index()
    {
        DataTable dt = words.Show_NCNC_Index();
        if (dt.Rows.Count > 0)
        {
            this.lit_num.Text = dt.Rows[0]["wordnum"].ToString();
            this.lit_word.Text = "<a href=\"/word.aspx?c="+dt.Rows[0]["w_id"].ToString()+"\">" + dt.Rows[0]["words"].ToString() + "</a>";
            this.lit_realname.Text = "<a href=\"/user/default.aspx?u=" + dt.Rows[0]["userid"].ToString() + "\">" + dt.Rows[0]["realname"].ToString() + "</a>";
            this.lit_cwordlist.Text = "<a href=\"/wordlist.aspx?w=" + dt.Rows[0]["wl_id"].ToString() + "\">" + dt.Rows[0]["wordlist"].ToString() + "</a>";
        }
    }
    #endregion

    #region 最新注册用户
    private void Show_Users_News()
    {
        DataTable dt = Users.Show_Users_News();
        string regUsers = "";
        for(int i=0;i<dt.Rows.Count;i++)
        {
            regUsers += "<span class=\"NewsUsers\"><a href=\"/user/default.aspx?u=" + dt.Rows[i]["userid"].ToString() + "\" title=\"" + dt.Rows[i]["realname"].ToString() + "\"><img border=\"0\" width=\"54\" height=\"54\" src=\"" + dt.Rows[i]["avater"].ToString() + "\" /></a><div class=\"Name Character\"><a href=\"/user/default.aspx?u=" + dt.Rows[i]["userid"].ToString() + "\">" + dt.Rows[i]["realname"].ToString() + "</a></div></span>";
        }
        this.lit_RegUsers.Text = regUsers;
    }
    #endregion

    #region 被收藏最多的词
    private void Show_Word_CollectionMost()
    {
        DataTable dt = words.Show_Word_CollectionMost();
        this.rep_CollMost.DataSource = dt;
        this.rep_CollMost.DataBind();
    }
    #endregion

    #region 7天内被引用最多的词
    private void Show_Word_CMost()
    {
        DataTable dt = words.Show_Word_CMost(7);
        string wds = "",size = "1";
        string[] color = new string[] { "#0084ff", "#369eff", "#6cb8ff", "#a1d2ff" };
        Random rand = new Random();
        for (int i = 0; i < dt.Rows.Count; i++)
        {   
            size = rand.Next(2, 6).ToString();
            int col = rand.Next(0,4);
            wds += "<a href=\"/word.aspx?c=" + dt.Rows[i]["w_id"].ToString() + "\"><font color=\"#0084ff\" size=\"" + size + "\">" + dt.Rows[i]["name"].ToString() + "</font></a>" + "&nbsp;&nbsp;&nbsp;";            
        }
        lit_words.Text = wds;
        if(string.IsNullOrEmpty(wds)) lit_words.Text = Data_Public.RandomSalutationS();
        
        if (dt.Rows.Count >= 30)
            hplnk_more7.Visible = true;        
    }
    #endregion

    #region 他们说。。。
    private void Show_WWl_Remark_Index()
    {
        try
        {
            DataTable dt = words.Show_WWl_Remark_Index(5);
            rep_remark_say.DataSource = dt;
            rep_remark_say.DataBind();
        }
        catch (Exception ex)
        {
            // 如果数据库查询失败，不影响首页加载
            rep_remark_say.DataSource = null;
            rep_remark_say.DataBind();

            // 可以记录日志
            System.Diagnostics.Debug.WriteLine("Show_WWl_Remark_Index error: " + ex.Message);
        }
    }
    protected void rep_remark_say_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dv = (DataRowView)e.Item.DataItem;
        Literal lit_content = (Literal)e.Item.FindControl("lit_content");
        Literal lit_rem = (Literal)e.Item.FindControl("lit_rem");
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string cont = dv["content"].ToString();
            if (dv["r_type"].ToString() == "-1") //词单评论
                lit_rem.Text = "评论["+dv["tname"].ToString()+"] <span class=\"Word\"><a href=\"/wordlist.aspx?w="+dv["cid"].ToString()+"\">" + dv["name"].ToString() + "</a></span>";
            else if (dv["r_type"].ToString() == "1")//造句词
            {
                lit_rem.Text = "对[" + dv["tname"].ToString() + "] <span class=\"Word\"><a href=\"/word.aspx?c=" + dv["cid"].ToString() + "\">" + dv["name"].ToString() + "</a></span> 造句";
                cont = dv["content"].ToString().Replace("@" + dv["name"].ToString() + "@", "<font color=\"#ff17a3\">" + dv["name"].ToString() + "</font>");
            }
            else
                lit_rem.Text = "评论[" + dv["tname"].ToString() + "] <span class=\"Word\"><a href=\"/word.aspx?c=" + dv["cid"].ToString() + "\">" + dv["name"].ToString() + "</a></span>";

            lit_content.Text = cont;
        }
    }
    #endregion

    #region 优先词单
    private void Show_wordlist_first_Index()
    {
        StringBuilder strB = new StringBuilder();
        DataSet ds = words.Show_wordlist_first_Index();
        DataTable dt1 = ds.Tables[0];
        DataTable dt2 = ds.Tables[1];
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            strB.AppendFormat("<div class=\"WordTxt\"><div class=\"WordTxt1\"><div class=\"Autographedphotos\"><a href=\"/user/default.aspx?u={0}\"><img src=\"{1}\"/></a></div>",dt1.Rows[i]["userid"].ToString(), dt1.Rows[i]["avater"].ToString());
            strB.AppendFormat("<div class=\"photosTxt\"><span class=\"Name\"><a href=\"/user/default.aspx?u={0}\">{1}</a></span> 创建</div>", dt1.Rows[i]["userid"].ToString(), dt1.Rows[i]["realname"].ToString());
            strB.AppendFormat("<div class=\"photosTxt Character1\"><a href=\"/wordlist.aspx?w={0}\"><h3>{1}</h3></a></div>", dt1.Rows[i]["wl_id"].ToString(), dt1.Rows[i]["name"].ToString());
            strB.AppendFormat("<div class=\"photosTxt\"><img src=\"images/index/index_25.gif\" /></div></div>");

            var rela = (from n in dt2.AsEnumerable() where n.Field<int>("wl_id") == int.Parse(dt1.Rows[i]["wl_id"].ToString()) select n);            
            if (rela.Count() > 0)
            {
                DataTable dt = rela.CopyToDataTable();
                string wdlist = "";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    wdlist += "<a href=\"/word.aspx?c="+dt.Rows[j]["w_id"].ToString()+"\">" + dt.Rows[j]["name"].ToString() + "</a>  | ";
                    if (j > 5) break;
                }                
                strB.AppendFormat("<div class=\"SeparateWords Word\">{0}</div>", wdlist.Substring(0,wdlist.Length-2));
            }            
            strB.Append("</div>");
        }
        this.lit_Content.Text = strB.ToString();
    }
    #endregion

    #region 首页图片滚动
    private void Show_WordComm()
    {
        DataTable dt = words.Show_WordComm(20);
        this.rep_comm.DataSource = dt;
        this.rep_comm.DataBind();
    }
    #endregion
}

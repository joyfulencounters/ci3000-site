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
public partial class admin_sys_commIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            adm_wordcomm_Page(1,"");
        }
    }
    private void adm_wordcomm_Page(int pageIndex,string name)
    {
        this.hideName.Value = name;
        int pageSize = 30;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = admin.Show_adm_wordcomm_Page(pageIndex, pageSize, name, out rowCount, out pageCount);
        this.rep_comment.DataSource = dt;
        this.rep_comment.DataBind();

        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
    }
    public string Commend(object obj)
    {
        if (string.IsNullOrEmpty(obj.ToString()))
        {
            return "<font color=\"blue\">未推荐</font>";
        }
        else if (!Boolean.Parse(obj.ToString()))
        {
            return "<font color=\"blue\">未推荐</font>";
        }
        else
        {
            return "<font color=\"red\">已推荐</font>";
        }
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        adm_wordcomm_Page(e.NewPageIndex, hideName.Value);
    }
    protected void rep_comment_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "edit")
        {
            int wid = int.Parse(e.CommandArgument.ToString().Split('|')[0].ToString());
            bool bol = false;
            bool.TryParse(e.CommandArgument.ToString().Split('|')[1].ToString(),out bol);
            int state = bol ? 0 : 1;
            admin.WordsCommend_State(wid, state);
        }
        Response.Redirect("commIndex.aspx");
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        adm_wordcomm_Page(1, this.txtbox_name.Text);
    }
}

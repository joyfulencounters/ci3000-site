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
public partial class admin_wordlist_remark : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["AdminName"] == null) { Response.Redirect("/admin/login.aspx"); return; }
            RemarkList(1, "");
        }
    }

    #region 评论绑定
    private void RemarkList(int pageIndex, string content)
    {
        int pageSize = 20;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = admin.Show_adm_WordList_Remark_Page(pageIndex, pageSize, content, out rowCount, out pageCount);
        this.rep_RemarkWl.DataSource = dt;
        this.rep_RemarkWl.DataBind();

        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        RemarkList(e.NewPageIndex, this.txtbox_name.Text);
    }
    
    protected void rep_RemarkWl_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "wldel")
        {
            words.WordListRemark_Delete(int.Parse(e.CommandArgument.ToString()));
        }
        Server.Transfer("remark.aspx");
    }
    #endregion

    //检索
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        RemarkList(1, this.txtbox_name.Text);
    }
}

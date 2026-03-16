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
public partial class admin_word_remark : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["AdminName"] == null) { Response.Redirect("/admin/login.aspx"); return; }
            RemarkList(1, "");
        }
    }

    #region 词评论
    private void RemarkList(int pageIndex, string cont)
    {
        int pageSize = 20;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = admin.Show_adm_Word_Remark_Page(pageIndex, pageSize, cont, out rowCount, out pageCount);
        this.rep_word_remark.DataSource = dt;
        this.rep_word_remark.DataBind();
        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
    }
    protected void rep_word_remark_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dv = (DataRowView)e.Item.DataItem;
        Literal lit_content = (Literal)e.Item.FindControl("lit_content");
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            lit_content.Text = dv["content"].ToString().Replace("@" + dv["name"].ToString() + "@", "<font color=\"red\">" + dv["name"].ToString() + "</font>");
        }
    }
    protected void rep_word_remark_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "wdel")
        {
            words.WordRemark_Delete(int.Parse(e.CommandArgument.ToString()));
        }
        Server.Transfer("remark.aspx");
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        RemarkList(e.NewPageIndex, this.txtbox_name.Text.Trim());
    }
    #endregion

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        RemarkList(1, this.txtbox_name.Text);
    }
}

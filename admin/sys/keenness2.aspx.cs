using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQywy;
using System.Data;
public partial class admin_sys_keenness2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            adm_keenness2_Page(1);
        }
    }
    private void adm_keenness2_Page(int pageIndex)
    {
        int pageSize = 20;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = admin.Show_adm_keenness2_Page(pageIndex, pageSize, out rowCount, out pageCount);
        this.rep_solutate.DataSource = dt;
        this.rep_solutate.DataBind();

        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        adm_keenness2_Page(e.NewPageIndex);
    }
    protected void rep_solutate_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "gdel")
        {
            admin.Adm_keenness2_Del(int.Parse(e.CommandArgument.ToString()));
        }
        Server.Transfer("keenness2.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string cont = this.txtName.Text.Trim();
        admin.Adm_keeness2_Add(cont);
        Server.Transfer("keenness2.aspx");
    }
}
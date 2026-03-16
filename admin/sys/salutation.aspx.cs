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
public partial class admin_sys_salutation : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            adm_solutate_Page(1);
        }
    }
    private void adm_solutate_Page(int pageIndex)
    {
        int pageSize = 20;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = admin.Show_adm_salutate_Page(pageIndex, pageSize, out rowCount, out pageCount);
        this.rep_solutate.DataSource = dt;
        this.rep_solutate.DataBind();

        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
    }
    public string Comment(object num)
    {
        if (int.Parse(num.ToString()) == 1)            
            return "<font color='red'>‘对不起’</font>方言";
        else
            return "<font color='blue'>‘打招呼’</font>方言";
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        adm_solutate_Page(e.NewPageIndex);
    }
    protected void rep_solutate_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "gdel")
        {
            admin.Adm_salutate_Del(int.Parse(e.CommandArgument.ToString()));
        }
        Server.Transfer("salutation.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string title = this.txtName.Text.Trim();
        string cont = this.txtCont.Text.Trim();
        admin.Adm_salutate_Add(title, cont, int.Parse(this.ddlstate.SelectedValue));
        Server.Transfer("salutation.aspx");
    }
}

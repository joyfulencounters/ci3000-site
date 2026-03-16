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
public partial class admin_user_list : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["AdminName"] == null) { Response.Redirect("/admin/login.aspx"); return; }
            adm_user_Page(1, this.hideOrder.Value);
        }
    }
    private void adm_user_Page(int pageIndex,string orderby)
    {
        int pageSize = 20;
        int rowCount = 0;
        int pageCount = 0;
        this.hideOrder.Value = orderby;
        DataTable dt = admin.Show_adm_users_Page(pageIndex, pageSize,orderby, out rowCount, out pageCount);
        this.rep_user.DataSource = dt;
        this.rep_user.DataBind();

        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
    }
    public string CompareToTime(object time)
    {   
        if (DateTime.Now.Year == Convert.ToDateTime(time).Year && DateTime.Now.Month == Convert.ToDateTime(time).Month)
            return "<font color='red'>" + time + "</font>";
        else
            return time.ToString();        
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        adm_user_Page(e.NewPageIndex, this.hideOrder.Value);
    }
    protected void lnkbtn_createtime_Click(object sender, EventArgs e)
    {
        this.hideOrder.Value = "createDate desc";
        adm_user_Page(1, this.hideOrder.Value);
    }
    protected void lnkbtn_logintimes_Click(object sender, EventArgs e)
    {
        this.hideOrder.Value = "logintimes desc";
        adm_user_Page(1, this.hideOrder.Value);
    }
    protected void rep_user_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "udel")
        {
            Users.UserDel(int.Parse(e.CommandArgument.ToString()));
        }
        Server.Transfer("list.aspx");
    }
}

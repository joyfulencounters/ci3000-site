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
public partial class admin_word_tag : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Show_adm_Word_Tag_Page(1, "addtime desc");
        }
    }
    private void Show_adm_Word_Tag_Page(int pageIndex, string orderby)
    {
        int pageSize = 40;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = admin.Show_adm_Word_Tag_Page(pageIndex, pageSize, orderby, out rowCount, out pageCount);
        this.rep_tag.DataSource = dt;
        this.rep_tag.DataBind();

        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Show_adm_Word_Tag_Page(e.NewPageIndex, "addtime desc");
    }
    protected void rep_tag_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "tdel")
        {   
            int num = words.Words_Tag_Delete(int.Parse(e.CommandArgument.ToString()));
        }
        Server.Transfer("tag.aspx");
    }
}

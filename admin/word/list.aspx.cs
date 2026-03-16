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
public partial class admin_word_list : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            adm_word_Page(1,"addtime desc");
        }
    }
    private void adm_word_Page(int pageIndex,string orderby)
    {
        int pageSize = 40;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = admin.Show_adm_word_Page(pageIndex, pageSize, orderby, out rowCount, out pageCount);
        this.rep_list.DataSource = dt;
        this.rep_list.DataBind();

        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        adm_word_Page(e.NewPageIndex,"addtime desc");
    }
    protected void rep_list_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dv = (DataRowView)e.Item.DataItem;
        //DropDownList ddpComment = (DropDownList)e.Item.FindControl("ddpComment");
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        { 
        }
    }
    protected void rep_list_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "wdel")
        {
            int wid = int.Parse(e.CommandArgument.ToString());
            words.Word_Delete(wid);
        }
        Server.Transfer("list.aspx");
    }
    protected void lnkbtn_addtime_Click(object sender, EventArgs e)
    {
        adm_word_Page(1, "addtime desc");
    }
    protected void lnkbtn_remark_Click(object sender, EventArgs e)
    {
        adm_word_Page(1, "r_amount desc");
    }
}

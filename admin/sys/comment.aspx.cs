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
public partial class admin_sys_comment :BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AdminName"] == null) { Response.Redirect("/admin/login.aspx"); return; }
            adm_wordlist_Page(1);
        }
    }
    private void adm_wordlist_Page(int pageIndex)
    {
        int pageSize = 20;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = admin.Show_adm_wordlist_Page(pageIndex, pageSize, "", "", out rowCount, out pageCount);
        this.rep_comment.DataSource = dt;
        this.rep_comment.DataBind();

        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
    }
    public string Comment(object num)
    {
        if (int.Parse(num.ToString()) == 3) //词单推荐无限推荐
            return "<b style='color:Gray;'>我的推荐</b>";
        else if (int.Parse(num.ToString()) == 2) //今日推荐 1个
            return "<b style='color:red;'>今日推荐</b>";
        else if (int.Parse(num.ToString()) == 1) //优先词单首页 3个
            return "<b style='color:blue;'>优选词单</b>";
        else
            return "默认";
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        adm_wordlist_Page(e.NewPageIndex);
    }
    protected void ddpComment_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddpComment = (DropDownList)sender;
        int state = int.Parse(ddpComment.SelectedValue);
        int index = ((RepeaterItem)ddpComment.NamingContainer).ItemIndex; //当前ddp索引位置
        int wlid = int.Parse(((Literal)rep_comment.Items[index].FindControl("lit_wlid")).Text); //当前行某值
        admin.WordListComment_Edit(wlid, state);
        Server.Transfer("comment.aspx");
    }
    protected void rep_comment_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dv = (DataRowView)e.Item.DataItem;
        DropDownList ddpComment = (DropDownList)e.Item.FindControl("ddpComment");
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ddpComment.SelectedValue = dv["wl_state"].ToString();
        }
    }
}

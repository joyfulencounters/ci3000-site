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
public partial class morewords : BasePage
{
    private int wid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        wid = Data_Public.getQueryStringToInt("c");
        if(!IsPostBack)
        {
            DataTable dt = words.Show_Info_Word_One(wid);
            if(dt.Rows.Count > 0)
                lit_name.Text = dt.Rows[0]["name"].ToString();

            Show_Words_likeTag_Page(1, wid);
        }
    }
    private void Show_Words_likeTag_Page(int pageIndex, int wid)
    {
        int pageSize = 70;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = words.Show_Words_likeTag_Page(pageIndex, pageSize, wid, out rowCount, out pageCount);
        this.rep_taglike.DataSource = dt;
        this.rep_taglike.DataBind();
        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
        if (dt.Rows.Count <= 0)
            lit_nullMsg.Text = Data_Public.RandomSalutationS();
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Show_Words_likeTag_Page(e.NewPageIndex, wid);
    }
}

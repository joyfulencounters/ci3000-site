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

public partial class search_wordlistSear : BasePage
{   
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string name = Data_Public.Encode(Data_Public.getQueryStringToStr("sear"));            
            Search_wordlist_OfWordlist_Page(1,name);
        }
    }

    private void Search_wordlist_OfWordlist_Page(int pageIndex,string name)
    {
        this.headq.Value = name;
        lit_name.Text = name;
        int pageSize = 10;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = search.Search_wordlist_OfWordlist_Page(pageIndex, pageSize, name, out rowCount, out pageCount);
        this.rep_wordlist.DataSource = dt;
        this.rep_wordlist.DataBind();

        this.lit_num.Text = rowCount.ToString();
        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
        if (dt.Rows.Count <= 0) lit_nullMsg.Text = Data_Public.RandomSalutationS();
        else lit_nullMsg.Text = "";
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Search_wordlist_OfWordlist_Page(e.NewPageIndex, this.headq.Value);
    }
    protected void Imgbtn_Search_Click(object sender, ImageClickEventArgs e)
    {
        string name = this.headq.Value.Trim();
        Search_wordlist_OfWordlist_Page(1, name);
    }
}

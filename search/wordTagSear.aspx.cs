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
public partial class search_wordTagSear : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string name = Data_Public.Encode(Data_Public.getQueryStringToStr("sear"));
            Search_word_OfTag_Page(1,name);
        }
    }

    private void Search_word_OfTag_Page(int pageIndex,string name)
    {
        this.lit_name.Text = name;
        int pageSize = 10;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = search.Search_word_OfTag_Page(pageIndex, pageSize, name, out rowCount, out pageCount);
        this.rep_wordlist.DataSource = dt;
        this.rep_wordlist.DataBind();

        this.lit_num.Text = rowCount.ToString();
        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;
        if (dt.Rows.Count <= 0) lit_nullMsg.Text = Data_Public.RandomSalutationS() + "<br/> 暂时没有相关信息";
        else lit_nullMsg.Text = "";
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Search_word_OfTag_Page(e.NewPageIndex,this.lit_name.Text);
    }
    protected void Imgbtn_Search_Click(object sender, ImageClickEventArgs e)
    {
        string name = this.headq.Value.Trim();
        Search_word_OfTag_Page(1, name);
    }
}

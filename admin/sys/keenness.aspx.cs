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
public partial class admin_sys_keenness : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) Show_adm_keenness_Page(1, "");
    }
    public void DataTableToDB(string filename)
    {
        string _strExcelFileName = filename;
        DataTable dtExcel = admin.ExcelToDataTable(_strExcelFileName, "Sheet1");
        for (int i = 0; i < dtExcel.Rows.Count; i++)
        {
            admin.InsertDataToSqlTable(dtExcel.Rows[i][0].ToString());         
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(this.FileUpload1.PostedFile.FileName))
        {
            string filename = Server.MapPath("/file/" + this.FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(filename);
            
            this.lit_load.Text = "<font color='red'>成功导入数据...</font>";
            DataTableToDB(filename);

            Show_adm_keenness_Page(1, "");
        }
        else
        {
            this.lit_load.Text = "导入失败...";
        }
    }
    protected void Show_adm_keenness_Page(int pageIndex,string sear)
    {
        int pageSize = 30;
        int rowCount = 0;
        int pageCount = 0;
        DataTable dt = admin.Show_adm_keenness_Page(pageIndex, pageSize, sear, out rowCount, out pageCount);
        this.rep_keenness.DataSource = dt;
        this.rep_keenness.DataBind();

        this.AspNetPager1.PageSize = pageSize;
        this.AspNetPager1.RecordCount = rowCount;    
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        Show_adm_keenness_Page(e.NewPageIndex,this.txt_sear.Text.Trim());
    }
    protected void rep_keenness_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "gdel")
        {
            admin.Adm_keenness_Del(int.Parse(e.CommandArgument.ToString()));
        }
        Server.Transfer("keenness.aspx");
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        string sear = this.txt_sear.Text.Trim();
        Show_adm_keenness_Page(1, sear);
    }
}

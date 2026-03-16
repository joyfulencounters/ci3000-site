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
public partial class more : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Show_Word_CMost();
        }
    }
    private void Show_Word_CMost()
    {
        DataTable dt = words.Show_Word_CMost(7, 100);
        this.rep_wordmore.DataSource = dt;
        this.rep_wordmore.DataBind();
        if (dt.Rows.Count <= 0)        
            lit_nullMsg.Text = Data_Public.RandomSalutationS();        
    }
}

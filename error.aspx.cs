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
public partial class error : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.hylk_Index.NavigateUrl = Data_Public.GetConfig("MainUrl");
            this.hylk_Rd.NavigateUrl = "/word.aspx?c=" + words.Show_WordID_Random();
            this.hylk_Look.NavigateUrl = "/lovers.aspx";
        }
    }
}

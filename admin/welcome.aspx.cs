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
public partial class admin_welcome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)        
            regBinder();        
    }
    private void regBinder()
    {
        DataTable dt = admin.Show_adm_users_regCount();
        this.lit_allreg.Text = dt.Rows[0]["allreg"].ToString();
        this.lit_monthreg.Text = dt.Rows[0]["monthreg"].ToString();
    }
}

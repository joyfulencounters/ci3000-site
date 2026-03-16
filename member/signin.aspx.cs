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
public partial class member_signin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void imgbtn_submit_Click(object sender, ImageClickEventArgs e)
    {
        string email = this.txt_email.Text;
        string pwd = this.txt_pwd.Text;
        if (!Users.CheckLogin(email, pwd))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "error", "<script>document.getElementById('WrongMsg').style.display='block';</script>");
        }
        else
        {
            string sReturnPage = Data_Public.getQueryStringToStr("returnpage");
            if (string.IsNullOrEmpty(sReturnPage))
            {
                sReturnPage = "/";//个人中心
            }
            Response.Redirect(sReturnPage);
        }
    }
}

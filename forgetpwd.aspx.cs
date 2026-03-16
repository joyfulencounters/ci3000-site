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
public partial class forgetpwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {   
            string email = Data_Public.getQueryStringToStr("mail");
            string rand = Data_Public.getQueryStringToStr("rand");
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(rand))
            {
                Data_Public.AlertToLocation(this.Page, "当前参数有误", "/");
                return;
            }
            else
            {
                if (!Users.ForgetPwd(email))
                {
                    Data_Public.AlertToLocation(this.Page, "该mail不存在", "/");
                    return;
                }
            }
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        string txtpwd1 = this.txtpwd1.Text.Trim();
        string txtpwd2 = this.txtpwd2.Text.Trim();        
        if (txtpwd1 != txtpwd2) return;
        string email = Data_Public.getQueryStringToStr("mail");
        Users.GetPwd(email, txtpwd1);
        Response.Redirect(Data_Public.GetConfig("LoginUrl"));
    }
}

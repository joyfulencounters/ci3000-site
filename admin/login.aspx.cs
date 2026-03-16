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
public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminName"] != null) Response.Redirect("manage.aspx");
    }
    public string UserLogin(string userName, string passWord)
    {
        bool flag = true;        
        if (userName.Trim() == string.Empty || passWord.Trim() == string.Empty) flag = false;
        
        if (flag)
        {

            if (!Users.CheckLoginBack(userName, txtPassword.Text))
            {
                Response.Write("<script>alert('用户名或者密码错误！');location.href='login.aspx'</script>");
                return null;
            }
            else
            {
                return userName;
            }
        }
        else
        {
            return null;
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string username = this.txtUserName.Text.Trim();
        string pwd = this.txtPassword.Text.Trim();       
        string admin = UserLogin(username, pwd);
        if (admin != null)
        {
            Session["AdminName"] = admin;
            Response.Redirect("manage.aspx");
            return;
        }
        else
        {
            Response.Write("<script>alert('用户名或者密码错误！');location.href='login.aspx'</script>");
        }
    }
}

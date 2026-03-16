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

public partial class member_loginOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Users.Clear();    //清空user的cookie
        this.Session.Clear();   //清空user的session
        Response.Redirect(Data_Public.GetConfig("MainUrl"));
    }
}

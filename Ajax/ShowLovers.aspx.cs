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
using System.IO;
using WebQywy;
public partial class Ajax_ShowLovers : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {   
            Response.ContentType = "text/xml";
            Response.Charset = "UTF-8";
            Response.Write(new Qywyxml().Show_SaveLoveOfMy(uc.UserID));
        }
    }
}

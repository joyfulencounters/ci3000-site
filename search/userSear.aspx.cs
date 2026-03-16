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
public partial class search_userSear : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string name = Data_Public.Encode(Data_Public.getQueryStringToStr("sear"));
            Search_User(name);
        }
    }
    private void Search_User(string name)
    {
        DataTable dt = Users.Show_UserInfo(name);
        if (dt.Rows.Count > 0)
        {
            lit_NullMsg.Text = "";
            Response.Redirect("/user/default.aspx?u=" + dt.Rows[0]["userid"].ToString());
        }
        else
        {
            lit_NullMsg.Text = Data_Public.RandomSalutationS();
            lit_name.Text = name;
        }
    }    
}

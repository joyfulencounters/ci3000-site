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
public partial class admin_wordlist_aded : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = Data_Public.getQueryStringToInt("id");
            DataTable dt = words.Show_Info_WordList_One(id);
            if (dt.Rows.Count > 0)
            {
                this.txt_name.Text = dt.Rows[0]["name"].ToString();
                this.txt_cont.Text = dt.Rows[0]["content"].ToString();
                this.hideUid.Value = dt.Rows[0]["adduserid"].ToString();
            }
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        string name = this.txt_name.Text.Trim();
        string cont = this.txt_cont.Text.Trim();
        int uid = int.Parse(this.hideUid.Value);
        int id = Data_Public.getQueryStringToInt("id");
        words.WordList_Edit(name, cont, uid, id);
        string waring = "<script>parent.winrload();</script>";
        ClientScript.RegisterStartupScript(typeof(admin_wordlist_aded), "msg", waring);
    }
}

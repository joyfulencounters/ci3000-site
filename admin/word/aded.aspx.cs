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
public partial class admin_word_aded : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DataTable dtt = words.WordTypeList();
            ddlType.DataSource = dtt;
            ddlType.DataTextField = "name";
            ddlType.DataValueField = "t_id";
            ddlType.DataBind();

            int id = Data_Public.getQueryStringToInt("id");
            DataTable dt = words.Show_Info_Word_One(id);
            if (dt.Rows.Count > 0)
            {
                this.txt_name.Text = dt.Rows[0]["name"].ToString();
                this.txt_cont.Text = dt.Rows[0]["content"].ToString();
                this.ddlType.SelectedValue = dt.Rows[0]["t_id"].ToString();
                this.hideUid.Value = dt.Rows[0]["adduserid"].ToString();
            }            
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        string name = this.txt_name.Text.Trim();
        string cont = this.txt_cont.Text.Trim();
        int type = int.Parse(this.ddlType.SelectedValue);
        int uid = int.Parse(this.hideUid.Value);
        int id = Data_Public.getQueryStringToInt("id");
        string error = "";
        words.Word_Edit(id, name, cont, uid, type, out error);
        string waring = "<script>parent.winrload();</script>";
        ClientScript.RegisterStartupScript(typeof(admin_word_aded), "msg", waring);
        
    }
}

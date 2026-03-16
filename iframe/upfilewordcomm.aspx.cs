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
public partial class iframe_upfilewordcomm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hidefile.Value = Data_Public.getQueryStringToStr("pic");
    }
    protected void btn_OK_Click(object sender, EventArgs e)
    {
        string userpic = hidefile.Value;
        if (!string.IsNullOrEmpty(this.FileUpload1.PostedFile.FileName))
        {
            UploadFile uf = new UploadFile();
            uf.loadFile(this.FileUpload1.PostedFile, "", out userpic, "/images/index/");
            userpic = "/images/index/" + userpic;
            int wid = Data_Public.getQueryStringToInt("wid");
            admin.WordsCommend_Add(wid, userpic);
            Response.Write("<script>parent.picstate(" + wid.ToString() + ",'" + userpic + "',true);</script>");
        }
        else
        {
            Response.Write("<script>parent.picstate(" + Data_Public.getQueryStringToInt("wid").ToString() + ",'" + userpic + "',false);</script>");
        }
    }
}

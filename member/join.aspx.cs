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

public partial class member_join : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            user_img.ImageUrl = Data_Public.RandomUserImg();//随机头像
        }
    }

    protected void imgbtn_submit_Click(object sender, ImageClickEventArgs e)
    {
        string email = this.txt_email.Text.Trim();
        string name = this.txt_name.Text.Trim();
        string pwd = this.txt_pwd1.Text.Trim();
        string userpic = "";
        if (!string.IsNullOrEmpty(this.file_upload.PostedFile.FileName))
        {
            UploadFile uf = new UploadFile();
            uf.loadFile(this.file_upload.PostedFile, "", out userpic);
            userpic = Data_Public.GetConfig("UserPicPath") + userpic;
            userpic = Data_Public.GetConfig("UserPicPath") + uf.MakeSmallPic(Server.MapPath(userpic));
        }
        else
        {
            userpic = Data_Public.RandomUserImg();
        }
        bool bol = Users.reg(email, name, pwd, userpic);
        if (bol)
            Response.Redirect("/");
        else
            Response.Write("<script type=\"text/javascript\" language=\"javascript\">alert('注册失败！');</script>");
    }
}

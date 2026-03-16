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
public partial class user_face : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (uc.UserID <= 0) Response.Redirect("/");
            if (!string.IsNullOrEmpty(Request.QueryString["Picurl"]))
            {
                ImageDrag.ImageUrl = Server.UrlDecode(Request.QueryString["Picurl"].ToString());
                ImageIcon.ImageUrl = Server.UrlDecode(Request.QueryString["Picurl"].ToString());
                Page.ClientScript.RegisterStartupScript(typeof(user_face), "step2", "<script type='text/javascript'>Step2();</script>");
            }
            else
            {   
                this.imgphoto.ImageUrl = uc.Avater;
                Page.ClientScript.RegisterStartupScript(typeof(user_face), "step1", "<script type='text/javascript'>Step1();</script>");
            }
        }
    }
    //切图并生成缩略
    protected void btn_Image_Click(object sender, EventArgs e)
    {
        int imageWidth = Int32.Parse(txt_width.Text);
        int imageHeight = Int32.Parse(txt_height.Text);
        int cutTop = Int32.Parse(txt_top.Text);
        int cutLeft = Int32.Parse(txt_left.Text);
        int dropWidth = Int32.Parse(txt_DropWidth.Text);
        int dropHeight = Int32.Parse(txt_DropHeight.Text);

        string ImgUrl = ImageIcon.ImageUrl;
        if (!string.IsNullOrEmpty(ImgUrl))       
            ImgUrl = ImgUrl.Substring(ImgUrl.LastIndexOf("/") + 1);
        
        string savepath = Data_Public.GetConfig("UserPicPath");
        ImgUrl = savepath + ImgUrl;
        string filename = new UploadFile().SaveCutPic(Server.MapPath(ImgUrl), Server.MapPath(savepath), 0, 0, dropWidth, dropHeight, cutLeft, cutTop, imageWidth, imageHeight);
        // 完成切图并保存到数据库 cookie也修改
        filename = savepath + filename;
        Users.UserInfo_Update(uc.UserID, filename);

        this.imgphoto.ImageUrl = filename;
        Response.Redirect("/user/face.aspx");
    }
    //上传的原始图
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(fuPhoto.PostedFile.FileName) && fuPhoto.PostedFile.ContentLength > 0)
        {
            string imgUrl = "";
            int num = new UploadFile().loadFile(fuPhoto.PostedFile, "", out imgUrl);
            if (num == 1)
            {
                imgUrl = Data_Public.GetConfig("UserPicPath") + imgUrl;
                Response.Redirect("/user/face.aspx?Picurl=" + Server.UrlEncode(imgUrl));
            }
            else
                Data_Public.AlertToLocation(this.Page, "上传失败！","/user/face.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(typeof(user_face), "step1", "<script type='text/javascript'>Step1();</script>");
        }
    }
}

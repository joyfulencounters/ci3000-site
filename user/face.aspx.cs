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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using WebQywy;

using SDImage = System.Drawing.Image;
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
        try
        {
            // 预览图上的尺寸和坐标
            double previewTop = double.Parse(txt_top.Text);
            double previewLeft = double.Parse(txt_left.Text);
            double zoom = double.Parse(txt_Zoom.Text);
            int previewCutSize = Int32.Parse(txt_DropWidth.Text);  // 前端预览框尺寸 92

            // 输出尺寸改为 200x200，更清晰
            int outputSize = 200;

            // 根据缩放比例计算原图上的坐标和尺寸
            int originCutLeft = (int)Math.Round(previewLeft / zoom);
            int originCutTop = (int)Math.Round(previewTop / zoom);
            int originCutSize = (int)Math.Round(previewCutSize / zoom);

            string ImgUrl = ImageIcon.ImageUrl;
            if (!string.IsNullOrEmpty(ImgUrl))       
                ImgUrl = ImgUrl.Substring(ImgUrl.LastIndexOf("/") + 1);
            
            string savepath = Data_Public.GetConfig("UserPicPath");
            string sourcePath = Server.MapPath(savepath + ImgUrl);
            
            // 生成新文件名（缩短长度以适应数据库字段）
            string filename = DateTime.Now.ToString("MMddHHmmss") + new Random().Next(100, 999).ToString() + ".png";
            string destPath = Server.MapPath(savepath + filename);

            // 直接从原图高质量裁切
            using (SDImage originalImg = SDImage.FromFile(sourcePath))
            {
                // 确保裁切区域不超出原图范围
                originCutLeft = Math.Max(0, Math.Min(originCutLeft, originalImg.Width - 1));
                originCutTop = Math.Max(0, Math.Min(originCutTop, originalImg.Height - 1));
                originCutSize = Math.Max(1, Math.Min(originCutSize, Math.Min(originalImg.Width - originCutLeft, originalImg.Height - originCutTop)));
                
                // 创建 200x200 的高质量输出图像
                Bitmap resultImg = new Bitmap(outputSize, outputSize, PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(resultImg))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    
                    // 从原图的指定区域绘制到目标图像
                    Rectangle destRect = new Rectangle(0, 0, outputSize, outputSize);
                    Rectangle srcRect = new Rectangle(originCutLeft, originCutTop, originCutSize, originCutSize);
                    g.DrawImage(originalImg, destRect, srcRect, GraphicsUnit.Pixel);
                }
                
                // 保存为高质量 PNG
                if (File.Exists(destPath))
                {
                    File.SetAttributes(destPath, FileAttributes.Normal);
                    File.Delete(destPath);
                }
                resultImg.Save(destPath, ImageFormat.Png);
                resultImg.Dispose();
            }

            // 更新数据库
            string newUrl = savepath + filename;
            int result = Users.UserInfo_Update(uc.UserID, newUrl);
            
            if (result > 0)
            {
                Response.Redirect("/user/face.aspx");
            }
            else
            {
                Response.Write("<script>alert('更新数据库失败，路径: " + newUrl + "');history.back();</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('保存失败：" + ex.Message.Replace("'", "\\'").Replace("\"", "\\\"") + "');history.back();</script>");
        }
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

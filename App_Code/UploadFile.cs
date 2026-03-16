#region 引用的文件
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;
using System.IO;
#endregion

namespace WebQywy
{
    public class UploadFile
    {
        #region 定义的变量
        public int pWidth = int.Parse(Data_Public.GetConfig("UserPicWidth"));         //缩略图宽度
        public int pHeight = int.Parse(Data_Public.GetConfig("UserPicWidth"));         //缩略图高度
        public int MaxSize = int.Parse(Data_Public.GetConfig("UserPicSize"));      //上传文件的大小（单位kb）
        public string SaveRoute = Data_Public.GetConfig("UserPicPath");//"/Upload/UserPic/";                 //保存的路径
        public string FileSuffixs = "jpg,jpeg,gif,bmp,png";          //允许的上传扩展名
        #endregion

        #region 上传文件
        #region loadFile
        public int loadFile(HttpPostedFile file_control,string oldfileurl,out string newfileurl)
        {           
            string client_url = "";                     //客户端的文件路径   
            string suffix = "";                         //上传文件的扩展名
            newfileurl = "";                            //将新的路径初始化
            string newfilename = "";                    //新的文件名
            client_url = file_control.FileName.Trim();  //PostedFile客户端路径  

            suffix = Path.GetExtension(client_url).ToLower();  //得到后缀名
            if (!CheckSuffix(suffix))                   //检查扩展名是否合法
                return 3;

            newfilename = GetFileName() + suffix;       //为新的文件名赋值

            if (!CreateDirectory(SaveRoute))     //创建新的文件夹
                return 2;
            if (file_control.ContentLength > MaxSize * 1024)    //判断文件大小
                return 4;

            newfileurl = SaveRoute;
            newfileurl = Path.Combine(newfileurl, newfilename);                             //得到上传后的路径及文件名
            string truefileurl = HttpContext.Current.Server.MapPath(newfileurl);   //得到上传后的路径

            file_control.SaveAs(truefileurl);                                //上传文件
            //暂不上传，生成缩略图91*91
            //Image image = System.Drawing.Image.FromStream(file_control.InputStream);
            //MakeSmallPic(image.Width, image.Height, pWidth, pHeight, truefileurl, image);

            if (!File.Exists(HttpContext.Current.Server.MapPath(newfileurl)))                        //判断上传后文件是否存在
                return 5;
            else
            {
                newfileurl = newfileurl.Substring(newfileurl.LastIndexOf('/') + 1);
            }
            if (!string.IsNullOrEmpty(oldfileurl))
            {
                DeleteFile(oldfileurl);
            }
            return 1;
        }
        #endregion

        #region loadFile
        public int loadFile(HttpPostedFile file_control, string oldfileurl, out string newfileurl, string new_SaveRoute)
        {           
            string client_url = "";                     //客户端的文件路径   
            string suffix = "";                         //上传文件的扩展名
            newfileurl = "";                            //将新的路径初始化
            string newfilename = "";                    //新的文件名
            client_url = file_control.FileName.Trim();  //PostedFile客户端路径  
            suffix = Path.GetExtension(client_url).ToLower();  //得到后缀名
            if (!CheckSuffix(suffix))                   //检查扩展名是否合法
                return 3;
            newfilename = GetFileName() + suffix;       //为新的文件名赋值
            if (!CreateDirectory(new_SaveRoute))     //创建新的文件夹
                return 2;
            if (file_control.ContentLength > MaxSize * 1024)    //判断文件大小
                return 4;
            newfileurl = new_SaveRoute;
            newfileurl = Path.Combine(newfileurl, newfilename);                             //得到上传后的路径及文件名
            string truefileurl = HttpContext.Current.Server.MapPath(newfileurl);   //得到上传后的路径

            file_control.SaveAs(truefileurl);                                //上传文件
            //Image image = System.Drawing.Image.FromStream(file_control.InputStream);
            //MakeSmallPic(image.Width, image.Height, pWidth, pHeight, truefileurl, image);

            if (!File.Exists(HttpContext.Current.Server.MapPath(newfileurl)))  //判断上传后文件是否存在
                return 5;
            else
            {
                newfileurl = newfileurl.Substring(newfileurl.LastIndexOf('/') + 1);
            }
            if (!string.IsNullOrEmpty(oldfileurl))
            {
                DeleteFile(oldfileurl);
            }
            return 1;
        }
        #endregion

        #region 图片剪切
        public string SaveCutPic(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY, int imageWidth, int imageHeight)
        {
            using (Image originalImg = Image.FromFile(pPath))
            {
                if (originalImg.Width == imageWidth && originalImg.Height == imageHeight)
                {
                    return SaveCutPic(pPath, pSavedPath, pPartStartPointX, pPartStartPointY, pPartWidth, pPartHeight, pOrigStartPointX, pOrigStartPointY);
                }
                string sFileType = pPath.Substring(pPath.LastIndexOf("."), pPath.Length - pPath.LastIndexOf("."));
                string filename = GetFileName() + sFileType;
                string filePath = pSavedPath + "\\" + filename;                
                Bitmap thumimg = MakeThumbnail(originalImg, imageWidth, imageHeight);
                Bitmap partImg = new Bitmap(pPartWidth, pPartHeight);
                Graphics graphics = Graphics.FromImage(partImg);
                Rectangle destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY), new Size(pPartWidth, pPartHeight));//目标位置
                Rectangle origRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));//原图位置（默认从原图中截取的图片大小等于目标图片的大小）
                ///文字水印  
                Graphics G = Graphics.FromImage(partImg);                
                G.Clear(Color.White);
                // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
                G.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // 指定高质量、低速度呈现。 
                G.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(thumimg, destRect, origRect, GraphicsUnit.Pixel);
                //G.DrawString("Xuanye", f, b, 0, 0);
                G.Dispose();
                //originalImg.Dispose();
                if (File.Exists(filePath))
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    File.Delete(filePath);
                }
                partImg.Save(filePath);
                partImg.Dispose();
                thumimg.Dispose();   
                return filename;
            }
        }

        public Bitmap MakeThumbnail(Image fromImg, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            int ow = fromImg.Width;
            int oh = fromImg.Height;
            //新建一个画板
            Graphics g = Graphics.FromImage(bmp);
            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);
            g.DrawImage(fromImg, new Rectangle(0, 0, width, height),
                new Rectangle(0, 0, ow, oh),
                GraphicsUnit.Pixel);
            return bmp;
        }

        public string SaveCutPic(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY)
        {
            string sFileType = pPath.Substring(pPath.LastIndexOf("."), pPath.Length - pPath.LastIndexOf("."));
            string filename = GetFileName() + sFileType;
            string filePath = pSavedPath + "\\" + filename;            
            using (Image originalImg = Image.FromFile(pPath))
            {
                Bitmap partImg = new Bitmap(pPartWidth, pPartHeight);
                Graphics graphics = Graphics.FromImage(partImg);
                Rectangle destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY), new Size(pPartWidth, pPartHeight));//目标位置
                Rectangle origRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));//原图位置（默认从原图中截取的图片大小等于目标图片的大小）
                ///注释 文字水印  
                Graphics G = Graphics.FromImage(partImg);
                G.Clear(Color.White);
                // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
                G.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // 指定高质量、低速度呈现。 
                G.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(originalImg, destRect, origRect, GraphicsUnit.Pixel);
                //G.DrawString("Xuanye", f, b, 0, 0);
                G.Dispose();
                //originalImg.Dispose();
                if (File.Exists(filePath))
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    File.Delete(filePath);
                }
                partImg.Save(filePath);
                partImg.Dispose();
            }
            return filename;
        }
        #endregion
        #endregion

        #region 生成缩略图
        //生成指定大小的缩略图
        public string MakeSmallPic(string sPath)
        {
            int SWidth = pWidth;
            int SHeight = pHeight;
            int iWidth = 0, iHeight = 0;
            using (Image originalImg = Image.FromFile(sPath))
            {
                int NewWidth = iWidth = originalImg.Width;
                int NewHeight = iHeight = originalImg.Height;
                if ((float)iHeight / (float)SHeight >= (float)iWidth / (float)SWidth)
                {
                    //按高来缩放
                    NewHeight = SHeight;
                    NewWidth = iWidth * SHeight / iHeight;
                }
                else
                {
                    //按宽来缩放
                    NewWidth = SWidth;
                    NewHeight = iHeight * SWidth / iWidth;
                }         
                //保存略缩图
                if (NewWidth > 0 && NewHeight > 0)
                {                    
                    int left = (-(91 - NewWidth)/2);
                    int top = (-(91 - NewHeight)/2);
                    return SaveCutPic(sPath, System.Web.HttpContext.Current.Server.MapPath(Data_Public.GetConfig("UserPicPath")), 0, 0, 91, 91, left, top, NewWidth, NewHeight);
                }
                else
                {
                    return "";
                }
            }
        }

        public void MakeSmallPic(int iWidth, int iHeight, int SWidth, int SHeight,string sPath,Image image)
        {
            Image anewimage;
            int NewWidth = iWidth;
            int NewHeight = iHeight;
            if ((float)iHeight / (float)SHeight >= (float)iWidth / (float)SWidth) {
                //按高来缩放
                NewHeight = SHeight;
                NewWidth = iWidth * SHeight / iHeight;
            }
            else            {
                //按宽来缩放
                NewWidth = SWidth;
                NewHeight = iHeight * SWidth / iWidth;
            }
            //保存略缩图
            if (NewWidth > 0 && NewHeight > 0)
            {
                Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                anewimage = image.GetThumbnailImage(NewWidth, NewHeight, callback, IntPtr.Zero);
                anewimage.Save(sPath);
                anewimage.Dispose();
            }
            else
            {
                return;
            }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }
        #endregion

        #region 文件命名
        /// <summary>
        /// 产生上传后的文件名
        /// </summary>
        /// <returns>新的文件名</returns>
        public string GetFileName()
        {
            return DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + new Random().Next(10000).ToString();
        }
        #endregion

        #region 判断上传文件名是否合法
        /// <summary>
        /// 判断上传文件名是否合法
        /// </summary>
        /// <returns>文件名是否合法</returns>
        public bool CheckSuffix(string suffix)
        {
            string[] suffixs = FileSuffixs.Split(',');
            //编历扩展名列表
            for (int i = 0; i < suffixs.Length; i++)
            {
                if (suffix.ToLower().Equals("." + suffixs[i]))     //判断是否合法
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 创建文件夹
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="sPath">文件夹名称</param>
        /// <returns>成功或者失败</returns>
        public bool CreateDirectory(string sPath)
        {
            string temp_path = HttpContext.Current.Server.MapPath(sPath);
            try
            {
                if (!Directory.Exists(temp_path))//检查文件夹是否存在
                {
                    Directory.CreateDirectory(temp_path);//创建文件夹
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 删除某个文件
        /// <summary>
        /// 删除某个文件
        /// </summary>
        /// <param name="fileurl"></param>
        public void DeleteFile(string fileurl)
        {
            try
            {
                fileurl = HttpContext.Current.Server.MapPath(fileurl);
                if (File.Exists(fileurl))
                    File.Delete(fileurl);
            }
            catch { };
        }
        #endregion

        #region 检查文件是否存在
        /// <summary>
        /// 检查指定文件是否存在
        /// </summary>
        /// <param name="sFileFullName">文件路径及全名</param>
        /// <returns></returns>
        public bool FileExists(string sFileFullName)
        {
            try
            {
                sFileFullName = HttpContext.Current.Server.MapPath(sFileFullName);
                return File.Exists(sFileFullName);
            }
            catch { return false; }

        }
        #endregion

        #region 通过编码返回编码文字描术信息
        /// <summary>
        /// 通过编码返回编码文字描术信息
        /// </summary>
        /// <param name="iErrCode">返回编码</param>
        /// <returns>通过编码返回编码文字描术信息</returns>
        public string returnErrorMessage(int Code)
        {
            string sErrorString = "";
            switch (Code)
            {
                case 1:
                    sErrorString = "上传成功";
                    break;
                case 2:
                    sErrorString = "创建文件夹失败";
                    break;
                case 3:
                    sErrorString = "扩展名不允许上传";
                    break;
                case 4:
                    sErrorString = "文件大小不合法";
                    break;
                case 5:
                    sErrorString = "文件上传不成功";
                    break;
                case 6:
                    sErrorString = "略缩图尺寸设置错误";
                    break;
            }
            return sErrorString.Trim();
        }
        #endregion

        #region 图片文件日志写入
        /// <summary>
        /// 图片文件日志写入
        /// </summary>
        /// <param name="tempPath">文件夹名</param>
        /// <param name="fileName">日志文件名</param>
        /// <param name="fileStr">日志写入内容</param>
        /// <returns>bool</returns>
        public bool WriteFile(string tempPath, string fileName,string fileStr)
        {
            string temp = HttpContext.Current.Server.MapPath(tempPath);
            bool bol = false;
            if (CreateDirectory(tempPath))
            {
                StreamWriter sw = null;
                try
                {
                    sw = File.AppendText(temp + fileName);
                    sw.WriteLine(fileStr);
                    sw.NewLine = " ";
                    bol = true;
                    sw.Close();
                }
                catch (Exception exp)
                {
                    bol = false;
                    sw.Close();
                }
                return bol;
            }
            else
                return false;
        }
        #endregion
    }
}

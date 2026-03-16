using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
namespace WebQywy
{
    public class Data_Public
    {
        #region 获取图片地址
        /// <summary>
        /// 获取图片地址
        /// </summary>
        /// <param name="imgurl">图片名称</param>
        /// <returns>string</returns>
        public static string ShowImgUrl(string imgurl)
        {
            return CheckImage(imgurl);
        }

        /// <summary>
        /// 检查图片是否存在，不存在则返回默认图片路径
        /// </summary>
        /// <param name="imgurl">图片路径</param>
        /// <returns>string图片路径</returns>
        public static string CheckImage(string imgurl)
        {
            UploadFile uf = new UploadFile();
            if (uf.FileExists(imgurl))
            {
                uf = null;
                return imgurl;
            }
            else
            {
                uf = null;
                return "/images/icon_dai.jpg";
            }
        }

        #endregion
        
        #region 获取webconfig 节点信息
        public static string GetConfig(string node)
        {
            return ConfigurationManager.AppSettings[node];
        }
        #endregion

        #region 随机方言
        /// <summary>
        /// 随机打招呼
        /// </summary>
        /// <returns></returns>
        public static string RandomSalutation()
        {
            DataSet ds = WebQywyBusiness.DataBusiness.RunReturnDataSet(CommandType.Text, "select top 1 * from aml_salutation where state = 0 order by newid()");            
            if (ds.Tables[0].Rows.Count > 0)
                return "<b><h4>" + ds.Tables[0].Rows[0]["title"].ToString() + "</h4></b>" + ds.Tables[0].Rows[0]["content"].ToString();
            else
                return "<b><h3>对不起！</h3></b>没有任何信息！";
        }
        /// <summary>
        /// 随机对不起
        /// </summary>
        /// <returns></returns>
        public static string RandomSalutationS()
        {
            DataSet ds = WebQywyBusiness.DataBusiness.RunReturnDataSet(CommandType.Text, "select top 1 * from aml_salutation where state = 1 order by newid()");
            if (ds.Tables[0].Rows.Count > 0)
                return "<b><h4>" + ds.Tables[0].Rows[0]["title"].ToString() + "</h4></b>" + ds.Tables[0].Rows[0]["content"].ToString();
            else
                return "<b><h3>对不起！</h3></b>没有任何信息！";
        }
        #endregion

        #region 随机头像
        public static string RandomUserImg()
        {
            Random r = new Random();
            int i = r.Next(1, 12);
            return "/images/avatar/00" + i + ".jpg";
        }
        #endregion

        #region 获取Form
        /// <summary>
        /// 获取Form并输出整形
        /// </summary>
        /// <param name="QueryName"></param>
        /// <returns></returns>
        public static int getFormStringToInt(string QueryName)
        {
            int i = 0;
            try
            {
                i = (HttpContext.Current.Request.Form[QueryName] != null) ? Convert.ToInt32(HttpContext.Current.Request.Form[QueryName]) : 0;
            }
            catch
            {
                i = 0;
            }
            return i;
        }
        /// <summary>
        /// 获取Form并输出字符串
        /// </summary>
        /// <param name="QueryName"></param>
        public static string getFormStringToStr(string QueryName)
        {
            string str = "";
            try
            {
                str = (HttpContext.Current.Request.Form[QueryName] != null) ? HttpContext.Current.Server.UrlDecode(Convert.ToString(HttpContext.Current.Request.Form[QueryName])) : "";
            }
            catch
            {
                str = "";
            }
            return str;
        }
        #endregion

        #region 获取QueryString
        /// <summary>
        /// 获取QueryString并输出整型
        /// </summary>
        /// <param name="QueryName"></param>
        public static int getQueryStringToInt(string QueryName)
        {
            int i = 0;
            try
            {
                i = (HttpContext.Current.Request.QueryString[QueryName] != null) ? Convert.ToInt32(HttpContext.Current.Request.QueryString[QueryName]) : 0;
            }
            catch
            {
                i = 0;
            }
            return i;
        }

        /// <summary>
        /// 获取QueryString并输出字符串
        /// </summary>
        /// <param name="QueryName"></param>
        public static string getQueryStringToStr(string QueryName)
        {
            string str = "";
            try
            {
                str = (HttpContext.Current.Request.QueryString[QueryName] != null) ? HttpContext.Current.Server.UrlDecode(Convert.ToString(HttpContext.Current.Request.QueryString[QueryName])) : "";
            }
            catch
            {
                str = "";
            }
            return str;
        }
        #endregion

        #region 获取 title
        public static string GetTitleAppend()
        {
            return GetConfig("TitleAppend");
        }
        #endregion

        #region 获取 meta
        public static string GetMetaAppend()
        {
            string MetaList = GetConfig("MetaAppend");
            string[] configMate = { };

            if (!string.IsNullOrEmpty(MetaList)) configMate = MetaList.Split(new char[] { '$' });
            else { return ""; }

            MetaList = "";
            foreach (string str in configMate)
            {
                if (str.IndexOf("|") > 0) MetaList += "<meta name=\"" + str.Substring(0, str.IndexOf("|")) + "\" content=\"" + str.Substring(str.IndexOf("|") + 1, str.Length - str.IndexOf("|") - 1) + "\" />";
            }
            return MetaList;
        }
        #endregion

        #region script 提示
        public static void Alert(Page page,string message)
        {
            string waring = "<script language=\"javascript\"> alert('" + message + "')</script>";
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", waring);
        }

        public static void AlertToLocation(Page page, string message, string redirectUrl)
        {   
            string waring = "<script language=\"javascript\"> alert('" + message + "'); window.location.href='" + redirectUrl + "'</script>";
            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", waring);
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="message">提示信息</param>
        /// <param name="redirectUrl">跳转页</param>
        /// <param name="back">true 登录后返回，false 不返回</param>
        public static void AlertToLocation(Page page, string message, string redirectUrl,bool back)
        {
            string waring = "";
            if (back)
            {
                redirectUrl += "?returnpage=" + HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Url.ToString());
                waring = "<script language=\"javascript\"> alert('" + message + "'); window.location.href='" + redirectUrl + "'</script>";
            }
            else
            {
                waring = "<script language=\"javascript\"> alert('" + message + "'); window.location.href='" + redirectUrl + "'</script>";
            }

            page.ClientScript.RegisterStartupScript(page.GetType(), "msg", waring);
        }
        #endregion

        #region 清除所有无关html
        /// <summary>
        /// 清除所有无关html
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ClearHtml(string text)
        {
            text = System.Text.RegularExpressions.Regex.Replace(text, @"<[^>]+>", "");
            return text;
        }
        #endregion

        #region 转换特殊字符 编码
        /// <summary>
        /// 转换特殊字符 编码
        /// </summary>
        /// <param name="str">待转换的字符</param>
        /// <returns>字符串</returns>
        public static string Encode(string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("'", "''");
            str = str.Replace("\"", "&quot;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\n", "<br>");
            str = str.Replace("\r\n", "<br>");
            return str;            
        }        
        #endregion

        #region 转换特殊字符 解码
        /// <summary>
        /// 转换特殊字符解码，与Encode()方法对应
        /// </summary>
        /// <param name="str">待转换的字符</param>
        /// <returns>字符串</returns>
        public static string Decode(string str)
        {
            str = str.Replace("<br>", "\n");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&quot;", "\"");
            return str;
        }
        #endregion

        #region 清除危险脚本
        /// <summary>
        /// 清除危险脚本
        /// </summary>
        /// <param name="html">代码</param>
        /// <returns></returns>
        public static string wipeScript(string html)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //System.Text.RegularExpressions.Regex regex3 = new System.Text.RegularExpressions.Regex(@" on[\s\S]*=",System.Text.RegularExpressions.RegexOptions.IgnoreCase);   
            System.Text.RegularExpressions.Regex regex4 = new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex5 = new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            System.Text.RegularExpressions.Regex regex6 = new System.Text.RegularExpressions.Regex(@" src *= *[\s\S]*script *:", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            html = regex1.Replace(html, ""); //过滤<script></script>标记
            html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性
            //html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件
            html = regex4.Replace(html, ""); //过滤iframe
            html = regex5.Replace(html, ""); //过滤frameset
            html = regex6.Replace(html, "");
            return html;
        }
        #endregion

        #region 时间处理

        /// <summary>
        /// 如果是当年，生成xx年xx月。否则生成xx年xx月xx日
        /// </summary>
        /// <param name="makeTime">要转换的时间</param>
        /// <returns>转换后的时间</returns>
        public static string DateToString(System.DateTime makeTime)
        {
            if (makeTime.Year == System.DateTime.Now.Year)
            {
                switch (System.DateTime.Now.Day - makeTime.Day)
                {
                    case 0:
                        return makeTime.Hour.ToString() + ":" + (makeTime.Minute > 10 ? makeTime.Minute.ToString() : "0" + makeTime.Minute.ToString());
                    default:
                        return makeTime.Month.ToString() + "月" + makeTime.Day.ToString() + "日";
                }
            }
            else
            {
                return makeTime.Year.ToString() + "年" + makeTime.Month.ToString() + "月" + makeTime.Day.ToString() + "日";
            }
        }
        /// <summary>
        ///小于1小时的，显示：xx分钟前
        ///大于1小时小于24小时的。显示：xx小时前
        ///大于1天小于30天的，显示：xx天前
        ///大于30天小于365天的，显示：xxx个月前
        ///大于365天的，显示：xxx年前
        /// </summary>
        /// <param name="makeTime"></param>
        /// <returns></returns>
        public static string DateToAgoString(System.DateTime makeTime)
        {
            string dateDiff = null;

            TimeSpan ts1 = new TimeSpan(makeTime.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            if (ts.Days > 365)
            {
                dateDiff = ts.Days / 365 + "年前";
            }
            else if (ts.Days >= 30 && ts.Days < 365)
            {
                dateDiff = ts.Days / 30 + "个月前";
            }
            else if (ts.Days >= 1 && ts.Days < 30)
            {
                dateDiff = ts.Days + "天前";
            }
            else if (ts.Hours >= 1 && ts.Hours < 24)
            {
                dateDiff = ts.Hours + "小时前";
            }
            else if (ts.Minutes > 0)
            {
                dateDiff = ts.Minutes + "分钟前";
            }
            else if (ts.Minutes < 1)
            {
                dateDiff = ts.Seconds + "秒前";
            }

            return dateDiff;
        }

        /// <summary>
        ///小于1小时的，显示：xx分钟前
        ///大于1小时小于24小时的。显示：xx小时前
        ///大于1天小于30天的，显示：xx天前
        ///大于30天小于365天的，显示：xxx个月前
        ///大于365天的，显示：xxx年前
        /// </summary>
        /// <param name="makeTime"></param>
        /// <returns></returns>
        public static string DateagoToNow(System.DateTime makeTime)
        {
            string dateDiff = null;

            TimeSpan ts1 = new TimeSpan(makeTime.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime.Now.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            if (ts.Days > 365)
            {
                dateDiff = ts.Days / 365 + "年了";
            }
            else if (ts.Days >= 30 && ts.Days < 365)
            {
                dateDiff = ts.Days / 30 + "个月了";
            }
            else if (ts.Days >= 1 && ts.Days < 30)
            {
                dateDiff = ts.Days + "天了";
            }

            return dateDiff;
        }
        #endregion

        #region 生成随机字符串
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="codeLen">需要的字符串长度</param>
        /// <returns></returns>
        public static string RandString(int len)
        {
            string codeSerial = "1,2,3,4,5,7,8,9,a,c,d,e,f,g,h,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z";

            string[] arr = codeSerial.Split(',');
            string randStr = "";
            int randValue = -1;

            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));//初始化随机数种子

            for (int i = 0; i < len; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);
                randStr += arr[randValue];
            }

            return randStr;
        }
        #endregion

        #region 生成随机自己编写的字符串
        /// <summary>
        /// 生成随机自己编写的字符串
        /// </summary>
        /// <param name="codeLen">需要的字符串长度</param>
        /// <param name="code">要随机的code EG: 1,2,3,4,5,a,b,c,d,e</param>
        /// <returns></returns>
        public static string RandString(int len,string code)
        {
            string codeSerial = code;

            string[] arr = codeSerial.Split(',');
            string randStr = "";
            int randValue = -1;

            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));//初始化随机数种子

            for (int i = 0; i < len; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);
                randStr += arr[randValue];
            }

            return randStr;
        }
        #endregion
    }
}

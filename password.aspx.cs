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
using System.Text;
using System.Net.Mail;
using System.Net;
using WebQywy;
public partial class password : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
    protected void imgbtn_pwd_Click(object sender, ImageClickEventArgs e)
    {
        string mail = this.input_mail.Value.Trim();
        string title = "找回密码 - 千言万语";      
        string rand = Data_Public.RandString(12);
        string body = "请点击以下链接，重新设置您的登陆密码： <br/><br/><br/> <a href=\"http://www.ci3000.com/forgetpwd.aspx?mail=" + Server.UrlEncode(mail) + "&rand=" + rand + "\">http://www.ci3000.com/forgetpwd.aspx?mail=" + Server.UrlEncode(mail) + "&rand=" + rand + "</a>";
        bool bol = Send(mail,title,body);
        if (bol)
        {
            MultiView1.ActiveViewIndex = 1;
            lit_mail.Text = mail;
            Users.ForgetPwd(mail, "忘记密码", rand);
        }
        else
        {
            MultiView1.ActiveViewIndex = 2;
        }        
    }

    public static bool Send(string mailTo, string mailSubject, string mailBody)
    {
        //try
        //{
            //MailMessage MailObj = new MailMessage();
            //MailObj.From = "千言万语网 -  <reborn@ci3000.com>";//设定邮件来源
            //MailObj.To = mailTo;//设定邮件的目的地址
            //MailObj.BodyFormat = MailFormat.Html;//设定邮件格式是文本格式，如果要设定成超文本，把MailFormat.Text改成 MailFormat.Html
            //MailObj.Priority = MailPriority.Normal;//设定邮件优先级，可为 High（高）, Low（低）, Normal（普通）
            //MailObj.Subject = mailSubject;//设定邮件专题
            //MailObj.Body = mailBody;//设定邮件内容
            //MailObj.BodyEncoding = System.Text.Encoding.UTF8;
            ////MailObj.Attachments.Add(new MailAttachment(fileName));//邮件附件
            //MailObj.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            ////用户名 
            //MailObj.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "reborn@ci3000.com"); //no-reply@mayi.com
            ////密码 
            //MailObj.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "19820205");
            //MailObj.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25);
            //MailObj.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "1");
            //SmtpMail.SmtpServer = "mail.ci3000.com";//邮件服务器
            //SmtpMail.Send(MailObj);//现在开始发送邮件
        return SendEmail("千言万语网 -  <reborn@ci3000.com>", "contact@ci3000.com", "cidelwen@hotmail.com", "cidelwen@hotmail.com",
                                "subject", "neirong ", "contact@ci3000.com", "19820205", "mail.ci3000.com", 25, false, "UTF-8");
        //   return true;
        //}
        //catch
        //{
        //    return false;
        //}
    }

    /// <summary>
    /// 同步发送邮件
    /// </summary>
    /// <param name="fromdisplayname">发件人显示的名字</param>
    /// <param name="frommail">发件人的邮箱地址</param>
    /// <param name="todisplayname">关联收件人的名字</param>
    /// <param name="tomail">收件邮箱地址</param>
    /// <param name="smtpserver">smtp服务器(smtp.163.com)</param>
    /// <param name="smtppoint">smtp服务器发送端口号(0为默认25)</param>
    /// <param name="isssl">是否安全套接字层 (SSL) 加密连接</param>
    /// <param name="username">smtp服务器的帐户名称</param>
    /// <param name="password">smtp服务器的帐户密码</param>
    /// <param name="subject">标题</param>
    /// <param name="body">内容</param>
    /// <param name="encoding">邮件编码(GB2312,UTF-8)</param>
    public static bool SendEmail(string fromDisplayName, string fromMailAddress, string toDisplayName, string toMailAddress,
                                 string subject, string body,
                                 string username, string password, string smtpServer,
                                 int smtpPoint, bool isssl, string encoding)
    {

        MailMessage msg = new MailMessage();
        msg.Priority = MailPriority.Normal;

        //设置邮件的编码
        Encoding encod = Encoding.GetEncoding(encoding);
        msg.BodyEncoding = encod;
        msg.SubjectEncoding = encod;

        msg.IsBodyHtml = true;

        msg.From = new MailAddress(fromMailAddress, fromDisplayName);
        msg.To.Add(new MailAddress(toMailAddress, toDisplayName));

        msg.Subject = subject;
        msg.Body = body;

        //端口号
        if (smtpPoint == 0) smtpPoint = 25;

        SmtpClient client = new SmtpClient(smtpServer, smtpPoint);
        client.Credentials = new NetworkCredential(username, password);

        //启用安全套接字层 (SSL) 加密连接
        if (isssl) client.EnableSsl = true;

        try
        {
            client.Send(msg);
            msg.Dispose();
            return true;
        }
        catch (Exception e)
        {
            msg.Dispose();
            throw new Exception(e.ToString());
        }
    }




}

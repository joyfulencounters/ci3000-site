<%@ Page Language="C#" AutoEventWireup="true" CodeFile="log.aspx.cs" Inherits="login_log" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录</title>
</head>
<body>
    <form id="form1" runat="server">
    <table width="325" border="0" align="center" cellpadding="0" cellspacing="0" style="font-size:14px; font-weight:800;">
        <tr>
          <td width="32%" valign="top">&nbsp;</td>
          <td colspan="2" valign="top">&nbsp;</td>
        </tr>
        <tr>
          <td height="30" align="right" valign="middle">登录Email：</td>
          <td height="30" colspan="2" align="left" valign="middle"><asp:TextBox ID="txt_email" onfocus="WrongMsg.style.display='none'" runat="server" MaxLength="50" CssClass="InputBox"></asp:TextBox></td>
      </tr>
        <tr>
          <td height="30" align="right" valign="middle">登录密码：<span id="WrongMsg" style="color:Red; margin-left:20px; display:none;">Email或密码错误！</span></td>
          <td height="30" colspan="2" align="left" valign="middle"><asp:TextBox ID="txt_pwd" TextMode="Password" onfocus="WrongMsg.style.display='none'" runat="server" MaxLength="20" CssClass="InputBox"></asp:TextBox></td>
      </tr>
        <tr>
          <td height="30" colspan="2" style="font-size:12px; font-weight:100;"><a href="/password.aspx" target="_top"></a>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td width="88%" align="right"><a href="/password.aspx" target="_top">忘记密码请点这里!</a></td>
                <td width="12%">&nbsp;</td>
              </tr>
            </table></td>
          <td width="38%" height="30"><asp:ImageButton ID="imgbtn_submit" ImageUrl="../images/member/Login.gif" Width="63" Height="35" runat="server" OnClick="imgbtn_submit_Click" /></td>
        </tr>
      </table>
    </form>
</body>
</html>

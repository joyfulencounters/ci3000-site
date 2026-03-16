<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signin.aspx.cs" Inherits="member_signin" EnableViewState="false" %>

<%@ Register src="../usercontrol/foot.ascx" tagname="foot" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>用户登录-千言万语</title>
<link href="../style/join.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">

  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-16731473-2']);
  _gaq.push(['_setLocalRemoteServerMode']);
  _gaq.push(['_trackPageview']);

  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();

</script>
</head>
<body>
<!--网站头部-->
<div id="MainBox"><a href="/"><img src="../images/index/logo.gif" /></a></div>
<!--登陆区域-->
<div id="MainBox">
    <div class="loginleft">
        <form id="form1" runat="server">
      <div class="loginleft1"> 
          <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td height="45" colspan="2" valign="top"><asp:TextBox ID="txt_email" onfocus="WrongMsg.style.display='none'" runat="server" MaxLength="50" CssClass="InputBox"></asp:TextBox></td>
            </tr>
            <tr>
              <td height="45" colspan="2" valign="top"><asp:TextBox ID="txt_pwd" TextMode="Password" onfocus="WrongMsg.style.display='none'" runat="server" MaxLength="20" CssClass="InputBox"></asp:TextBox><span id="WrongMsg" style="color:Red; margin-left:20px; display:none;">Email或密码错误！</span></td>
            </tr>
            <tr>
              <td width="41%" height="35" class="White"><a href="/password.aspx">忘记密码请点这里!</a></td>
              <td width="59%" height="35"><asp:ImageButton ID="imgbtn_submit" 
                      ImageUrl="../images/member/Login.gif" Width="63" Height="35" runat="server" 
                      onclick="imgbtn_submit_Click" /></td>
            </tr>
          </table>
      </div>
        </form>
  </div>
    <div class="loginright">
        <div class="loginrightButton"><a href="join.aspx"><img src="../images/member/Logintop.gif" /></a></div>
  </div>
</div>
<uc1:foot ID="foot1" runat="server" />    
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="join.aspx.cs" Inherits="member_join" %>

<%@ Register src="../usercontrol/foot.ascx" tagname="foot" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户免费注册-千言万语</title>
    <link href="../style/join.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="/js/public.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript" src="../js/reg.js"></script>
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
<!--登录区域-->
<div id="MainBox" style="height:600px;">
    <div class="LoginButton">
        <div class="LoginButton1"><a href="signin.aspx"><img src="../images/member/LoginButton.gif" /></a></div>
    </div>
    
    <form id="form1" runat="server">
<div class="BgBox" style="margin-top:10px;">
        <div>
        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td height="30" align="right" class="Black">“<span class="Red"> *</span> ”为必填项</td>
            </tr>
            <tr>
              <td height="30"><table width="500" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="118" align="left" valign="middle"><asp:Image ID="user_img" runat="server" ImageUrl="../images/member/member_07.gif" Width="91" Height="91" /></td>
                  <td width="382" align="center" valign="middle" background="../images/member/member_04.gif"><table width="300" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td align="left" class="gray1">随机赠送的签名照，它会显示在您出现的各个地方。<br />
                      如果觉得不够好，请   <img src="../images/member/member_05.gif" width="16" height="16" /><span class="BlueTop"><a href="javascript:void(0);" onclick="return funClick();">上传您自己的签名照&gt;&gt;</a></span><!--如果觉得不够好，注册成功后，请到<span class="BlueTop"><a herf="http://www.ci3000.com/member/signin.aspx">个人设置</a></span>中修改。--></td>
                    </tr>
                  </table>
                      <span id="sp_fileUp" style="display:none;"><asp:FileUpload ID="file_upload" runat="server" onchange="UserPicChange()" /></span>
                    </td>
                </tr>
              </table></td>
            </tr>
            <tr>
              <td height="45" class="gray1"><img src="../images/member/member_06.gif" width="14" height="14" /> 自上传图片需为<span class="Red">JPG,BMP、PNG</span>或<span class="Red">GIF</span>格式，大小不要超过<span class="Red">500K</span>，签名照默认尺寸为<span class="Red">91×91</span>，超过该尺寸将自动裁剪</td>
            </tr>
          </table>
      </div>
        <div style="border-top:#ededed 1px solid; width:95%; margin:auto; margin-top:10px;">
          <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
              <td height="35" colspan="3" class="Black">&nbsp;</td>
            </tr>
            <tr>
              <td width="13%" height="35" class="Black">登录Email：<span class="Red">*</span></td>
              <td width="35%" height="45" align="left"><asp:TextBox ID="txt_email" CssClass="InputTxtBox" onfocus="Chk_Email_Before()" onblur="Chk_Email()" runat="server" MaxLength="50"></asp:TextBox></td>
              <td width="52%" align="left"><span id="sp_email"></span></td>
            </tr>
            <tr>
              <td height="35" class="Black">昵称：<span class="Red">*</span></td>
              <td height="45" align="left"><asp:TextBox ID="txt_name" runat="server" CssClass="InputTxtBox" onfocus="Chk_Name_Before()" onblur="Chk_Name()"  MaxLength="20"></asp:TextBox></td>
              <td height="45" align="left"><span id="sp_name"></span></td>
            </tr>
            <tr>
              <td height="35" class="Black">设置登录密码：<span class="Red">*</span></td>
              <td height="45" align="left"><asp:TextBox ID="txt_pwd1" runat="server" CssClass="InputTxtBox" onfocus="Chk_PwdOne_Before()" onblur="Chk_PwdOne()"  MaxLength="25" TextMode="Password"></asp:TextBox></td>
              <td height="45" align="left"><span id="sp_pwd1"></span></td>
            </tr>
            <tr>
              <td height="35" class="Black">密码确认：<span class="Red">*</span></td>
              <td height="45" align="left"><asp:TextBox ID="txt_pwd2" runat="server" CssClass="InputTxtBox" onfocus="Chk_Pwd_AgainBef()" onblur="Chk_Pwd_Again()"  MaxLength="25" TextMode="Password"></asp:TextBox></td>
              <td height="45" align="left"><span id="sp_pwd2"></span>&nbsp;</td>
            </tr>
            <tr>
              <td height="35">&nbsp;</td>
              <td height="55" colspan="2" valign="middle"><input type="checkbox" name="checkbox" id="checkbox" checked />
              <span class="gray"><a href="http://www.ci3000.com/member/Agreement.html" target="_blank">我接受千言万语用户使用协议</a></span></td>
            </tr>
            <tr>
              <td height="35">&nbsp;</td>
              <td height="65" colspan="2"><asp:ImageButton ID="imgbtn_submit" runat="server" 
                      OnClientClick="return do_validation();" 
                      ImageUrl="../images/member/Registration.gif" Width="216" Height="53" 
                      onclick="imgbtn_submit_Click" /></td>
            </tr>
          </table>
    </div>
  </div>
    </form>
</div>
<!--底部版权-->
    <uc1:foot ID="foot1" runat="server" />    
</body>
</html>

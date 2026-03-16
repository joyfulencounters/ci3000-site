<%@ Page Language="C#" AutoEventWireup="true" CodeFile="error.aspx.cs" Inherits="error" %>
<%@ Register src="usercontrol/foot.ascx" tagname="foot" tagprefix="uc1" %>
<%@ Register src="usercontrol/head.ascx" tagname="head" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>错误页<%= WebQywy.Data_Public.GetTitleAppend()%></title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="MainBox" class="TopBox">
  <div class="logo"><a href="http://www.ci3000.com"><img src="/images/index/logo.gif" border="0" /></a></div>
</div>
    <div id="MainBox">
	    <div><img src="/images/404/404_05.gif" /></div>
	    <div>
		    <div class="Mistake40"><img src="/images/404/404_10.gif" /></div>
		    <div class="Mistake404"><asp:HyperLink ID="hylk_Index" runat="server">回到网站首页</asp:HyperLink>　 |　  <asp:HyperLink ID="hylk_Rd" runat="server">随机取词</asp:HyperLink>　 | 　<asp:HyperLink ID="hylk_Look" runat="server">看看同好</asp:HyperLink></div>
		    <div class="Mistake40"><img src="/images/404/404_13.gif" /></div>
	    </div>
    </div>
    <uc1:foot ID="foot1" runat="server" />    
    </form>
</body>
</html>

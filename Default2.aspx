<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>  
    <script src="/js/jquery-1.3.2.min.js" language="javascript" type="text/javascript"></script>  
    <script language="javascript" type="text/javascript">
        function gexml()
        {
            alert($("rsp > photos").html());
    }
    </script>
</head>
<body>    
<form runat="server">
<table bgcolor="#FFFFFF"><tr><td>
<input name=tn type=hidden value=baidu>
<a href="http://www.baidu.com/"><img src="http://img.baidu.com/img/logo-80px.gif" alt="Baidu" align="bottom" border="0"></a>
<input type=text name=word size=30>
<input type="submit" value="百度搜索">
</td></tr></table>
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
<asp:Button ID="Button1" runat="server" Text="11111" onclick="Button1_Click1" />

<input id="Button2" type="button" value="button" onclick="gexml()" />
</form>
</body>
</html>

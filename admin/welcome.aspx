<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="admin_welcome" %>
<%@ Register src="../usercontrol/top.ascx" tagname="top" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>千言万语管理后台</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc2:top ID="top1" runat="server" />
    <div id="main">
        <div class="box-a">
            <h5>网站基本信息</h5>
            <div class="pd-10">欢迎使用千言万语管理后台</div>
        </div>        
        <div class="box-a">
            <h5>会员统计</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t-form">
                    <colgroup>
                        <col width="100px" /><col />
                    </colgroup>
                    <tr>
                        <th scope="row">本站共有注册会员：</th>
                        <td width="350"><font color="red"><asp:Literal ID="lit_allreg" runat="server">0</asp:Literal></font> 位</td>
                    </tr>
                    <tr>
                        <th scope="row">本月注册会员：</th>
                        <td><font color="red"><asp:Literal ID="lit_monthreg" runat="server">0</asp:Literal></font> 位</td>
                    </tr>                   
                    <tr>
                        <th scope="row">&nbsp;</th>
                        <td></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

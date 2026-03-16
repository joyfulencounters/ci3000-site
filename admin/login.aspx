<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>千言万语管理后台登录</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
</head>
<body class="bg-blue">
    <form id="form1" runat="server">
    <div class="loginBox">
            <h5 class="font-orange">千言万语后台管理</h5>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="mt-10">
                <colgroup>
                    <col width="120px;" />
                    <col />
                </colgroup>
                <tr>
                    <th>
                        用户名：
                    </th>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        密码：
                    </th>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
<%--                <tr>
                    <th>
                        验证码：
                    </th>
                    <td>
                        <asp:TextBox ID="txtCode" runat="server" CssClass="text" Width="50"></asp:TextBox>
                        <img id="visualvalidate" src="/VerifyCode.aspx" alt="验证码" />
                    </td>
                </tr>--%>
                <tr>
                    <th>
                        &nbsp;
                    </th>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="管理员登录" 
                            onclick="btnLogin_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

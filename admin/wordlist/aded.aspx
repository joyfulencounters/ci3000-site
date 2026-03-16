<%@ Page Language="C#" AutoEventWireup="true" CodeFile="aded.aspx.cs" Inherits="admin_wordlist_aded" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>词单页</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <div class="box-a">
            <h5>编辑词单</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="编辑词单" class="t-list mt-10">
                    <tr>
                        <td width="80" height="35">词单名称： </td>
                        <td><asp:TextBox ID="txt_name" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>词单义：</td>
                        <td><asp:TextBox ID="txt_cont" runat="server" TextMode="MultiLine" Height="65px" 
                                Width="170px"></asp:TextBox></td>                        
                    </tr>
                    <tr>
                        <td colspan="2" align="center"><asp:Button ID="btn_submit" runat="server" Text="提交" 
                                onclick="btn_submit_Click" />
                            <asp:HiddenField ID="hideUid" Value="0" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>        
    </div>
    </form>
</body>
</html>

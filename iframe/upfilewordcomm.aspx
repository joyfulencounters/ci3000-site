<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upfilewordcomm.aspx.cs" Inherits="iframe_upfilewordcomm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传首页词照</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>  
        <asp:HiddenField ID="hidefile" Value="" runat="server" />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="btn_OK" runat="server" Text="确定" onclick="btn_OK_Click" />
    </div>
    </form>
</body>
</html>

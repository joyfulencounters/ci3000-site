<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="forgetpwd.aspx.cs" Inherits="forgetpwd" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
找回密码<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
function CheckUserInfo()
{              
    if(!Chk_PwdOne()) return false;
    if(!Chk_Pwd_Again()) return false;
}
function Chk_PwdOne() {
    if ( StringTrim($("#ctl00_ContentPlaceHolder1_txtpwd1").val()).length < 6) {
        alert("密码必须不得小于6位");
        return false;
    }else{return true;}
}
function Chk_Pwd_Again()
{
    var obj = $("#ctl00_ContentPlaceHolder1_txtpwd1").val();    
    if ($("#ctl00_ContentPlaceHolder1_txtpwd2").val() != obj) {
        alert("2次密码不一致");
        return false;
    }else {
        if(!is_empty(obj))
            return true;        
        else             
            return false;        
    }
}
</script>
<form runat="server">
输入新密码：<asp:TextBox ID="txtpwd1" runat="server" TextMode="Password"></asp:TextBox> <span>该密码是您用于登录本网站的密码，不是您的email的密码哦!至少6位</span>
<br />
重新输入：<asp:TextBox ID="txtpwd2" runat="server" TextMode="Password"></asp:TextBox> <span>请再输入一遍上面的密码</span>
<br />
<asp:Button ID="btn_submit" runat="server" Text="确定" onclick="btn_submit_Click" OnClientClick="return CheckUserInfo();" />
</form>
</asp:Content>


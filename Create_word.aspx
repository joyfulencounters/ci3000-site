<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="Create_word.aspx.cs" Inherits="Create_word" Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <asp:Literal ID="lit_titleName" runat="server">创建新</asp:Literal>词单<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
.CreateWord{ background-image:none !important;}
</style>
<form runat="server" id="form1">
<div class="CreateWord">
	<div class="CreateWordA"><img runat="server" id="img_show" src="images/word/word_20.png" alt="" /></div>
	<div>
		<div class="CreateWordB">
			<div class="Black CreateWordC">词单名称：</div>
			<span><input type="text" id="txt_name" runat="server" class="CreateBtten" name="n" value="例如：我喜欢的植物名称" onfocus="if(this.value=='例如：我喜欢的植物名称')this.value='';" /></span>		
		</div>		
		<div class="CreateWordB1">
		<div class="Black CreateWordC">词单描述：</div>
		<span><textarea name="textarea"  id="txt_content" runat="server" class="CreateBtten1" onfocus="if(this.value=='请简单说明这个词单的主题')this.value='';" >请简单说明这个词单的主题</textarea>
		</span>		
		</div>		
		<div class="CreateWordD">
		<table width="100px" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td valign="top"><asp:ImageButton ID="Imgbtn_Submit" ImageUrl="/images/word/word_15.gif" runat="server" onclick="Imgbtn_Submit_Click" /></td>
    <td><asp:Panel ID="Panel1" runat="server" Visible="false"><img alt="" src="/images/word/word_400.gif" onclick="javascript:history.go(-1)" style="cursor:pointer;" /></asp:Panel></td>
  </tr>
</table>
		
		
		
        </div>	
	</div>
</div>
</form>
</asp:Content>


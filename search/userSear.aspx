<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="userSear.aspx.cs" Inherits="search_userSear" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
用户搜索<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server" id="form1">
<div class="CreateWord">
  <div class="NoResults"><img src="/images/word/word_47.png" /></div>
  <div class="NoResults">
	  <ul>
	      <li><asp:Literal ID="lit_NullMsg" runat="server"></asp:Literal></li>
		  <li class="Blue"><asp:Literal ID="lit_name" runat="server"></asp:Literal></li>
		  <li>这个用户尚未注册千言万语。</li><p></p>
		  <li><a href="javascript:window.close()"><img src="/images/word/word_45.gif" border="0" /></a></li>
	  </ul>
  </div>
</div>
</form>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="more.aspx.cs" Inherits="more" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
7天内引用词更多<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server" id="form1">
<div class="CreateWord" style="clear:both; height:1050px;">
	<div style=" height:30px; border-bottom:#eaeaea 1px solid;"><img src="/images/word/word_03.gif" /> 最近7天引用最多的词：</div>	
<div class="WordBoxA Blue" style=" line-height:40px;">
    <asp:Repeater ID="rep_wordmore" runat="server">
        <ItemTemplate>
            <span style=" margin-right:10px;"><a href="/word.aspx?c=<%#Eval("w_id")%>"><%#Eval("name")%></a></span>
        </ItemTemplate>
    </asp:Repeater>	
	<asp:Literal ID="lit_nullMsg" runat="server"></asp:Literal>	</div>   
</div>
</form>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="morewords.aspx.cs" Inherits="morewords" Title="无标题页" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
更多词页<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server" id="form1">
<div class="CreateWord" style="clear:both; height:1050px;">
	<div style=" height:30px; border-bottom:#eaeaea 1px solid; font-size:14px; font-weight:800;"><img src="/images/word/word_03.gif" /> 与 
        <font color="#000000"><asp:Literal ID="lit_name" runat="server"></asp:Literal></font> 风格类似的词有以下这些：</div>	
    <div class="WordBoxA Blue" style=" line-height:40px;"><asp:Repeater ID="rep_taglike" runat="server">
        <ItemTemplate>
            <span style=" margin-left:10px; margin-right:10px;"><a href="/word.aspx?c=<%#Eval("w_id")%>"><%#Eval("name")%></a></span>
        </ItemTemplate>
    </asp:Repeater>	
	<asp:Literal ID="lit_nullMsg" runat="server"></asp:Literal>
    </div>
	<div class="yellow">
        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Size="13px" onpagechanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
    </div>    
</div>
</form>    
</asp:Content>


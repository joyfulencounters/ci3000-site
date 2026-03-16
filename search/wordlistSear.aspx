<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="wordlistSear.aspx.cs" Inherits="search_wordlistSear" Title="无标题页" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
搜索<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server" id="form1">
<div class="SearchBoxWord">
	<div class="SearchBoxWordB"><img src="/images/search/search_03.gif"/></div>
	<div class="SearchBoxWordA">	
		<div class="SearchBoxWordA1">
		<input name="q" type="text" class="SearchBoxWordA2" id="headq" value="请输入您要搜索的词单" runat="server" onfocus="if(this.value=='请输入您要搜索的词单')this.value='';" />
		</div>
		<div class="SearchBoxWordA3" style="margin-top:3px;"><asp:ImageButton ID="Imgbtn_Search" runat="server" TabIndex="0" ImageUrl="/images/search/search_06.png" onclick="Imgbtn_Search_Click" /></div>
		<div class="SearchBoxWordA4 Name" style="CURSOR: hand;"><a href="/search/Default.aspx">返回更多搜索>></a></div>
	</div>
	<div class="SearchBoxWordB"><img src="/images/search/search_06.gif" alt="" /></div>
</div>

<div class="CreateWord" style="clear:both; height:1050px;">
	<div style=" height:30px; border-bottom:#eaeaea 1px solid; margin-bottom:15px;"><div style="margin-top:2px; width:16px; float:left"><img src="/images/word/word_03.gif" /></div><div style="float:left;"> 名称中包含 " 
        <asp:Literal ID="lit_name" runat="server"></asp:Literal>" 的词单<span class="Red"><asp:Literal ID="lit_num"
            runat="server" Text="0"></asp:Literal></span>个，以下是详细信息：</div></div>	
    <asp:Repeater ID="rep_wordlist" runat="server">
        <ItemTemplate>
            <div class="SearchBoxWordF" style="overflow: hidden">
		<div><img src="/images/search/search_10.gif"/><a href="/wordlist.aspx?w=<%#Eval("wl_id") %>"><span class="Green"> <%#Eval("name") %></span></a><span class="Green">　</span><a href="/user/default.aspx?u=<%#Eval("adduserid") %>" ><img width="27" height="26" src="<%#Eval("avater") %>"/></a>　创建人：<a href="/user/default.aspx?u=<%#Eval("adduserid") %>"><span class="Name"><%#Eval("realname") %></span></a> 　　 <img src="/images/index/index_11.gif" /><span class="Gray">发表于<%#Eval("addtime") %></span>
			<div class="Black SearchBoxWordE1"><%#Eval("content") %></div>	
		</div>
	</div>
        </ItemTemplate>
    </asp:Repeater>	
	<asp:Literal ID="lit_nullMsg" runat="server"></asp:Literal>
	<div class="yellow">
        <div class="yellow"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Size="13px" onpagechanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager></div>
    </div>    
</div>
</form>
</asp:Content>
<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="wordSear.aspx.cs" Inherits="search_wordSear" Title="无标题页" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
搜索<%= WebQywy.Data_Public.GetTitleAppend()%>
<style type="text/css">
.CreateWord {
    background:none !important;
    background-color:transparent !important;
}

.CreateWord .resultHeader {
    border-bottom:#eaeaea 1px solid;
    margin-bottom:15px;
    padding:4px 0 8px 0;
    background:none !important;
    background-color:transparent !important;
}

.CreateWord .SearchBoxWordF,
.CreateWord .SearchBoxWordF div {
    background:none !important;
    background-color:transparent !important;
}

.backSearchText {
    font-size:13px;
    color:#4e8f6c;
    text-decoration:none;
}

.backSearchText:hover {
    text-decoration:underline;
}
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<form runat="server" id="form1">

    <div style="display:none;">
        <input name="q" type="text" id="headq" runat="server" />
        <asp:ImageButton ID="Imgbtn_Search" runat="server" onclick="Imgbtn_Search_Click" />
    </div>

    <div class="CreateWord" style="clear:both; min-height:600px; background:none; background-color:transparent;">
        <div class="resultHeader">
            <table cellpadding="0" cellspacing="0" border="0" style="width:100%;">
                <tr>
                    <td style="vertical-align:middle;">
                        <img src="/images/word/searchresults.png"
                             width="16"
                             height="16"
                             style="width:16px; height:16px; vertical-align:middle; margin-right:2px;"
                             alt="" />
                        <span style="vertical-align:middle;">
                            添加了“<span class="Word"><asp:Literal ID="lit_name" runat="server"></asp:Literal></span>”的词单共有
                            <span class="Red"><asp:Literal ID="lit_num" runat="server">0</asp:Literal></span>个，以下是详细信息：
                        </span>
                    </td>
                    <td style="width:180px; text-align:right; vertical-align:middle;">
                        <a href="/search/Default.aspx" class="backSearchText">返回更多搜索>></a>
                    </td>
                </tr>
            </table>
        </div>

        <asp:Repeater ID="rep_wordlist" runat="server">
            <ItemTemplate>
                <div class="SearchBoxWordF" style="overflow:hidden;">
                    <div>
                        <img src="/images/search/search_10.gif"/>
                        <a href="/wordlist.aspx?w=<%#Eval("wl_id") %>"><span class="Green"><%#Eval("name") %></span></a>
                        <span class="Green">　</span>
                        <a href="/user/default.aspx?u=<%#Eval("adduserid") %>"><img width="27" height="26" src="<%#Eval("avater") %>" /></a>
                        创建人：<a href="/user/default.aspx?u=<%#Eval("adduserid") %>"><span class="Name"><%#Eval("realname") %></span></a>
                        　　 <img src="/images/index/index_11.gif" /><span class="Gray">发表于<%#Eval("addtime") %></span>
                        <div class="Black SearchBoxWordE1"><%#Eval("content") %></div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <asp:Literal ID="lit_nullMsg" runat="server"></asp:Literal>

        <div class="yellow">
            <div class="yellow">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Size="13px" onpagechanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
            </div>
        </div>
    </div>

</form>
</asp:Content>
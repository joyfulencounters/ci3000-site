<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="Master.aspx.cs" Inherits="Master" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <asp:Literal ID="lit_titleName" runat="server"></asp:Literal>的个人主页<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="/js/sign.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
function Wsearch() {
    var locat = "word.aspx?w=";
    var sear = escape($("#headq").val());
    window.location.href = "/search/"+locat+sear;
}
</script>
<style>
/* 头像改为方形，加灰色外框 */
.PersonalWordlist .Autographedphotos {
    border-radius: 0 !important;
    width: 90px !important;
    height: 90px !important;
    min-width: 90px !important;
    min-height: 90px !important;
    padding: 6px !important;
    border: 1px solid #ccc !important;
    box-sizing: content-box !important;
}
.PersonalWordlist .Autographedphotos a,
.PersonalWordlist .Autographedphotos a img,
.PersonalWordlist .Autographedphotos img {
    border-radius: 0 !important;
    width: 100% !important;
    height: 100% !important;
}
/* 头像和昵称居中对齐 */
.PersonalWordlistLeft {
    display: flex !important;
    flex-direction: column !important;
    align-items: center !important;
}
/* 只把头像和昵称往左移动 */
.PersonalWordlistLeft .Autographedphotos,
.PersonalWordlistLeft .Name {
    margin-left: -25px !important;
}
/* 推荐词单样式修复 */
.Boxright .List {
    background: #fff;
    border-radius: 8px;
    padding: 15px;
    margin-top: 15px;
}
.Boxright .List .Rank ul {
    list-style: none !important;
    padding: 0;
    margin: 0;
}
.Boxright .List .Rank ul li {
    list-style: none !important;
}
.Boxright .List .Rank ul li::before {
    content: none !important;
}
.Boxright .List .Rank li {
    height: auto !important;
    min-height: 120px;
    padding: 15px 0;
    border-bottom: 1px dashed #e0e0e0;
    overflow: hidden;
}
.Boxright .List .Rank li:last-child {
    border-bottom: none;
}
.Boxright .WordTxt {
    width: 100%;
}
.Boxright .WordTxt1 {
    display: flex;
    flex-wrap: wrap;
    align-items: center;
    gap: 8px;
}
.Boxright .WordTxt1 .Autographedphotos {
    display: none !important;
}
.Boxright .WordTxt1 .Autographedphotos img {
    width: 100% !important;
    height: 100% !important;
    border-radius: 50% !important;
    object-fit: cover;
}
.Boxright .photosTxt {
    font-size: 12px;
    color: #666;
    line-height: 1.6;
}
.Boxright .photosTxt a {
    text-decoration: none;
    color: #333;
}
.Boxright .photosTxt a:hover {
    color: #4e8f6c;
}
.Boxright .photosTxt h3 {
    font-size: 14px;
    font-weight: 500;
    color: #333;
    margin: 3px 0;
    display: inline;
}
.Boxright .SeparateWords {
    width: 100%;
    margin-top: 8px;
    font-size: 12px;
    color: #888;
    line-height: 1.8;
}
.Boxright .SeparateWords a {
    color: #4e8f6c;
    text-decoration: none;
    margin-right: 5px;
}
.Boxright .SeparateWords a:hover {
    text-decoration: underline;
}
</style>
<form runat="server" id="form1">
<div id="MainBox">
    <!--网站主内容-->
  <div class="Boxleft" style="height:1000px;">  	
		<div class="PersonalWordlist">
          <div class="PersonalWordlistLeft">
	        <div class="Autographedphotos"><img id="img_user" runat="server" src="images/word/img_photo.gif"/></div>
	        <div class="PersonalWordlistLeftA Name"><asp:Literal ID="lit_name" runat="server"></asp:Literal></div>
          </div>          
          <div class="PersonalWordlistRight">
  	        <div class="WordlistRightA">
	        <ul>
		        <li><a href="/user/wordlist.aspx?u=<%=uc.UserID %>"><div class="WordlistRightA1"><img src="images/word/word_26.gif"/></div><div>创建<span class="Red"><asp:Literal ID="lit_cr" runat="server">0</asp:Literal></span>词单</div></a></li>
		        <li><a href="/user/collection.aspx?u=<%=uc.UserID %>"><div class="WordlistRightA1"><img src="images/word/word_29.gif"/></div><div>收藏<span class="Red"><asp:Literal ID="lit_co" runat="server">0</asp:Literal></span>词</div></a></li>
		        <li><a href="/user/comment.aspx?u=<%=uc.UserID %>"><div class="WordlistRightA1"><img src="images/word/word_28.gif"/></div><div>评论<span class="Red"><asp:Literal ID="lit_r" runat="server">0</asp:Literal></span>条</div></a></li>
		        <li><a href="/user/word.aspx?u=<%=uc.UserID %>"><div class="WordlistRightA1"><img src="images/word/word_27.gif"/></div><div>添加<span class="Red"><asp:Literal ID="lit_x" runat="server">0</asp:Literal></span>词</div></a></li>
	        </ul>
	        </div>
  	        <div class="WordlistRightB" id="div_sign"><span id="sp_sign" onclick="CkSign(<%=uc.UserID%>)"><asp:Literal ID="lit_feeling" runat="server">懒家伙，什么感言都没有留下...点击写下心情，快点！</asp:Literal></span></div>		  
          </div>
        </div>		
		<div style=" padding:30px 5px; border-bottom:#CCCCCC 1px dashed;"><img src="images/word/word_51.gif"/></div>
		<div style="padding:20px 0px;"><img src="images/word/word_52.gif"/>　<a href="/Create_word.aspx"><img src="images/word/word_54.gif" border="0"/></a></div>
		<div>
<!--		<table width="200px" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><input name="q" type="text" class="txtSearch" id="headq" value="搜索一个词..." maxlength="8" onfocus="if(this.value=='搜索一个词...') this.value='';" /></td>
    <td><a href="javascript:Wsearch();"><img src="/images/index/Search.png" border="0" /></a></td>
  </tr>
</table>--></div>		
	</div>
	<!--网站辅内容-->
  <div class="Boxright">
    <div class="CreateWordlist1">
        <div class="CreateWordlist"><a href="/Create_word.aspx"><img id="im" src="images/word/words_01.png" onMouseOut="huanyuan();" onMouseOver="jiaohuan();"/></a></div>             
    </div>
    <div class="List">
        <div><img src="images/word/word_50.png" width="64" height="18"/></div>
        <div class="Rank">
          <ul><asp:Literal ID="lit_Content" runat="server"></asp:Literal></ul>
        </div>
    </div>
  </div>
</div>
</form>
</asp:Content>


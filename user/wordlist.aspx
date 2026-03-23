<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="wordlist.aspx.cs" Inherits="user_wordlist" Title="无标题页" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <asp:Literal ID="lit_titleName" runat="server"></asp:Literal>的所有词单<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="/js/sign.js" type="text/javascript"></script>
<style>
.userWordlistHeader {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin: 20px 0 15px 0;
}
.userWordlistTitle {
    font-size: 16px;
    font-weight: 500;
    color: #228a30;
    line-height: 1.4;
    padding-left: 8px;
    border-left: 3px solid #7fcf72;
}
/* 排序标签样式 - 文本形式放在右侧 */
.userWordlistSortBar {
    display: flex;
    justify-content: flex-end;
    align-items: center;
    gap: 20px;
}
.userWordlistSortItem {
    font-size: 13px;
    color: #666;
    cursor: pointer;
    padding: 5px 0;
    border-bottom: 2px solid transparent;
    transition: color 0.2s, border-color 0.2s;
}
.userWordlistSortItem:hover {
    color: #228a30;
}
.userWordlistSortItem.active {
    color: #228a30;
    border-bottom-color: #7fcf72;
}
.userWordlistSortItem img {
    display: none;
}
/* 头像改为方形，加灰色外框 - 与wordlist.aspx一致 */
.userWordlistPage .PersonalWordlist .Autographedphotos {
    border-radius: 0 !important;
    width: 90px !important;
    height: 90px !important;
    min-width: 90px !important;
    min-height: 90px !important;
    padding: 6px !important;
    border: 1px solid #ccc !important;
    box-sizing: content-box !important;
}
.userWordlistPage .PersonalWordlist .Autographedphotos a,
.userWordlistPage .PersonalWordlist .Autographedphotos a img {
    border-radius: 0 !important;
    width: 100% !important;
    height: 100% !important;
}
/* 头像和昵称居中对齐 */
.userWordlistPage .PersonalWordlistLeft {
    display: flex !important;
    flex-direction: column !important;
    align-items: center !important;
}
/* 只移动头像和昵称，不影响右侧内容 */
.userWordlistPage .PersonalWordlistLeft .Autographedphotos,
.userWordlistPage .PersonalWordlistLeft .Name {
    margin-left: -20px !important;
}
</style>
<form runat="server" id="form1" class="userWordlistPage">
<div id="MainBox">
    <!--网站主内容-->
	<div class="Boxleft">
		<div class="PersonalWordlist">
		  <div class="PersonalWordlistLeft">
			<div class="Autographedphotos"><asp:HyperLink ID="img_user" runat="server"></asp:HyperLink></div>
			<div class="PersonalWordlistLeftA Name"><asp:Literal ID="lit_name" runat="server"></asp:Literal></div>
		  </div>
		  <div class="PersonalWordlistRight">
		  	<div class="WordlistRightA">
			<ul>
				<li><a href="/user/wordlist.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="/images/word/word_26.gif"/></div><div>创建<span class="Red"><asp:Literal ID="lit_cr" runat="server">0</asp:Literal></span>词单</div></a></li>
				<li><a href="/user/collection.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="/images/word/word_29.gif"/></div><div>收藏<span class="Red"><asp:Literal ID="lit_co" runat="server">0</asp:Literal></span>词</div></a></li>
				<li><a href="/user/comment.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="/images/word/word_28.gif"/></div><div>评论<span class="Red"><asp:Literal ID="lit_r" runat="server">0</asp:Literal></span>条</div></a></li>
				<li><a href="/user/word.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="/images/word/word_27.gif"/></div><div>添加<span class="Red"><asp:Literal ID="lit_x" runat="server">0</asp:Literal></span>词</div></a></li>
			</ul>
			</div>
		  	<div class="WordlistRightB" id="div_sign"><span id="sp_sign" onclick="CkSign(<% if(uc.UserID==uid){%><%= uid%><%} %>)"><asp:Literal ID="lit_feeling" runat="server">懒家伙，什么感言都没有留下...</asp:Literal></span></div>
		  </div>
		</div>
		<div class="ContentLeft1">
<div id="con">
<div class="userWordlistHeader">
  <div class="userWordlistTitle">所有词单</div>
  <div class="userWordlistSortBar">
    <a class="userWordlistSortItem active" href="javascript:void(0)" onclick="switchSortTab(0, this)">按创建时间排序</a>
    <a class="userWordlistSortItem" href="javascript:void(0)" onclick="switchSortTab(1, this)">按最后评论时间排序</a>
  </div>
</div>
<div id="tagContent">
<div class="tagContent" id="tagContent0" style="display:block;">
    <asp:Repeater ID="rep_worlist" runat="server" OnItemCommand="rep_worlist_ItemCommand">
        <ItemTemplate>
            <div class="CommentsBgAllB">
		    <div class="CreateWordlistA1" style="overflow:hidden; ">
              <div class="ViewALLWord"><span class="BlackWord"><a href="/wordlist.aspx?w=<%#Eval("wl_id") %>"><%#Eval("name") %></a></span> <span class="Red"><%#Eval("cnum") %></span>词 <img src="/images/index/index_11.gif" /><span class="Gray">创建于<%#Eval("addtime") %></span>
              <% if (uid == uc.UserID){%><span class="Word"><a href="/Create_word.aspx?w=<%#Eval("wl_id") %>">编辑</a></span> | <span class="Word"><asp:LinkButton ID="lnkbtn_delwl2" OnClientClick="return confirm('您确定要删除该词单吗？')" CommandName="wlDel2" CommandArgument='<%#Eval("wl_id") %>' runat="server">删除</asp:LinkButton></span><%} %></div>
	          <div class="ViewALLWordA" style="overflow:hidden; "><h1><%#Eval("content") %></h1></div>
			  <div class="ViewALLWordB"><img src="/images/word/word_25.gif" /><span>评论</span>（<span class="Red"><%#Eval("r_amount") %></span>） <span class="Gray"><%#Eval("lastrmktime").ToString() == "" ? "" : ("最后评论时间" + Eval("lastrmktime"))%></span></div>
		    </div>
		  </div>
        </ItemTemplate>
    </asp:Repeater>
	<div class="yellow"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Size="13px" onpagechanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager></div>
	</div>
<div class="tagContent" id="tagContent1" style="display:none;">

<asp:Repeater ID="rep_wordlistR" runat="server" OnItemCommand="rep_worlist_ItemCommand">
    <ItemTemplate>
        <div class="CommentsBgAllB">
	    <div class="CreateWordlistA1">
          <div class="ViewALLWord"><span class="BlackWord"><a href="/wordlist.aspx?w=<%#Eval("wl_id") %>"><%#Eval("name") %></a></span> <span class="Red"><%#Eval("cnum") %></span>词 <img src="/images/index/index_11.gif" /><span class="Gray">创建于<%#Eval("addtime") %></span>
          <% if (uid == uc.UserID){%><span class="Word"><a href="/Create_word.aspx?w=<%#Eval("wl_id") %>">编辑</a></span> | <span class="Word"><asp:LinkButton ID="lnkbtn_delwl2" OnClientClick="return confirm('您确定要删除该词单吗？')" CommandName="wlDel2" CommandArgument='<%#Eval("wl_id") %>' runat="server">删除</asp:LinkButton></span><%} %></div>
          <div class="ViewALLWordA"><h1><%#Eval("content") %></h1></div>
		  <div class="ViewALLWordB"><img src="/images/word/word_25.gif" /><span>评论</span>（<span class="Red"><%#Eval("r_amount") %></span>） <span class="Gray"><%#Eval("lastrmktime").ToString() == "" ? "" : ("最后评论时间" + Eval("lastrmktime"))%></span></div>
	    </div>
	  </div>
    </ItemTemplate>
</asp:Repeater>
<div class="yellow"><webdiyer:AspNetPager ID="AspNetPager2" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Size="13px" onpagechanging="AspNetPager2_PageChanging"></webdiyer:AspNetPager></div>
</div>
</div>
</div>

<script type="text/javascript" language="javascript">
function switchSortTab(tabIndex, selfObj){
	// 操作标签
	var sortBar = document.querySelector('.userWordlistSortBar');
	if (sortBar) {
		var items = sortBar.getElementsByTagName('a');
		for(i=0; i<items.length; i++){
			items[i].className = 'userWordlistSortItem';
		}
		selfObj.className = 'userWordlistSortItem active';
	}
	// 操作内容
	document.getElementById('tagContent0').style.display = tabIndex == 0 ? 'block' : 'none';
	document.getElementById('tagContent1').style.display = tabIndex == 1 ? 'block' : 'none';
}
</script>
</div>
  </div>
<div class="Boxright">
    <div class="CreateWordlist1">
      <asp:MultiView ID="MultiView1" runat="server">
              <asp:View ID="View1" runat="server">
                <div class="CreateWordlist"><a href="/Create_word.aspx"><img id="im" src="/images/word/words_01.png" class="png24" onMouseOut="huanyuan();" onMouseOver="jiaohuan();"/></a></div>
              </asp:View>
              <asp:View ID="View2" runat="server">
                <div class="CreateWordlist3">		
		            <div class="CreateWordlist4"><img src="/images/word/word_24.png"  class="png24"/></div>
		            <div class="CreateWordlist2"><asp:Literal ID="lit_Index" runat="server"></asp:Literal></div>
		            <div class="CreateWordlist4">契合指数代表双方喜好的词的重叠情况。数字越大，叠加程度越高。</div>		
		        </div>
              </asp:View>
          </asp:MultiView>
    </div>
    <div class="List">
        <div><img src="/images/word/word_23.png"  class="png24"/></div>
        <div class="Rank">
          <ul>
              <asp:Repeater ID="rep_remark_wl" runat="server">
                <ItemTemplate>
                    <li><img src="/images/word/word_30.gif" />　<a href="/wordlist.aspx?w=<%#Eval("wl_id") %>#remark"><%#Eval("content") %></a></li>        
                </ItemTemplate>
              </asp:Repeater>
          </ul>
        </div>
    </div>
  </div>
</div>
</form>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="user_Default" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <asp:Literal ID="lit_titleName" runat="server"></asp:Literal>的个人首页<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="/js/sign.js" type="text/javascript"></script>
<form runat="server" id="form1">
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
				<li><a href="/user/wordlist.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="/images/word/word_26.gif" class="png24"/></div><div>创建<span class="Red"><asp:Literal ID="lit_cr" runat="server">0</asp:Literal></span>词单</div></a></li>
				<li><a href="/user/collection.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="/images/word/word_29.gif"  class="png24"//></div><div>收藏<span class="Red"><asp:Literal ID="lit_co" runat="server">0</asp:Literal></span>词</div></a></li>
				<li><a href="/user/comment.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="/images/word/word_28.gif"  class="png24"//></div><div>评论<span class="Red"><asp:Literal ID="lit_r" runat="server">0</asp:Literal></span>条</div></a></li>
				<li><a href="/user/word.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="/images/word/word_27.gif"  class="png24"//></div><div>添加<span class="Red"><asp:Literal ID="lit_x" runat="server">0</asp:Literal></span>词</div></a></li>
			</ul>
			</div>
		  	<div class="WordlistRightB" id="div_sign"><span id="sp_sign" onclick="CkSign(<% if(uc.UserID==uid){%><%= uid%><%} %>)"><asp:Literal ID="lit_feeling" runat="server">懒家伙，什么感言都没有留下...</asp:Literal></span></div>		  
		  </div>
		</div>		  
		<div class="ContentLeftA">
				  <div class="ContentLeftTitle">
					  <div class="ContentText"  style=" padding:20px 0px;"><img src="/images/word/word_16.png"  class="png24" width="89" height="17" /></div>
					  <div class="ContentMore" style=" margin-top:22px;"><asp:HyperLink ID="hypelnk_wlmore" ImageUrl="/images/index/more.gif" runat="server" Visible="false"></asp:HyperLink></div>
				  </div>        
		  <div>
		      <asp:Literal ID="lit_nullMsg" runat="server" Visible="false">还未添加任何词单。。。</asp:Literal>
              <asp:Repeater ID="rep_worlist" runat="server" OnItemCommand="rep_worlist_ItemCommand">
                   <ItemTemplate>
                   <div class="CreateWordlistA1" style=" clear:both ; height:90px;">
              <div><span class="BlackWord"><a href="/wordlist.aspx?w=<%#Eval("wl_id") %>" ><%#Eval("name") %></a></span> <span class="Red"><%#Eval("cnum") %></span>词 <img src="/images/index/index_11.gif" /><span class="Gray">创建于<%#Eval("addtime") %></span>
              <%if (uid == uc.UserID){ %><span class="Word">　<a href="/Create_word.aspx?w=<%#Eval("wl_id") %>">编辑</a></span>｜<span class="Word"><asp:LinkButton ID="lnkbtn_del" OnClientClick="return confirm('您确定要删除该词单吗？')" CommandName="wlDel" CommandArgument='<%#Eval("wl_id")%>' runat="server">删除</asp:LinkButton></span><%} %></div>
	          <div class="CreateWordlistB"><h1><%#Eval("content") %></h1></div>	          
		    </div>
                   </ItemTemplate>
              </asp:Repeater>             
		  </div>
    </div>
  </div>
	<!--网站辅内容-->
  <div class="Boxright">
      <div class="CreateWordlist1">
        <asp:MultiView ID="MultiView1" runat="server">
              <asp:View ID="View1" runat="server">
                <div class="CreateWordlist"><a href="/Create_word.aspx"><img id="im" src="/images/word/words_01.png" class="png24" onMouseOut="huanyuan();" onMouseOver="jiaohuan();"/></a></div>
              </asp:View>
              <asp:View ID="View2" runat="server">
                <div class="CreateWordlist3">		
		            <div class="CreateWordlist4"><img src="/images/word/word_24.png" class="png24" /></div>
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
              <asp:Repeater ID="rep_NewRk" runat="server" OnItemDataBound="rep_NewRk_ItemDataBound">
              <ItemTemplate>
              <li><img src="/images/word/word_30.gif" />　<asp:Literal ID="lit_content" runat="server"></asp:Literal></li>
              </ItemTemplate>
              </asp:Repeater>
          </ul>
        </div>
      </div>
    </div>
</div>
<div id="MainBox">
				<div class="ContentLeftTitle" style=" width:100%">
					  <div class="ContentText"><img src="/images/word/word_22.png"  class="png24" width="71" height="19" /></div>
					  <div class="ContentMore" style="margin-top:4px;"><asp:HyperLink ID="hypeLnk_more" ImageUrl="/images/index/more.gif" runat="server" Visible="false"></asp:HyperLink></div>
  </div>
				<div class="TagCloudone" >
				<ul>
              <asp:Repeater ID="rep_coll" runat="server" OnItemCommand="rep_coll_ItemCommand">
              <ItemTemplate>
              <li><span class="BlackWordList"><a href="/word.aspx?c=<%#Eval("w_id") %>" ><%#Eval("name") %></a></span>
                 <%--<% if (uid == uc.UserID){%><span><asp:LinkButton ID="lnkbtn_delCW" OnClientClick="return confirm('您确定要删除该词的收藏吗？')" CommandName="cwDel" CommandArgument='<%#Eval("w_id") %>' runat="server">删除</asp:LinkButton></span><%} %>--%>
              </li>
              </ItemTemplate>
              </asp:Repeater>
          </ul>
				</div>
</div>
</form>
</asp:Content>


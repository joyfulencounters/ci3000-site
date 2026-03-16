<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="collection.aspx.cs" Inherits="collection" Title="无标题页" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
词收藏<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="/js/collection.js" language="javascript" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    var uid = <%=uc.UserID %>;
</script>
<script src="/js/sign.js" type="text/javascript"></script>
<div id="MainBox">
    <!--网站主内容-->
	<div class="Boxleft">
  	
		<div class="PersonalWordlist">
		  <div class="PersonalWordlistLeft">
			<div class="Autographedphotos"><img id="img_user" runat="server" src="images/word/img_photo.gif"/></div>
			<div class="PersonalWordlistLeftA Name"><asp:Literal ID="lit_name" runat="server"></asp:Literal></div>
		  </div>		  
		  <div class="PersonalWordlistRight">
		  	<div class="WordlistRightA">
			<ul>
				<li><a href="/all_wordlist.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="images/word/word_26.gif"/></div><div>创建<span class="Red"><asp:Literal ID="lit_cr" runat="server">0</asp:Literal></span>词单</div></a></li>
				<li><a href="/collection.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="images/word/word_29.gif"/></div><div>收藏<span class="Red"><asp:Literal ID="lit_co" runat="server">0</asp:Literal></span>词</div></a></li>
				<li><a href="/All_comments.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="images/word/word_28.gif"/></div><div>评论<span class="Red"><asp:Literal ID="lit_r" runat="server">0</asp:Literal></span>条</div></a></li>
				<li><a href="/all_word.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="images/word/word_27.gif"/></div><div>共添加<span class="Red"><asp:Literal ID="lit_x" runat="server">0</asp:Literal></span>新词</div></a></li>
			</ul>
			</div>
		  	<div class="WordlistRightB" id="div_sign"><span id="sp_sign" onclick="CkSign(<% if(uc.UserID==uid){%><%= uid%><%} %>)"><asp:Literal ID="lit_feeling" runat="server">懒家伙，什么感言都没有留下...点击写下心情，快点！</asp:Literal></span></div>		  
		  </div>
		</div>
		  
	  <div class="ContentLeftA">
				  <div class="ContentLeftTitle">
				    <div class="ContentText" style=" padding:20px 0px;"><img src="images/word/words_12.png" width="36" height="19"/></div>
				    <div class="ContentMore">
				      <div style="margin-top:5px;">
                        <asp:Panel ID="pane_coll" runat="server" Visible="false">                            
				        <div class="CreateWordlistG">添加想要收藏的词：
				          <input type="text" name="n" value="请输入想要收藏的词..." id="Input_word" onfocus="if(this.value=='请输入想要收藏的词...')this.value='';" onkeyup="Onkeyup('Input_word');" />
                        </div>
				        <div class="CreateWordlistF"><a href="javascript:void(0);" onclick="WordCheck()"><img src="images/word/word_02.gif" border="0" alt="收藏词" /></a>
				        <span id="sp_Vili" style="color:Red;display:none;">注意：添加的词不能超过8个汉字，中间不可添加空格或其它符号</span></div>
				        </asp:Panel>
			          </div>
			            <span id="sp_load" style="display:none;">load...</span>
				        <div id="div_wordType" style="display:none;"><asp:Literal ID="lit_wordTypeList" runat="server"></asp:Literal></div>
				    </div>
				  </div>        
	              <div class="CreateWordlistD">
					<ul class="BlackWordList">
					
					<asp:Repeater ID="rep_coll" runat="server">
              <ItemTemplate>
              <li><%#Eval("name") %></li>
              </ItemTemplate>
              </asp:Repeater>             
					
					</ul>
		</div>
		<webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Size="13px" onpagechanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
		<div class="CreateWordlistE"></div>	
		
    </div>

  </div>
	<!--网站辅内容-->
    <div class="Boxright">
      <div class="CreateWordlist1">
        <asp:MultiView ID="MultiView1" runat="server">
              <asp:View ID="View1" runat="server">
                <div class="CreateWordlist"><a href="/Create_word.aspx"><img id="im" src="images/word/words_01.png" onMouseOut="huanyuan();" onMouseOver="jiaohuan();"/></a></div>
              </asp:View>
              <asp:View ID="View2" runat="server">
                <div class="CreateWordlist3">		
		            <div class="CreateWordlist4"><img src="images/word/word_24.png"/></div>
		            <div class="CreateWordlist2"><asp:Literal ID="lit_Index" runat="server"></asp:Literal></div>
		            <div class="CreateWordlist4">契合指数代表双方喜好的词的重叠情况。数字越大，叠加程度越高。</div>		
		        </div>
              </asp:View>
          </asp:MultiView>
      </div>
    </div>
</div>
</asp:Content>


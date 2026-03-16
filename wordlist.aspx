<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="wordlist.aspx.cs" Inherits="wordlist" Title="无标题页" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
【词单】<asp:Literal ID="lit_titleName" runat="server"></asp:Literal> <%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="/js/addword.js" language="javascript" type="text/javascript"></script>
    <script src="/js/pages.js" language="javascript" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        var uid = <%=uc.UserID %>;
        word.wlid = <%=wlid %>;
    </script>
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
				<li><asp:Literal ID="lit_cr" runat="server">0</asp:Literal></li>
				<li><asp:Literal ID="lit_co" runat="server">0</asp:Literal></li>
				<li><asp:Literal ID="lit_r" runat="server">0</asp:Literal></li>
				<li><asp:Literal ID="lit_x" runat="server">0</asp:Literal></li>
			</ul>
			</div>
		  	<div class="WordlistRightB" id="div_sign"><asp:Literal ID="lit_feeling" runat="server">懒家伙，什么感言都没有留下...</asp:Literal></div>		  
		  </div>
		</div>
		  
		<div class="ContentLeft1">
          <div class="ContentLeftTitle1">
              <div class="ContentText" style=" padding:20px 0px;"><img src="images/word/word_20.gif"/></div>
          </div>        
          <div class="CreateWordlistA">

			<div><span class="BlackWord">
                <asp:Literal ID="lit_wname" runat="server"></asp:Literal></span> <span class="Red">
                    <asp:Literal ID="lit_cnum" runat="server"></asp:Literal></span>词 <img src="images/index/index_11.gif" /><span class="Gray">创建于<asp:Literal ID="lit_ctime" runat="server"></asp:Literal></span>　<span class="Word"><asp:HyperLink ID="hypelnk_edit" runat="server" Visible="false">编辑</asp:HyperLink></span></div> 
			
			<div class="Black"><h1>
                <asp:Literal ID="lit_content" runat="server"></asp:Literal></h1></div> 
			
			<div class="CreateWordlistB">
				<div class="CreateWordlistB2"><a id="pl" href="javascript:Whow_Word_Page('true',<%=wlid %>,1);"><img src="images/word/word_22.gif" border="0" /></a>　<a id="lb" href="javascript:Whow_Word_Page('false',<%=wlid %>,1);"><img src="images/word/word_21.gif" border="0" /></a></div>
				<div class="CreateWordlistB1"><img src="images/word/word_25.gif" /><span>评论</span>（<span class="Red"><asp:Literal ID="lit_rnum" runat="server"></asp:Literal></span>） <span class="Gray"><asp:Literal ID="lit_rtime" runat="server"></asp:Literal></span></div>	            
			</div> 
			
			<div class="CreateWordlistC">
				<div id="ShowList"><img src="/images/load.gif" alt="" /></div>
	            <div style="clear:both;" class="yellow" id="pages"></div>
	            <script language="javascript" type="text/javascript">    
                    CurrentPage(10,10,1);
                </script>
				<div class="CreateWordlistE">
				<div>
				<asp:Panel ID="pane_addwl" runat="server" Visible="false">
				    <div class="CreateWordlistG">向词单添加词：<input name="n" type="text" id="Input_word" onfocus="if(this.value=='输入想要添加的词...')this.value='';" onkeyup="Onkeyup('Input_word');" value="输入想要添加的词..." size="17" maxlength="8" /></div>
                    <div class="CreateWordlistF"><a href="javascript:void(0);" onclick="WordCheck()"><img src="images/word/word_02.gif" border="0" alt="添加新词" /></a>
                    <span id="sp_Vili" style="color:#ff17a3;display:none;">注意：添加的词不能超过8个汉字，中间不可添加空格或其它符号</span></div></asp:Panel>
				</div>				
				<span id="sp_load" style="display:none;">load...</span>

				</div>					
				<div id="div_wordType" style="display:none; clear:both; background:#f3f3f3; line-height:30px; background:#FFF; padding:15px; border:#e6e6e6 1px solid; overflow:hidden; "><asp:Literal ID="lit_wordTypeList" runat="server"></asp:Literal></div>		
			</div>			
          </div>        
        </div>
        
		<div class="ContentLeftA">
		  <div class="ContentLeftTitle">
			  <div class="ContentText"><img src="images/word/word_010.gif" /></div>			  
		  </div>        
		  <div>
		  <a name="remark"></a>
              <asp:Literal ID="lit_NoMess" runat="server" Visible="false">暂还没有用户作出任何评论。</asp:Literal>
            <asp:Repeater ID="rep_RemarkWl" runat="server">
                <ItemTemplate>
                    <div class="MessageList">
					<div class="MessageSignature"><a href="/user/default.aspx?u=<%#Eval("userid") %>"><img style="margin-top:2px;margin-left:2px;" width="50" height="50" alt="<%# Eval("realname")%>" src="<%# Eval("avater")%>" /></a></div>
					<div class="MessageListTxt1"><a href="/user/default.aspx?u=<%#Eval("userid") %>"><span class="Name"><%# Eval("realname")%></span></a> 评论 <span class="Word"><%# Eval("name")%></span>
					  <ul><li><h1><%# Eval("content")%></h1></li>
						<li><h2><img src="images/index/index_11.gif" alt="" />发表于 <%# WebQywy.Data_Public.DateToAgoString(Convert.ToDateTime(Eval("addtime")))%></h2></li>
					  </ul>
				  </div>
				</div>
                </ItemTemplate>
            </asp:Repeater>
		  </div>
		  <div class="yellow"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Size="13px" onpagechanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager></div>		
        </div>

		<div class="ContentLeft1">
          <div class="ContentLeftTitle1">
              <div class="ContentText"><img src="images/word/word_030.gif"  /></div>
				  <div class="zao">
				  	<div id="contentPad">
						  <!--<span class="formInfo"><a href="ajax.htm?width=375" class="jTip" id="one" name="怎么造句:"><img src="images/word/index_01.gif"  /></a></span>-->
				  	</div>
				  </div>			  
          </div>        
          <div class="WordBoxF">
              <div> <textarea class="TextFields" value="把你的想法说出来..." onfocus="if(this.value=='把你的想法说出来...')this.value='';" id="txt_ContentR" runat="server" name="textarea" ></textarea>
              </div>
              <div class="WordBoxF1"><asp:ImageButton ID="Imgbtn_Ok" runat="server" ImageUrl="/images/word/word_btt.gif" onclick="Imgbtn_Ok_Click" OnClientClick='return CkLogin(uid);' /></div>          
		  </div>        
        </div>	
	</div>    
    <!--网站辅内容-->
    <div class="Boxright">
      <div class="CreateWordlist1">
          <asp:MultiView ID="MultiView1" runat="server">
              <asp:View ID="View1" runat="server">
                <div class="CreateWordlist"><a href="/Create_word.aspx"><img id="im" src="/images/word/words_01.png" onMouseOut="huanyuan();" onMouseOver="jiaohuan();"/></a></div>
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
</form>
</asp:Content>


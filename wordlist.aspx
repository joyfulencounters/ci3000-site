<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="wordlist.aspx.cs" Inherits="wordlist" Title="无标题页" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
【词单】<asp:Literal ID="lit_titleName" runat="server"></asp:Literal> <%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="/js/jtip.js" type="text/javascript"></script>
<style>
.wordlistAddSection .MeaningWordE {
    border-bottom: none !important;
    margin-left: 0 !important;
}
.wordlistAddSection .TagSubmitBtn {
    display: inline-flex !important;
    align-items: center !important;
    justify-content: center !important;
    height: 32px !important;
    padding: 0 15px !important;
}
.WordListTitle {
    font-size: 16px;
    font-weight: 500;
    color: #228a30;
    line-height: 1.4;
    padding-left: 8px;
    border-left: 3px solid #7fcf72;
}
.wordlistCommentSection > .ContentLeftA { margin-top: 30px !important; }
.wordlistMainSection { margin-top: 25px !important; margin-bottom: 0 !important; }
.ContentLeft1.commentSection { margin-top: 10px !important; }
.ContentLeft1,
.CreateWordlistA,
.CreateWordlistC,
.CreateWordlistE,
#ShowList {
    height: auto !important;
    min-height: 0 !important;
    margin-bottom: 0 !important;
    padding-bottom: 0 !important;
}
/* 加载图片左上角显示 */
#ShowList img {
    display: block !important;
    width: 200px !important;
    height: 200px !important;
    margin: 2px 0 0 5px !important;
}

/* 评论输入区样式 */
.commentSection { margin-top: 0 !important; }
/* 分页样式 - 移除边框 */
#pages.yellow,
.wordlistPager.yellow {
    margin: 30px 3px 3px 3px !important;
    padding: 0 !important;
}
.wordlistMainSection .CreateWordlistD ul {
    margin-bottom: 20px !important;
}
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
.PersonalWordlist .Autographedphotos a img {
    border-radius: 0 !important;
    width: 100% !important;
    height: 100% !important;
}
/* 头像和昵称整体往左移动 */
.PersonalWordlistLeft {
    padding-left: 20px !important;
}
/* 右侧四个方块和此刻心情往右移动 */
.PersonalWordlistRight {
    padding-left: 17px !important;
}
/* 头像和昵称居中对齐 */
.PersonalWordlistLeft {
    display: flex !important;
    flex-direction: column !important;
    align-items: center !important;
}
/* 列表视图删除按钮不换行 */
.CommentsText .CreateWordlistD2 {
    white-space: nowrap !important;
    overflow: visible !important;
    display: flex !important;
    align-items: center !important;
    justify-content: space-between !important;
    position: relative !important;
}
/* 列表视图词条内容与删除按钮布局 */
.CommentsText .WordListItemContent {
    white-space: nowrap;
    overflow: hidden;
    text-overflow: ellipsis;
    flex: 1;
    padding-right: 30px;
}
.CommentsText .WordListDelBtn {
    color: #999 !important;
    font-size: 16px !important;
    margin-left: 5px !important;
    flex-shrink: 0;
}
#pages.yellow A, #pages.yellow SPAN,
.wordlistPager.yellow A, .wordlistPager.yellow SPAN {
    border: none !important;
    padding: 2px 6px !important;
    margin: 0 !important;
    background: none !important;
}
/* 当前页样式 */
DIV#pages.yellow SPAN.current,
DIV.wordlistPager.yellow SPAN.current {
    background: #4e8f6c !important;
    border-radius: 4px !important;
}
DIV#pages.yellow SPAN.current A,
DIV.wordlistPager.yellow SPAN.current A {
    font-weight: bold !important;
    color: #fff !important;
}
#pages.yellow A:hover,
.wordlistPager.yellow A:hover {
    color: #4e8f6c !important;
    background: none !important;
}
.commentSection .WordBoxF {
    position: static;
}
.commentSection .WordBoxF .zao{
    display: block;
    width: 100%;
    text-align: right;
    margin: 0 0 14px 0;
    padding: 0;
    line-height: 1;
}
.commentSection .WordBoxF > div:nth-child(2){
    width: 100%;
    margin: 0;
    padding: 0;
}
.commentSection .WordBoxF .TextFields{
    display: block;
    width: 100% !important;
    box-sizing: border-box;
    margin: 0;
}
.commentSection .WordBoxF .zao img {
    display: none;
}
.commentSection .WordBoxF .zao a.jTip {
    display: inline-block;
    font-size: 14px;
    color: #4e8f6c;
    text-decoration: underline;
    cursor: help;
    white-space: nowrap;
}
.commentSection .WordBoxF .zao a.jTip::before {
    content: "怎么造句？";
}
.commentSection .WordBoxF .zao a.jTip:hover {
    color: #3f7f5c;
    text-decoration: none;
}
.commentSection .WordBoxF .TextFields {
    background: #fff;
    padding: 12px 70px 12px 12px;
    border: 1px solid #dcdcdc;
    border-radius: 6px;
    font-size: 14px;
    line-height: 1.6;
    transition: border-color 0.2s, box-shadow 0.2s;
}
.commentSection .WordBoxF .TextFields:focus {
    border-color: #4e8f6c;
    box-shadow: 0 0 0 2px rgba(78,143,108,0.08);
    outline: none;
}
.commentSection .WordBoxF > div:first-child{
    width: 100%;
}
.commentSection .WordBoxF .TextFields{
    display: block;
    width: 100% !important;
    box-sizing: border-box;
}
.commentSection .WordBoxF1{
    width: 100%;
    text-align: right;
    margin-top: 10px;
}
.commentSection .WordBoxF1 .CommentSubmitBtn{
    display: inline-block;
}
.CommentSubmitBtn{
    background: #4e8f6c !important;
    color: #fff !important;
    border: none !important;
    border-radius: 6px !important;
    height: 36px !important;
    padding: 0 20px !important;
    font-size: 14px !important;
    cursor: pointer !important;
}
.CommentSubmitBtn:hover{
    background: #3f7f5c;
}
</style>
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
		  
		<div class="ContentLeft1 wordlistMainSection">
          <div class="ContentLeftTitle1">
              <div class="ContentText WordListTitle">词单</div>
          </div>        
          <div class="CreateWordlistA">

			<div><span class="BlackWord">
                <asp:Literal ID="lit_wname" runat="server"></asp:Literal></span> <span class="Red">
                    <asp:Literal ID="lit_cnum" runat="server"></asp:Literal></span>词 <img src="images/index/index_11.gif" /><span class="Gray">创建于<asp:Literal ID="lit_ctime" runat="server"></asp:Literal></span>　<span class="Word"><asp:HyperLink ID="hypelnk_edit" runat="server" Visible="false">编辑</asp:HyperLink></span></div> 
			
			<div class="Black"><h1>
                <asp:Literal ID="lit_content" runat="server"></asp:Literal></h1></div> 
			
			<div class="CreateWordlistB">
				<div class="CreateWordlistB2"><a id="pl" href="javascript:Whow_Word_Page('true',<%=wlid %>,1);" style="color:#4e8f6c;text-decoration:underline;">排列</a>　<a id="lb" href="javascript:Whow_Word_Page('false',<%=wlid %>,1);" style="color:#666;text-decoration:underline;">列表</a></div>
				<div class="CreateWordlistB1"><img src="images/word/word_25.gif" /><span>评论</span>（<span class="Red"><asp:Literal ID="lit_rnum" runat="server"></asp:Literal></span>） <span class="Gray"><asp:Literal ID="lit_rtime" runat="server"></asp:Literal></span></div>	            
			</div> 
			
			<div class="CreateWordlistC">
				<div id="ShowList"><img src="/images/load.gif" alt="" /></div>
	            <div style="clear:both;margin:50px 3px 3px 3px!important;padding-top:20px!important;" class="yellow wordlistPager" id="pages"></div>
	            <script language="javascript" type="text/javascript">    
                    CurrentPage(10,10,1);
                </script>
				<div class="CreateWordlistE wordlistAddSection">
				<div>
				<asp:Panel ID="pane_addwl" runat="server" Visible="false">
				    <div class="MeaningWordE">
				        <div class="Wordbttse1">向词单添加词：<input name="n" type="text" id="Input_word" onfocus="if(this.value=='输入想要添加的词...')this.value='';" onkeyup="Onkeyup('Input_word');" value="输入想要添加的词..." size="17" maxlength="8" /></div>
                        <div class="Wordbttse"><a href="javascript:void(0);" onclick="WordCheck()" class="TagSubmitBtn">添加</a></div>
                    </div>
                    <span id="sp_Vili" style="color:#ff17a3;display:none;">注意：添加的词不能超过8个汉字，中间不可添加空格或其它符号</span></asp:Panel>
				</div>				
				<span id="sp_load" style="display:none;">load...</span>

				</div>					
				<div id="div_wordType" style="display:none; clear:both; background:#f3f3f3; line-height:30px; background:#FFF; padding:15px; border:#e6e6e6 1px solid; overflow:hidden; "><asp:Literal ID="lit_wordTypeList" runat="server"></asp:Literal></div>		
			</div>			
          </div>        
        </div>
        
		<div class="ContentLeftA wordlistCommentSection" style="margin-top: 30px; margin-bottom: 0;">
		  <div class="ContentLeftTitle">
			  <div class="ContentText WordListTitle">词单评论</div>			  
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
		  <div class="yellow wordlistPager" style="font-weight:bold;"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Size="13px" onpagechanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager></div>		
        </div>

		<div class="ContentLeft1 commentSection">
          <div class="WordBoxF">
              <div class="zao">
                  <div id="contentPad">
                      <span class="formInfo"><a href="ajax.htm?width=375" class="jTip" id="two" name="怎么造句:"></a></span>
                  </div>
              </div>
              <div> <textarea class="TextFields" value="把你的想法说出来..." onfocus="if(this.value=='把你的想法说出来...')this.value='';" id="txt_ContentR" runat="server" name="textarea" ></textarea>
              </div>
              <div class="WordBoxF1"><asp:Button ID="Imgbtn_Ok" runat="server" Text="提交" CssClass="CommentSubmitBtn" OnClientClick='return CkLogin(uid);' onclick="Imgbtn_Ok_Click" /></div>          
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


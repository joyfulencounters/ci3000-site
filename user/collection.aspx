<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="collection.aspx.cs" Inherits="user_collection" Title="无标题页" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <asp:Literal ID="lit_titleName" runat="server"></asp:Literal>的收藏<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="/js/collection.js" language="javascript" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    var uid = <%=uc.UserID %>;
</script>
<script src="/js/sign.js" type="text/javascript"></script>
<style>
/* 收藏标题样式 - 与wordlist.aspx保持一致 */
.CollectionTitle {
    font-size: 16px;
    font-weight: 500;
    color: #228a30;
    line-height: 1.4;
    padding-left: 8px;
    border-left: 3px solid #7fcf72;
}
/* 头像改为方形，加灰色外框 - 与wordlist.aspx保持一致 */
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
/* 头像和昵称居中对齐 */
.PersonalWordlistLeft {
    display: flex !important;
    flex-direction: column !important;
    align-items: center !important;
}
/* 只把头像和昵称往左移动 */
.PersonalWordlistLeft .Autographedphotos,
.PersonalWordlistLeft .Name {
    margin-left: -20px !important;
}
/* 收藏词输入框样式 - 与wordlist.aspx保持一致 */
.collectionAddSection .MeaningWordE {
    border-bottom: none !important;
    margin-left: 0 !important;
}
.collectionAddSection .TagSubmitBtn {
    display: inline-flex !important;
    align-items: center !important;
    justify-content: center !important;
    height: 32px !important;
    padding: 0 15px !important;
}
.MeaningWordE {
    display: flex;
    align-items: center;
    gap: 8px;
    margin: 8px 0 14px 0;
    clear: both;
}
.Wordbttse1 {
    margin-right: 0 !important;
    display: flex;
    align-items: center;
}
.Wordbttse1 input {
    width: 250px;
    height: 28px;
    padding: 0 10px;
    border: 1px solid #d7ddd7;
    border-radius: 14px;
    box-shadow: none;
    vertical-align: middle;
    margin: 0;
}
.Wordbttse1 input:focus {
    border-color: #8db79f;
    background: #fff;
}
.Wordbttse {
    display: flex;
    align-items: center;
}
.TagSubmitBtn {
    background: #4e8f6c;
    color: #fff !important;
    border: none;
    border-radius: 14px;
    padding: 0 20px;
    height: 28px;
    line-height: 28px;
    cursor: pointer;
    text-decoration: none;
    font-size: 13px;
}
.TagSubmitBtn:hover {
    background: #3d7a57 !important;
    color: #fff !important;
}
</style>
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
				<li><a href="/user/wordlist.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="/images/word/word_26.gif"/></div><div>创建<span class="Red"><asp:Literal ID="lit_cr" runat="server">0</asp:Literal></span>词单</div></a></li>
				<li><a href="/user/collection.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="/images/word/word_29.gif"/></div><div>收藏<span class="Red"><asp:Literal ID="lit_co" runat="server">0</asp:Literal></span>词</div></a></li>
				<li><a href="/user/comment.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="/images/word/word_28.gif"/></div><div>评论<span class="Red"><asp:Literal ID="lit_r" runat="server">0</asp:Literal></span>条</div></a></li>
				<li><a href="/user/word.aspx?u=<%=uid %>"><div class="WordlistRightA1"><img src="/images/word/word_27.gif"/></div><div>添加<span class="Red"><asp:Literal ID="lit_x" runat="server">0</asp:Literal></span>词</div></a></li>
			</ul>
			</div>
		  	<div class="WordlistRightB" id="div_sign"><span id="sp_sign" onclick="CkSign(<% if(uc.UserID==uid){%><%= uid%><%} %>)"><asp:Literal ID="lit_feeling" runat="server">懒家伙，什么感言都没有留下...</asp:Literal></span></div>		  
		  </div>
		</div>		  
	  <div class="ContentLeftA">
				  <div class="ContentLeftTitle">
				    <div class="ContentText" style="padding:20px 0px;"><div class="CollectionTitle">收藏</div></div>
				  </div>        
	              <div class="CreateWordlistD">
					<ul class="BlackWordList">					
			   <asp:Repeater ID="rep_coll" runat="server" OnItemCommand="rep_coll_ItemCommand">
              <ItemTemplate>
              <li ><a href="/word.aspx?c=<%#Eval("w_id") %>"><%#Eval("name") %></a>
<!--              <span id="sp_<%#Eval("w_id") %>" style="display:none;"><% if (uid == uc.UserID){%><asp:LinkButton ID="lnkbtn_delw" OnClientClick="return confirm('您确定要删除该词吗？')" CommandName="wDel" CommandArgument='<%#Eval("w_id") %>' runat="server">删除</asp:LinkButton><%} %></span>-->
              </li>
              </ItemTemplate>
              </asp:Repeater>
              </ul>
              <div class="ContentMore">
				      
		</div>
		<div class="CreateWordlistE"></div><div style="margin-top:5px;" class="collectionAddSection">
                        <asp:Panel ID="pane_coll" runat="server" Visible="false">
				        <div class="MeaningWordE">
				          <div class="Wordbttse1">收藏词：<input name="n" type="text" id="Input_word" onfocus="if(this.value=='输入要收藏的词')this.value='';" onkeyup="Onkeyup('Input_word');" value="输入要收藏的词" size="17" maxlength="8" /></div>
                          <div class="Wordbttse"><a href="javascript:void(0);" onclick="WordCheck()" class="TagSubmitBtn">添加</a></div>
				        </div>
				        <span id="sp_Vili" style="color:#ff17a3;display:none;">注意：添加的词不能超过8个汉字，中间不可添加空格或其它符号</span>
				        </asp:Panel>
			          </div>
			            <span id="sp_load" style="display:none;">load...</span>
				        <div id="div_wordType" style="display:none; clear:both; background:#f3f3f3; line-height:30px; background:#FFF; padding:15px; border:#e6e6e6 1px solid; overflow:hidden; "><asp:Literal ID="lit_wordTypeList" runat="server"></asp:Literal></div>
				    </div>
		
		<div class="yellow"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Size="13px" onpagechanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager></div>			
    </div>
  </div>
	<!--网站辅内容-->
    <div class="Boxright">
      <div class="CreateWordlist1">
        <asp:MultiView ID="MultiView1" runat="server">
              <asp:View ID="View1" runat="server">
                <div class="CreateWordlist"><a href="/Create_word.aspx"><img id="im" src="/images/word/words_01.png"   class="png24" onMouseOut="huanyuan();" onMouseOver="jiaohuan();"/></a></div>
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
    </div>
</div>
</form>
</asp:Content>


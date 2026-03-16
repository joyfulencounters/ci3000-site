<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="comment.aspx.cs" Inherits="user_comment" Title="无标题页" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <asp:Literal ID="lit_titleName" runat="server"></asp:Literal>的所有评论<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script src="/js/sign.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    function Remark_Del(id,rid,type)
    {   
        if(type=="词")
            var action = "RemarkW_Del";
        else
            var action = "RemarkWL_Del";
            
        if(confirm("确定要删除该"+type+"吗？"))
        {
            $.get("/Ajax/AjaxGet.aspx",{ Rid: Math.random(),Action:action,Cid:rid },
            function(Msg) {
                $("#div_"+id).remove();
            });
        }        
    }
</script>
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
				  <div class="ContentLeftTitle" style="border-bottom:#ebebeb 1px solid;">
					  <div class="ContentText"><span class="ContentText" style=" padding:20px 0px;"><span class="Blue"><asp:Literal ID="lit_nm" runat="server"></asp:Literal></span> <img src="/images/word/word_31.gif" width="126" height="17"/></span></div>					  
				  </div>				  		  
            <asp:Repeater ID="rep_wwl_remark" runat="server" OnItemCommand="rep_wwl_remark_ItemCommand"
                      onitemdatabound="rep_wwl_remark_ItemDataBound">
                <ItemTemplate>
                    <div class="CommentsBgAll" id="div_<%#Eval("id")%>">		
						<div class="MessageList">
							  <div class="CommentsBg1">
                                <div class="CreateWordlistB2" style=" width:500px;"><asp:Literal ID="lit_remark" runat="server"></asp:Literal>　　<img src="/images/index/index_11.gif" /><%# WebQywy.Data_Public.DateToAgoString(Convert.ToDateTime(Eval("addtime")))%> 
                                <% if (uid == uc.UserID){%><span class="Word"><asp:LinkButton ID="lnkbtn_delremark" OnClientClick="return confirm('您确定要删除该评论吗？')" CommandName="remarkDel" CommandArgument='<%#Eval("rcid") %>' runat="server">删除</asp:LinkButton><asp:HiddenField ID="hidetype" runat="server" Value='<%#Eval("r_type") %>' /></span><%} %>                                    
                                </div>
							    <div class="CreateWordlistB1"><asp:Literal ID="lit_del" runat="server" Visible="false"></asp:Literal></div>
						      </div>
							<div class="CommentsBg"><asp:Literal ID="lit_content" runat="server"></asp:Literal></div>
						</div>
		            </div>
                </ItemTemplate>
            </asp:Repeater>
		  <div class="yellow"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Size="13px" onpagechanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager></div>
		</div>
  </div>
	<!--网站辅内容-->
    <div class="Boxright">
      <div class="CreateWordlist1">
        <asp:MultiView ID="MultiView1" runat="server">
              <asp:View ID="View1" runat="server">
                <div class="CreateWordlist"><a href="/Create_word.aspx"><img id="im" src="/images/word/words_01.png"  class="png24" onMouseOut="huanyuan();" onMouseOver="jiaohuan();"/></a></div>
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


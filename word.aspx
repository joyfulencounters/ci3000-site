<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="word.aspx.cs" Inherits="word" Title="无标题页" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<asp:Literal ID="lit_titleName" runat="server"></asp:Literal><%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript" src="/js/word.js"></script>
<script src="/js/jtip.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
    word.uid = <%=uc.UserID %>;
    word.wid = <%=wid %>;
    function onld(){
    var txt = $("#sp_lit").text();        
        try{
        if(getExplorer() == "MSIE")      
            window.frames["iframe"].document.getElementById("word").value = txt;            
        else       
            document.getElementById("iframe").contentWindow.document.getElementById("word").value = txt;
        }catch(e){alert(e);}
    }   
</script>
<form runat="server" id="form1">
<div id="MainBox">
    <!--网站主内容-->
  <div class="Boxleft">  
		<div class="WordBox">				
				<div class="MeaningWordB"><img src="/images/word/word_03.gif" /> 该词已被列入 <span class="Red"><asp:Literal ID="lit_num" runat="server">0</asp:Literal></span> 个词单，初始添加人：<span class="Name"><asp:Literal ID="lit_realname" runat="server"></asp:Literal></span>（<span class="Red"><asp:Literal ID="lit_cnum" runat="server"></asp:Literal></span>词） <span class="Gray">添加于<asp:Literal ID="lit_addtime" runat="server"></asp:Literal></span></div>
				<div class="MeaningWordA"><div id="divCname"><asp:Literal ID="lit_cname" runat="server"></asp:Literal><asp:Image ID="ImgHeart" ImageUrl="/images/word/heart.png" runat="server" Visible="false" /></div></div>
				<div class="MeaningWordC" style=" text-align:left">
				    <span id="sp_lit" style="display:none;"><asp:Literal ID="lit" runat="server"></asp:Literal></span>
                    <iframe id="iframe" name="iframe" src="iframe/transport.htm" width="90%" height="10px;" scrolling="no" frameborder="0"></iframe></div>                    		
				<div><img src="images/word/gmq.png" style="width: 80px; height: auto;" /></div>
				<div class="MeaningWordD"><asp:Literal ID="lit_TagList" runat="server"></asp:Literal></div>
  <div class="MeaningWordE">
      <div class="Wordbttse1">
          <input name="textfield" type="text" id="txt_Tag"
              onfocus="if(this.value=='我对这个词的感觉是?')this.value='';"
              onkeyup="Onkeyup('txt_Tag')"
              value="我对这个词的感觉是?" />
      </div>
      <div class="Wordbttse">
          <a href="javascript:Tag_add();" class="TagSubmitBtn">添加</a>
      </div>
  </div>

  <div class="MeaningWordG">
      <div class="Popword">
          <p>
              <a href="javascript:BeforeWordAdd();" class="WordActionBtn AddToListBtn">
                  <span class="BtnText">加入词单</span>
                  <span style="display:none;">
                      <img src="/images/word/1.gif" id="Image6" alt="加入词单" onmouseover="MM_swapImage('Image6','','/images/word/5.gif',1)" 
  onmouseout="MM_swapImgRestore()" />
                  </span>
              </a>
          </p>
          <div id="emid" style="display:none;">
              <div><img src="/images/word/word_s_01.gif"/></div>
              <div class="bitsword" style="width:700px; ">
                  <div class="bitswordB" style="clear:both; color:#000000; font-size:14px; margin-bottom:15px;"><b>请点击选择您要将“<asp:Literal ID="lit_thisname" 
  runat="server"></asp:Literal>”添加到的词单</b>&nbsp;</div>
                  <div class="bitswordA" style="height:220px; overflow: scroll">
                      <ul><asp:Literal ID="lit_li" runat="server"></asp:Literal></ul>
                  </div>
                  <div style="margin-top:15px; clear:both;"><a href="/Create_word.aspx"><img src="images/word/word_09.gif"/></a></div>
              </div>
              <div><img src="/images/word/word_s_04.gif"/></div>
          </div>
      </div>

      <div class="MeaningWordG1">
          <asp:HyperLink ID="hplnk_collection" runat="server" CssClass="WordActionBtn CollectionBtn" ImageUrl="/images/word/2.gif"></asp:HyperLink>
      </div>
  </div>

	</div>				  
<div class="ContentLeft1" style="clear:both">
    <div class="ContentLeftTitle1 SimilarWordHeader">
        <div class="ContentText SimilarWordTitle">友邻词汇</div>
        <div class="ContentMore">
            <asp:HyperLink ID="hplnk_LikeWord" runat="server" Visible="false" CssClass="SimilarMoreBtn">+更多</asp:HyperLink>
        </div>
    </div>
    <div class="WordBoxA Word">
        <asp:Literal ID="lit_tagWord" runat="server"></asp:Literal>
    </div>
  </div>

		 <div class="ContentLeftA">
    <div class="ContentLeftTitle SimilarWordHeader WordRemarkHeader">
          <div class="ContentText SimilarWordTitle">大家的话</div>
    </div>
  
		    <div>
                <asp:Literal ID="lit_word_remark" runat="server" Visible="false">暂还没有用户作出任何评论。</asp:Literal>
              <asp:Repeater ID="rep_word_remark" runat="server" OnItemDataBound="rep_word_remark_ItemDataBound">
                <ItemTemplate>
                    <div class="MessageList">
					<div class="MessageSignature"><a href="/user/default.aspx?u=<%#Eval("userid") %>"><img style="margin-top:2px;margin-left:2px;" width="50" height="50" alt="<%# Eval("realname")%>" src="<%# Eval("avater")%>" /></a></div>
					<div class="MessageListTxt1"><a href="/user/default.aspx?u=<%#Eval("userid") %>"><span class="Name"><%#Eval("realname")%></span></a> <asp:Literal ID="lit_remark" runat="server"></asp:Literal>
					  <ul><li><h1><asp:Literal ID="lit_content" runat="server"></asp:Literal></h1></li>
						<li><h2><img src="images/index/index_11.gif" />发表于<%# WebQywy.Data_Public.DateToAgoString(Convert.ToDateTime(Eval("addtime")))%></h2></li>
					  </ul>
				  </div>
				</div>
                </ItemTemplate>
              </asp:Repeater>
			</div>	
			<webdiyer:AspNetPager ID="AspNetPager1" runat="server" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Size="13px" onpagechanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>	
		  </div>
	

<div class="ContentLeft1 commentSection">
            <div class="ContentLeftTitle1">
                <div class="ContentText"><img src="images/word/word_03.png"  class="png24"/></div>
            </div>
            <div class="WordBoxF">
                <div class="zao">
                    <div id="contentPad">
                        <span class="formInfo"><a href="ajax.htm?width=375" class="jTip" id="one" name="怎么造句:"><img src="images/word/index_02.gif" id="Image1"
  onmouseover="MM_swapImage('Image1','','images/word/index_01.gif',1)" onmouseout="MM_swapImgRestore()" /> </a></span>
                    </div>
                </div>
                <div> <textarea id="txt_ContentR" class="TextFields" name="textarea"  runat="server" value="把你的想法说出来..." onfocus="if(this.value=='把你的想法说出来...')this.value='';" ></textarea>
                </div>
                <div class="WordBoxF1"><asp:Button ID="Imgbtn_submit" runat="server" Text="提交" CssClass="CommentSubmitBtn"
                          OnClientClick="return CheckUser();" onclick="Imgbtn_submit_Click" /></div>
            </div>
          </div>

  </div>
    <!--网站辅内容-->
    <div class="Boxright">
<div class="DataAmount">
          <div class="SingleWord WordListTitle">
              所属词单
          </div>
          <div class="SingleWord">

            <asp:Repeater ID="rep_WofWl" runat="server">
                <ItemTemplate>
                    <div class="MessageList">
                        <div class="MessageSignature"><a href="/user/default.aspx?u=<%#Eval("userid") %>"><img src="<%#Eval("avater") %>" alt="" width="50" height="50" style="margin-left:2px; margin-top:2px;" /></a></div>
                        <div class="MessageListTxt">
                          <ul>
                            <li style=" height:22px; line-height:22px;" ><span class="Name"><a href="/user/default.aspx?u=<%#Eval("userid") %>"><%#Eval("realname")%></a></span></li>
                            <li><img src="images/index/index_11.gif" /><span class="Word"><a href="wordlist.aspx?w=<%#Eval("wl_id")%>"><%#Eval("name")%></a></span></li>
                          </ul>
                        </div>
                      </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <asp:Literal ID="lit_more" runat="server"></asp:Literal>   
    <div class="Boxright">
<div class="List" style="display:none;">
      <div style=" margin-bottom:20px;"><img src="images/word/word_66.png"  class="png24"/></div>
        <asp:Literal ID="lit_flickr" runat="server"><img src="/images/load.gif" alt="" /></asp:Literal>
  </div>
   
      </div>
    </div>
</div>
</form>
</asp:Content>
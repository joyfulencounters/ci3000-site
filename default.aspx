<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Title="无标题页" EnableViewState="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
千言万语 - 发掘文字趣味  汇集汉语词汇
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link rel="stylesheet" href="style/index_banner.css" type="text/css" media="screen" charset="utf-8">
<script src="/js/slider.js" type="text/javascript" charset="utf-8"></script>
<meta name="description" content="千言万语是一个汇聚美好词汇、供热爱国学和热爱词汇的朋友分享交流的平台。在千言万语，每个人都可以添加和收集自己喜爱的汉语词汇。" />
<form runat="server" id="form1">
<div id="MainBox">
    <!--网站主内容-->
    <div class="Boxleft">
        <div id="wrapper">
      <div id="slider">
            <span class="scrollButtons left">‹</span>
		<div style="overflow: hidden;" class="scroll">
		  <div class="scrollContainer">
              <asp:Repeater ID="rep_comm" runat="server">
                <ItemTemplate>
                    <div class="panel" id="panel_<%# Container.ItemIndex +1%>">
					  <div class="inside"><a href="http://www.ci3000.com/word.aspx?c=<%#Eval("w_id") %>" class="word-banner-text"><%#Eval("name") %></a></div>
					</div>
                </ItemTemplate>
              </asp:Repeater>
          </div>
		</div>
			<span class="scrollButtons right">›</span>        </div>
        
</div>
        <div class="ContentLeft">
          <div class="ContentLeftTitle">
              <div class="ContentText section-title">优选词单</div>
          </div>        
          <div>
          <asp:Literal ID="lit_Content" runat="server"></asp:Literal>   			  
          </div>        
        </div>
		
		<div class="ContentLeft1">
          <div class="ContentLeftTitle1">
              <div class="ContentText section-title">最新词汇</div>
			  <div class="ContentMore">
                  <asp:HyperLink ID="hplnk_more7" Text="+更多" NavigateUrl="/more.aspx" runat="server" Visible="false" style="color:#4e8f6c;text-decoration:none;font-size:13px;"></asp:HyperLink>	
			</div>
          </div>        
          <div style="line-height:35px; width:95%;">
              <asp:Literal ID="lit_words" runat="server"></asp:Literal>
          </div>        
        </div>
		
		<div class="ContentLeft">
          <div class="ContentLeftTitle">
              <div class="ContentText section-title">用户动态</div>
          </div>        
          <div>
          
              <asp:Repeater ID="rep_remark_say" runat="server" OnItemDataBound="rep_remark_say_ItemDataBound">
                <ItemTemplate>
                    <div class="MessageList" style=" clear:both;">
					<div class="MessageSignature" style="padding:2px; width:50px; height:50px;"><a href="/user/default.aspx?u=<%#Eval("userid") %>" style=" "><img width="50" height="50" src="<%#Eval("avater")%>" alt="" /></a></div>
					<div class="MessageListTxt1"><span class="Name"><a href="/user/default.aspx?u=<%#Eval("userid") %>"><%#Eval("realname")%></a></span> <asp:Literal ID="lit_rem" runat="server"></asp:Literal>
					  <ul><li><h1><asp:Literal ID="lit_content" runat="server"></asp:Literal></h1></li>
						<li><h2><img src="images/index/index_11.gif" />发表于<%#WebQywy.Data_Public.DateToAgoString(Convert.ToDateTime(Eval("addtime")))%></h2></li>
						</ul>
				  </div>
				</div>
                </ItemTemplate>
              </asp:Repeater>
          </div>        
        </div>    
    </div>
    <!--网站辅内容-->
    <div class="Boxright">
		<div class="DataAmount">
			<div class="DataAmountBox">
				<div class="DataBox" style="line-height:14px;">
					<ul class="data-list">
						<li><span class="data-label">总词汇量：</span><span class="data-value"><asp:Literal ID="lit_num" runat="server">0</asp:Literal>个</span></li>
						<li><span class="data-label">最新添加：</span><span class="data-value"><asp:Literal ID="lit_word" runat="server"></asp:Literal></span></li>
						<li><span class="data-label">最佳词人：</span><span class="data-value Name"><asp:Literal ID="lit_realname" runat="server"></asp:Literal></span></li>
						<li><span class="data-label">推荐词单：</span><span class="data-value"><asp:Literal ID="lit_cwordlist" runat="server"></asp:Literal></span></li>
					</ul>
                    <div class="data-action-btn">
                        <% if (uc.UserID > 0) { %>
                        <a href="/Create_word.aspx" class="create-word-btn">+ 添加词单</a>
                        <% } else { %>
                        <a href="/member/join.aspx" class="login-btn">立即加入</a>
                        <% } %>
                    </div>
				</div>
			</div>
		</div>
		<div class="buttonLogin"></div>		
		<div class="Introduction">
            <div class="section-header">关于千言万语</div>
            <div class="IntroductionText">
   <div class="intro-content">
<p>　　汉语很美。几个字就是一幅画面，一种境界，一个故事。比如“月来满地水，云起一天山”，某个中秋抬头看月亮的时候，天上正覆着一层薄云，当时想起这幅楹联，只觉得惊心动魄。怎么有人能够隔着无尽时光，用寥寥十个字，就让后来人依然能够感同身受？又比如词牌名。菩萨蛮，说不出的娇俏可爱；醉花阴，那是画上才有的风景；点绛唇，三个字就是一段故事。书法里有种字，叫簪花小楷，且不论这字到底什么样，光听名字便已美不胜收。</p>
<p>　　千言万语就是想发掘并发扬汉语中这些生动鲜活、清新隽永、意味深长的词汇，让每个人汇聚自己喜欢的词汇，赋予这些词个性与意义，留待将来，给自己和爱我们的人，各自缅怀。</p>
</div>
			</div>
            <div style="border-top: 1px dashed #e8e4df; margin: 15px 0;"></div>
            <div style="text-align:center;"><a href="/member/join.aspx" class="small-btn">立即加入我们</a></div>
        </div>
        		
        <div class="List">
			<div class="section-header">热门词汇榜</div>
			<div class="Rank">
				<ul>
                    <asp:Repeater ID="rep_CollMost" runat="server">
                        <ItemTemplate>
 <li><a href="/word.aspx?c=<%#Eval("w_id") %>"><%#Eval("name") %>（<%#Eval("collectionnum")%>）</a>　　　　<span class="Name"><a 
  href="/user/default.aspx?u=<%#Eval("userid") %>"><%#Eval("realname") %></a></span></li>
                        </ItemTemplate>
                    </asp:Repeater>					
				</ul>
			</div>
        </div>		
		
        <div class="List list-members">
			<div class="section-header">新加入成员</div>
			<div class="NewsUsers1">
                <asp:Literal ID="lit_RegUsers" runat="server"></asp:Literal>
			</div>

        </div>
	
	</div>

</div>
</form>
</asp:Content>



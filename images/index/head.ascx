<%@ Control Language="C#" AutoEventWireup="true" CodeFile="head.ascx.cs" Inherits="usercontrol_head" %>
<script language="javascript" type="text/javascript">
function Wsearch()
{
    var locat = "word.aspx?w=";
    var sear = escape($("#headq").val());
    window.location.href = "/search/"+locat+sear;
}
</script>

<div id="MainBox" class="TopBox">
  <div class="logo"><a href="http://www.ci3000.com"><img src="/images/index/logo.gif" border="0" /></a></div>
  <div class="Logged">
  	<div class="Loggedimg"><img src="/images/index/main_05.gif" /></div>
  	<div class="Loggedbg">
          <asp:HyperLink ID="hypelnk_log" runat="server" ImageUrl="/images/index/main_07.gif" NavigateUrl="/member/signin.aspx"></asp:HyperLink>
          <asp:HyperLink ID="hypelnk_reg" runat="server" ImageUrl="/images/index/main_08.gif" NavigateUrl="/member/join.aspx"></asp:HyperLink>
          <asp:HyperLink ID="hypelnk_col" runat="server" ImageUrl="/images/index/main_09.gif" NavigateUrl="javascript:void(0);"></asp:HyperLink>        
    </div>
  	<div class="Loggedimg"><img src="/images/index/main_10.gif" /></div>
  </div>
</div>
<div id="MainBox">
	<div class="Nav">
		<div class="BoxNav">
			<span><a href="/"><img src="/images/index/home.png" alt="首页" id="Image2" onmouseover="MM_swapImage('Image2','','/images/index/home1.png',1)" onmouseout="MM_swapImgRestore()" /></a></span>
			<span><asp:Literal ID="lit_random" runat="server"></asp:Literal></span>
			<span><a href="http://www.ci3000.com/ci3000/Lovers.html"><img src="/images/index/hao.png" alt="与你志趣相投的人"id="Image4" onmouseover="MM_swapImage('Image4','','/images/index/hao1.png',1)" onmouseout="MM_swapImgRestore()" /></a></span>		
			<span style="margin-left:240px;"><a href="http://www.ci3000.com/blog" target="_blank"><img src="/images/index/index_05.png" alt="和我们共同经历"id="Image5" onmouseover="MM_swapImage('Image5','','/images/index/index_050.png',1)" onmouseout="MM_swapImgRestore()" /></a></span>		</div>
		<div class="Boxright">
			<div class="searchTool">
            <form method="get" action="#" name="headSearchForm" id="headSearchForm" onsubmit="return dosearch(this);">
     <input name="q" type="text" class="txtSearch" id="headq" value="搜索一个词"  onfocus="if(this.value=='搜索一个词')this.value='';" />
     <input name="searchdomain" type="hidden" value="#">
     <input id="headSearchType" name="searchType" type="hidden" value="playlist">
     <div class="selSearch">
    <div class="nowSearch" id="headSlected" onclick="if(document.getElementById('headSel').style.display=='none'){document.getElementById('headSel').style.display='block';}else {document.getElementById('headSel').style.display='none';};return false;" onmouseout="drop_mouseout('head');">普通搜索</div>

    <div class="btnSel"><a href="#" onclick="if(document.getElementById('headSel').style.display=='none'){document.getElementById('headSel').style.display='block';}else {document.getElementById('headSel').style.display='none';};return false;" onmouseout="drop_mouseout('head');"></a></div>

    <div class="clear"></div>
    <ul class="selOption" id="headSel" style="display:none;">
     <li><a href="#" onclick="return search_show('head','video',this)" onmouseover="drop_mouseover('head');" onmouseout="drop_mouseout('head');">普通搜索</a></li>
     <li><a href="/search/default.aspx" target="_blank" >更多搜索</a></li>
    </ul>
    </div>
     <div class="btnSearch">
    <a href="javascript:Wsearch();"><img src="/images/index/Search.png" border="0" /></a>
     </div>
  <div class="clear"></div>
  </form>
            </div>
        <div class="clear"></div>
        </div>
    </div>		
</div>
<%@ Control Language="C#" AutoEventWireup="true" CodeFile="head.ascx.cs" Inherits="usercontrol_head" %>

<script language="javascript" type="text/javascript">
function Wsearch()
{
    var locat = "word.aspx?w=";
    var sear = escape($("#headq").val());
    window.location.href = "/search/"+locat+sear;
}
function txtonkeyup(e){
    if(!e)
        document.onkeydown = keyDown;
    else{
        if((event.keyCode == 13)) Wsearch();
    }
}
function keyDown(e){
    if(!e) e=window.event;
    if(e.keyCode==13 ) Wsearch();
}
function onblurNull(){
    document.onkeydown = null;
}
</script>
 <style type="text/css">
<!--

.png24 {tmp:expression(setPng24(this));}
-->
</style>




<script language="javascript" type="text/javascript">
  function setPng24(obj) {
    obj.width=obj.height=1;
    obj.className=obj.className.replace(/\bpng24\b/i,'');
    obj.style.filter =
    "progid:DXImageTransform.Microsoft.AlphaImageLoader(src='"+ obj.src

+"',sizingMethod='image');"
    obj.src='';
    return '';
}</script>



<div id="MainBox" class="TopBox">
  <div class="logo"><a href="http://www.ci3000.com"><img src="/images/logonew2.png" border="0" /></a></div>
  <div class="Logged">
  	<div class="Loggedimg"><img src="/images/index/main_05.gif" /></div>
  	<div class="Loggedbg">
          <asp:Literal ID="lit_log" runat="server"><a href="/member/signin.aspx"><img id="Imagelog" onmouseover="MM_swapImage('Imagelog','','/images/index/main_070.gif',1)" onmouseout="MM_swapImgRestore()" alt="" src="/images/index/main_07.gif" /></a></asp:Literal>
          <asp:Literal ID="lit_reg" runat="server"><a href="/member/join.aspx"><img id="Imagereg" onmouseover="MM_swapImage('Imagereg','','/images/index/main_080.gif',1)" onmouseout="MM_swapImgRestore()" alt="" src="/images/index/main_08.gif" /></a></asp:Literal>
          <asp:Literal ID="lit_col" runat="server"><a href="javascript:void(0);" onclick="javascript:window.external.AddFavorite('http://www.ci3000.com/','千言万语-发掘文字趣味');"><img id="Imagecol" onmouseover="MM_swapImage('Imagecol','','/images/index/main_090.gif',1)" onmouseout="MM_swapImgRestore()" alt="" src="/images/index/main_09.gif" /></a></asp:Literal>
    </div>
  	<div class="Loggedimg"><img src="/images/index/main_10.gif" /></div>
  </div>
</div>
<div id="MainBox">
	<div class="Nav">
		<div class="BoxNav">
			<span class="nav-item"><a href="/" class="nav-link active">&#39318;&#39029;</a></span>
			<span class="nav-item nav-random"><asp:Literal ID="lit_random" runat="server"></asp:Literal></span>
			<span class="nav-item"><a href="http://www.ci3000.com/search/default.aspx?index=3" class="nav-link">&#20973;&#24863;&#35273;</a></span>
            </div>
		<div class="Boxright">
			<div class="searchTool">
     <input name="q" type="text" class="txtSearch" id="headq" value="搜索一个词" onblur="onblurNull()" onfocus="if(this.value=='搜索一个词')this.value='';" onkeyup="return txtonkeyup();" onpropertychange="if(this.value.length>8){this.value=this.value.slice(0,8)}" />
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
    <a href="javascript:Wsearch();"><img src="/images/index/Search.png" border="0"   class="png24" /></a>
     </div>

            </div>
        <div class="clear"></div>
        </div>
    </div>
</div>
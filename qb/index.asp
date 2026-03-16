<!--#include file="conn.asp"-->
<%
OpenDB()

Dim sql,Rs,arrRs
Dim arrRsNumS,arrRsNumI
sql = "Select top 2000 cid,cdate,cauthor,ccontent,cbcolor,cfcolor from ccc_love order by cID DESC"
Set Rs = Conn.Execute(sql)

arrRs = Rs.GetRows

Rs.Close
Set Rs = Nothing
CloseDB()
arrRsNumS = UBound(arrRs,2)
%>
<html>
<head>
<title>千言万语-词汇墙</title>
<meta http-equiv="Pragma" content="no-cache" />
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<meta name="keyword" content=千言万语词汇墙,网络墙,电子墙," />
<link rel="stylesheet" href="style0930.css" type="text/css" />
<style type="text/css">
<!--
body {
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
	background-color: #fff;
}
table {word-break:break-all;}
.tdb {
	background-image: url();
	background-repeat: no-repeat;
	background-position: right top;
}
td {
	font-size: 12px;
	color: #000000;
	line-height: 18px;
}
.white {
	color: #FFFFFF;
	text-decoration: none; 
}
//a:link {
	color: #FFFFFF;
}
a:visited {
	color: #FFFFFF;
}
a:active {
	color: #FF0000;
}
-->
</style>
<script language="JavaScript1.2">
//-- 控制层删除start of script -->
function ssdel(){
if (event)
{
lObj = event.srcElement ;

while (lObj && lObj.tagName != "DIV") lObj = lObj.parentElement ;
}
var id=lObj.id
     document.getElementById(id).removeNode(true);
     //document.getElementById(id).outerHTML="";//
  }

//-- 控制层删除End of script -->
</script>
<script>
//-- 控制层移动start of script -->
var Obj=''
var index=10000;//z-index;
document.onmouseup=MUp
document.onmousemove=MMove

function MDown(Object){
Obj=Object.id
document.all(Obj).setCapture()
pX=event.x-document.all(Obj).style.pixelLeft;
pY=event.y-document.all(Obj).style.pixelTop;
}

function MMove(){
if(Obj!=''){
 document.all(Obj).style.left=event.x-pX;
 document.all(Obj).style.top=event.y-pY;
 }
}

function MUp(){
if(Obj!=''){
 document.all(Obj).releaseCapture();
 Obj='';
 }
}
//-- 控制层移动end of script -->
//获得焦点;
function getFocus(obj)
{
       if(obj.style.zIndex!=index)
       {
               index = index + 2;
               var idx = index;
               obj.style.zIndex=idx;
               //obj.nextSibling.style.zIndex=idx-1;
       }
}
//查找祝福纸条
function Srch(obj)
{//alert(obj);
	if(obj.style.zIndex!=index)
	{
		index = index + 1000;
		var idx = index;
		obj.style.zIndex = idx;
		obj.style.width = 400;
		obj.style.height = 300;
		obj.style.left = 200;
		obj.style.top = 200;
	}
}
function ChkSrch()
{
if (SrchFrm.srchId.value == "")
	{alert("\n\n\n你总得告诉我查找哪一个吧！！\n\n\n");
	SrchFrm.srchId.focus();
	return false; }
return true;
}

function checkNum(obj){
	var checkOK = "0123456789 ";
	var checkStr = obj.value;
	var allValid = true;
	for (i = 0;  i < checkStr.length;  i++){
		ch = checkStr.charAt(i);
		for (j = 0;  j < checkOK.length;  j++)
		if (ch == checkOK.charAt(j))
			break;
		if (j == checkOK.length){
			allValid = false;
			break;
		}
	}
	if (!allValid){
		alert("只能由数字组成！");
		obj.select();
		return (false);
	}
	return (true);	
}
</script>
</head>
<body>
<table width="100%" border="0" cellpadding="0" cellspacing="0" >
  <tr>
    <td width="289" ><img src="images/top.gif" width="670" height="232"></td>
    <td align="right" valign="middle" bgcolor="#d80100" class="tdb">
	<table width="370" border="0" cellspacing="4" cellpadding="0">
	<FORM name="SrchFrm" action="find.asp" onSubmit="return ChkSrch();">
      <tr>
        <td align="right" valign="bottom"><font color="#FFFFFF"><label>
			庆字 <INPUT size=5 value="9999" name="srchId" type="text" onKeyUp="checkNum(this);"> 号
			<INPUT type="submit" value="查找心愿纸条" style="background-color:#fe9402; border:1px outset #ff4301;color:#FFFFFF;font-weight:bold; "> 
        </label><br>
        <br>
        将您的祝福语编辑填写好即可发布到本站许愿墙[发布许愿全部免费</font></td>
      </tr>
	  </FORM>
    </table></td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="1%"><img src="images/nav_top.gif" width="18" height="50"></td>
    <td width="99%" background="images/nav_top.gif"><table width="100%" border="0" cellpadding="1" cellspacing="0" >
      <tr>
        <td align="left"><a href="input.htm"><img src="images/love_04.gif" width="110" height="27" border="0" /></a></td>
        <td align="right"><span class="white">&nbsp;&nbsp;&nbsp;&nbsp;将您的祝福语编辑填写好即可发布到本站许愿墙[发布许愿全部免费]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;共有 <%=arrRsNumS+1%> 张祝福&nbsp;</span>&nbsp;</td>
      </tr>
    </table></td>
    <td width="0%"><img src="images/nav_top.gif" width="18" height="50"></td>
  </tr>
</table>
<table width="100%" height="100%"  border="0">
  <tr>
    <td height="325" align="center" valign="middle" bgcolor="#ffebbd" >
	<%

For arrRsNumI = 0 To arrRsNumS

	Randomize

	LeftPx = Int((1000-10+1)*Rnd+10)
	TopPx = Int((1000-100+1)*Rnd+100)

	Response.write "<div id='cc"&arrRs(0,arrRsNumI)&"' class='Cccc' style='position:absolute;left:"&LeftPx&"px;top:"&TopPx&"px;background-color:"&arrRs(4,arrRsNumI)&";z-index:"&arrRs(0,arrRsNumI)&";' onmousedown='getFocus(this)'>"
	Response.write "<table border=0><td style='cursor:move;' width='98%' onmousedown=MDown(cc"&arrRs(0,arrRsNumI)&")>"&"第["&arrRs(0,arrRsNumI)&"]条&nbsp;"&FormatDateTime(arrRs(1,arrRsNumI),2)&"&nbsp;"&FormatDateTime(arrRs(1,arrRsNumI),4)&"</td><td style='cursor:hand;' onclick='ssdel()' width='2%'>×</td></tr><tr><td style='height:100px;padding:5px;' colspan='2'>"
	Response.write arrRs(3,arrRsNumI)
	Response.write "<div style='padding:5px;float:right;'>"&arrRs(2,arrRsNumI)&"</div></td></tr></table>"
	Response.write "</div>"
Next
%></td>
  </tr>
</table>
</td>
  </tr>
</table>
</body></html>
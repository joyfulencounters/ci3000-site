<!--#include file="conn.asp"-->

<%
if Session("isAdmin")<>true Then
Response.Write "<script>location.href='adminlogin.asp';</script>"
Response.End
End if
%>
<HTML>
<HEAD>
<TITLE> New Document </TITLE>
<style type="text/css">
body {font-size:15px}
</style>
</HEAD>
<%
OpenDB()
dim rs
	set rs=server.createobject("adodb.recordset")
	set rs=conn.execute("select cid,cdate,cauthor,ccontent from ccc_love")
Del=request.QueryString("Del")
if Del=1 then
	conn.execute("delete from ccc_love where cid="&request.QueryString("ID"))
	Response.write "<script>alert('删除成功!!!');location.href='admin.asp';</script>"
	Response.end
end if
%>
<BODY>
<center><h1>管理</h1>
<br>

<br>
	<table border="0" cellspacing="1" cellpadding="3" width="643"  bgcolor="#009ACE">
	  <tr><td>
		  <table width="100%" border="0" cellspacing="1" cellpadding="5" class=TBtwo>
			<tr bgcolor="#eeeeee" class=TBfour>
			  <td width="10%" align=center> I D </td>
			  <td width="15%" align=center>作者</td>
			  <td width="40%" align=center>留言内容</td>
			  <td width="20%" align=center>留言时间</td>
			  <td width="15%"></td>
			</tr>
<%
	if rs.BOF and rs.EOF then
%>
			<tr bgcolor=#FFFFFF class=TBBG9><td colspan=4> </td>
			</tr>
	
<%	
	else
		while not rs.eof
%>
			<tr bgcolor=#FFFFFF class=TBBG9>
			<td><%=rs("cid")%></td><td><%=rs("cauthor")%></td>
			<td><%=rs("ccontent")%></td><td><%=rs("cdate")%></td>
			<td><a href=admin.asp?Del=1&ID=<%=rs("cid")%>> 删除 </a></td>
			</tr>
<%
			rs.movenext
		wend
	end if
	rs.Close
	set rs=nothing
%>
     </table>
     </td></tr>
  </table>

</BODY>
</HTML>

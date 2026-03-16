<!--#include file="conn.asp"-->
<!--#include file="md5.asp"-->
<%
username=trim(Request.form("username"))
password=trim(Request.form("password"))

if username="" or password="" then 
	Response.Redirect ("adminlogin.asp")
end if
password=md5(trim(CheckStr(password)),16)
OpenDB()
set rs=server.createobject("adodb.recordset")
sql="select * from admin_table where user='"&username&"'and password='"&password&"'"
set rs=conn.Execute(sql)
if not rs.EOF and not rs.bOF then
	conn.Execute("update admin_table set Logincount=Logincount+1,LoginTime='"&now()&"',LoginIP='" & Request.ServerVariables("REMOTE_ADDR") & "' where user='"&username&"'and password='"&password&"'")
	Session("Admin")=rs("user")
	Session("IsAdmin")=true
	Session("level")=rs("levels")
    Session.timeout=900
	Response.Redirect ("admin.asp")
else
	Response.Write "请输入正确的管理员名字和密码！<a href='javascript:history.back(-1)'>返回</a>"
	Response.End 
end if
rs.close
set rs=nothing
CloseDB()
%>
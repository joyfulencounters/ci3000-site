<!--#include file="conn.asp"-->
<%
OpenDB()
cauthor = Request.Form("author")
cbcolor = Request.Form("tagbcolor")
ccontent = Request.Form("massages")

ccontent = Replace(Replace(Replace(ccontent,"'",""),">",""),"<","")
If Len(ccontent) >100 Then
LoveTxt = Left(LoveTxt,100)
End If
Conn.execute("Insert Into ccc_love(cauthor,ccontent,cbcolor) values ('" & cauthor &"','" & ccontent & "','"& cbcolor & "')")

CloseDB()
Response.write "<script>alert('\n\n\n\n粘贴祝福纸条成功!!!\n\n\n返回首页查看祝福\n\n\n');location.href='index.asp';</script>"
%>
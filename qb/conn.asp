<%
Dim Conn,ConnStr,DBPath

DBPath = "uc886_aiqiang.asp"
ConnStr = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source = " & Server.MapPath(DBPath)
Public Function Checkstr(Str)
	If Isnull(Str) Then
		CheckStr = ""
		Exit Function 
	End If
	CheckStr = Replace(Str,"'","''")
End Function

Function OpenDB() 
	On Error Resume Next
	Set Conn = Server.CreateObject("ADODB.Connection")
	Conn.open ConnStr
	If Err Then
		err.Clear
		Set Conn = Nothing
		Response.Write "数据库连接出错，请检查连接字串。"
		Response.End
	End If
End Function

Function CloseDB() 
	Conn.Close
	Set Conn = Nothing
End Function
%>
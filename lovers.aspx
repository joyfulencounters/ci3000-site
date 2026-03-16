<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="lovers.aspx.cs" Inherits="lovers" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
同好<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="width:960px; margin:0 auto; height:497px;">



<script language="JavaScript" type="text/javascript" src="js/flash.js"></script> 
<script language="JavaScript" type="text/javascript"> 
writeFlashHTML("_swf=flash/index.swf", "_width=960", "_height=497" ,"_wmode=transparent"); 
</script> 

</div>
</asp:Content>
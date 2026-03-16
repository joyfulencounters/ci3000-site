<%@ Control Language="C#" AutoEventWireup="true" CodeFile="top.ascx.cs" Inherits="usercontrol_top" %>
<div class="topNav">
    <h5> 后台首页</h5>
    <div class="nav">
        用户：<%=Session["AdminName"] %>&nbsp;|&nbsp;<a href="/admin/manage.aspx" target="_top">后台首页</a>&nbsp;|&nbsp;
        <a href="http://www.ci3000.com" target="_blank">网站首页</a>&nbsp;|&nbsp;<a href="/member/loginOut.aspx" target="_top">退出</a></div>
</div>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="admin_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理列表</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="leftNav">
        <div class="topNav"><a href="welcome.aspx" target="mainFrame"><h5>后台管理列表</h5></a></div>
        <div class="nav mt-5">
            <h5 style="padding: 4px 5px"> 词管理</h5>
            <ul>                
                <li><a href="word/list.aspx" target="mainFrame">词列表</a></li>
                <li><a href="word/remark.aspx" target="mainFrame">词评论</a></li>
                <li><a href="word/tag.aspx" target="mainFrame">词Tag</a></li>
            </ul>
        </div>  
        <div class="nav mt-5">
            <h5 style="padding: 4px 5px"> 词单管理</h5>
            <ul>                
                <li><a href="wordlist/list.aspx" target="mainFrame">词单列表</a></li>
                <li><a href="wordlist/remark.aspx" target="mainFrame">词单评论</a></li>
            </ul>
        </div>       
        <div class="nav mt-5">
            <h5 style="padding: 4px 5px">会员管理</h5>
            <ul>                
                <li><a href="user/list.aspx" target="mainFrame">会员列表</a></li>
            </ul>
        </div>        
        <div class="nav mt-5">
            <h5 style="padding: 4px 5px">系统管理</h5>
            <ul>
                <li><a href="sys/keenness.aspx" target="mainFrame">敏感词汇</a></li>
                <li><a href="sys/keenness2.aspx" target="mainFrame">敏感词汇2</a></li>
                <li><a href="sys/comment.aspx" target="mainFrame">每日推荐</a></li>
                <li><a href="sys/commIndex.aspx" target="mainFrame">首页推荐</a></li>
                <li><a href="sys/salutation.aspx" target="mainFrame">有趣的方言</a></li>         
            </ul>
        </div>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="commIndex.aspx.cs" Inherits="admin_sys_commIndex" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../usercontrol/top.ascx" tagname="top" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>首页推荐</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
    <link rel="stylesheet" type="text/css" href="/style/ymPrompt.css" />
    <script src="../../js/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../js/ymPrompt.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        function changePic(wid,wpic)
        {
            ymPrompt.win({message:'/iframe/upfilewordcomm.aspx?wid='+wid+'&pic='+wpic,width:500,height:300,title:'编辑',iframe:true});
        }
        function picstate(wid,pic,bol)
        {
//            ymPrompt.close();
//            if(bol)
//            {
//                $("#imgID_"+wid).attr("src",pic);
//                $("#repID_"+wid).html("<font color=\"red\">已推荐</font>");
//            }
            window.location.href = window.location.href;
        }
         
    </script>    
</head>
<body>
    <form id="form1" runat="server">
    <uc1:top ID="top2" runat="server" />
    <div id="Div1">
        <div class="box-a">
            <h5>搜索词</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="搜索" class="t-list mt-10">
                    <tr >
                        <th width="60" >搜索名称：</th>                        
                        <th>操作</th>
                    </tr>                    
                    <tr>
                        <td> <asp:TextBox ID="txtbox_name" runat="server" MaxLength="8"></asp:TextBox></td>
                        <td><asp:Button ID="btn_submit" runat="server" Text="搜索" onclick="btn_submit_Click" /></td>                        
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:HiddenField ID="hideName" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>        
    </div>
    <div id="main">
        <div class="box-a">
            <h5>词列表</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="词单列表" class="t-list mt-10">
                    <tr >
                        <th width="40" >
                            &nbsp;
                        </th>
                        <th width="80" >
                           词单ID
                        </th>
                         <th width="120" >
                            词单名称
                        </th>                        
                        <th width="100">
                            相关图片
                        </th>
                        <th>
                            当前状态
                        </th>
                    </tr>
                    <asp:Repeater ID="rep_comment" runat="server" 
                        onitemcommand="rep_comment_ItemCommand" >
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td><%#Eval("w_id")%></td>
                                <td><%#Eval("name")%></td>                                
                                <td><img width="200" height="80" id="imgID_<%#Eval("w_id") %>" alt="<%#Eval("name")%>" src="<%#Eval("wpic")%>" /></td>
                                <td><a href="javascript:changePic(<%#Eval("w_id") %>,'<%#Eval("wpic") %>');">修改</a> | 
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit" CommandArgument='<%#Eval("w_id").ToString()+"|"+Eval("iscommend") %>'><%# Commend(Eval("iscommend"))%></asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div class="clearfix mt-10">
         <div class="pages"> 
		    <webdiyer:AspNetPager ID="AspNetPager1" runat="server"  FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" Font-Size="13px" onpagechanging="AspNetPager1_PageChanging">
            </webdiyer:AspNetPager>
		</div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>

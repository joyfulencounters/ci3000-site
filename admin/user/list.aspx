<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="admin_user_list" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../usercontrol/top.ascx" tagname="top" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员列表</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">   
    <uc1:top ID="top1" runat="server" />
    <div id="main">
        <div class="box-a">
            <h5>会员列表</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="会员列表" class="t-list mt-10">
                    <tr >
                        <th width="40" >
                            &nbsp;
                        </th>
                        <th width="100" >
                            头像
                        </th>                        
                        <th width="120">
                            会员mail
                        </th>
                        <th width="120" >
                            会员昵称    
                        </th>                        
                        <th width="120" >
                            <asp:LinkButton ID="lnkbtn_createtime" runat="server" 
                                onclick="lnkbtn_createtime_Click">注册时间</asp:LinkButton>    
                        </th>
                        <th width="120" >
                            <asp:LinkButton ID="lnkbtn_logintimes" runat="server" 
                                onclick="lnkbtn_logintimes_Click">登录次数</asp:LinkButton>    
                        </th>                        
                        <th>
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rep_user" runat="server" onitemcommand="rep_user_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td></td>                                
                                <td><img alt="" src='<%#Eval("avater")%>' /></td>
                                <td><%#Eval("email")%></td>
                                <td><%#Eval("realname")%></td>                                
                                <td><%# CompareToTime(Eval("createdate"))%></td>
                                <td><%#Eval("logintimes")%></td>
                                <td><a href='/user/default.aspx?u=<%#Eval("userid") %>' target="_blank">查看</a>| <asp:LinkButton ID="lnkbtn_del" runat="server" CommandName="udel" OnClientClick="return confirm('该用户所有信息删除后不可恢复，确定要删除吗？')" CommandArgument='<%#Eval("userid") %>'>删除</asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <asp:HiddenField ID="hideOrder" runat="server" Value="userid asc" />
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

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="comment.aspx.cs" Inherits="admin_sys_comment" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../usercontrol/top.ascx" tagname="top" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>每日推荐</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc1:top ID="top2" runat="server" />
    <div id="main">
        <div class="box-a">
            <h5>词单列表</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="词单列表" class="t-list mt-10">
                    <tr >
                        <th width="40" >
                            &nbsp;
                        </th>
                        <th width="80" >
                           词单ID
                        </th>
                         <th width="80" >
                            词单名称
                        </th>                        
                        <th width="60">
                            词数量
                        </th>
                        <th width="60">
                            词单创建者
                        </th>
                        <th width="80">
                            创建时间
                        </th>
                        <th>
                            当前状态
                        </th>
                    </tr>
                    <asp:Repeater ID="rep_comment" runat="server" 
                        onitemdatabound="rep_comment_ItemDataBound" >
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td><asp:Literal ID="lit_wlid" runat="server" Text='<%#Eval("wl_id")%>'></asp:Literal></td>
                                <td><%#Eval("name")%></td>                                
                                <td><%#Eval("wordcount")%></td>
                                <td><%#Eval("realname")%></td>
                                <td><%#Eval("addtime")%></td>
                                <td>    <asp:DropDownList ID="ddpComment" runat="server" AutoPostBack="true" onselectedindexchanged="ddpComment_SelectedIndexChanged">
                                        <asp:ListItem Value="0">默认</asp:ListItem>
                                        <asp:ListItem Value="1">优选（3）</asp:ListItem>
                                        <asp:ListItem Value="2">今日推荐（1）</asp:ListItem>
                                        <asp:ListItem Value="3">推荐词单（3）</asp:ListItem>
                                    </asp:DropDownList>                                    
                                    <%# Comment(Eval("wl_state"))%></td>
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

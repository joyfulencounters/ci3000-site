<%@ Page Language="C#" AutoEventWireup="true" CodeFile="remark.aspx.cs" Inherits="admin_wordlist_remark" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../usercontrol/top.ascx" tagname="top" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>词单评论列表</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
    <style type="text/css">
        .style1 {
            width: 214px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:top ID="top2" runat="server" />
    <div id="Div1">
        <div class="box-a">
            <h5>搜索内容</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="搜索内容" class="t-list mt-10">
                    <tr >
                        <th class="style1" >搜索内容：</th>                        
                        <th>操作</th>
                    </tr>                    
                    <tr>
                        <td class="style1"> <asp:TextBox ID="txtbox_name" runat="server" MaxLength="8"></asp:TextBox></td>
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
            <h5>词单评论列表</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="词单评论列表" class="t-list mt-10">
                    <tr >
                        <th width="40" >
                            &nbsp;
                        </th>
                        <th width="80" >
                           评论词单
                        </th>
                         <th width="240" >
                            内容
                        </th>                        
                        <th width="80">
                            评论者
                        </th>
                        <th width="80">
                            评论时间
                        </th>                       
                        <th>
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rep_RemarkWl" runat="server" onitemcommand="rep_RemarkWl_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td><%#Eval("name")%></td>
                                <td><%#Eval("content")%></td>                                
                                <td><%#Eval("realname")%></td>
                                <td><%#Eval("addtime")%></td>
                                <td><asp:LinkButton ID="lnkbtn_del" runat="server" CommandName="wldel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%#Eval("rwl_id") %>'>删除</asp:LinkButton></td>
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

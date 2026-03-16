<%@ Page Language="C#" AutoEventWireup="true" CodeFile="keenness2.aspx.cs" Inherits="admin_sys_keenness2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../usercontrol/top.ascx" tagname="top" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>评论词单敏感词汇</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">
    <uc1:top ID="top2" runat="server" />
    <div class="box-a">
            <h5>添加评论词单敏感词汇</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t-form">                  
                    <tr>
                        <th width="100">敏感词：</th>
                        <td width="100"><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:Button CssClass="button" ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    
    <div id="main">
        <div class="box-a">
            <h5>敏感词列表</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="敏感词列表" class="t-list mt-10">
                    <tr >
                        <th width="40" >
                            &nbsp;
                        </th>                 
                         <th width="120" >
                            敏感词
                        </th>
                        <th>
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rep_solutate" runat="server" 
                        onitemcommand="rep_solutate_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td><%#Eval("Name")%></td>
                                <td><asp:LinkButton ID="lnkbtn_del" runat="server" CommandName="gdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%#Eval("id") %>'>删除</asp:LinkButton></td>
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

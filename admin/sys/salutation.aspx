<%@ Page Language="C#" AutoEventWireup="true" CodeFile="salutation.aspx.cs" Inherits="admin_sys_salutation" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../usercontrol/top.ascx" tagname="top" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>有趣方言</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">   
    <uc1:top ID="top1" runat="server" />
    <div class="box-a">
            <h5>添加方言</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="t-form">
                    <colgroup>
                        <col width="100px" />
                        <col />
                    </colgroup>
                    <tr>
                        <th scope="row">
                            分类：
                        </th>
                        <td width="350">
                            <asp:DropDownList ID="ddlstate" runat="server">
                                <asp:ListItem Selected="True" Value="1">对不起方言</asp:ListItem>
                                <asp:ListItem Value="0">打招呼方言</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th scope="row">标题：</th>
                        <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                    </tr>                    
                    <tr>
                        <th scope="row">内容：</th>
                        <td><asp:TextBox ID="txtCont" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <th scope="row">
                            &nbsp;
                        </th>
                        <td>
                            <asp:Button CssClass="button" ID="btnSave" runat="server" Text="保存" OnClick="btnSave_Click" />&nbsp;<input
                                class="button" name="" type="reset" value="取消" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    
    <div id="main">
        <div class="box-a">
            <h5>方言列表</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="方言列表" class="t-list mt-10">
                    <tr >
                        <th width="40" >
                            &nbsp;
                        </th>                 
                         <th width="120" >
                            招呼名称
                        </th>                        
                        <th width="200">
                            招呼内容
                        </th>
                        <th width="120" >
                            当前状态
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
                                <td><%#Eval("title")%></td>
                                <td><%#Eval("content")%></td>                                
                                <td><%# Comment(Eval("state"))%></td>
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

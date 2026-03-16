<%@ Page Language="C#" AutoEventWireup="true" CodeFile="keenness.aspx.cs" Inherits="admin_sys_keenness" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../usercontrol/top.ascx" tagname="top" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>敏感词汇</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:top ID="top2" runat="server" />
    <div id="main">
        <div class="box-a">
            <h5>敏感词汇</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="敏感词汇" class="t-list mt-10">
                    <tr >
                        <th width="60" >敏感词汇导入文件名称：</th>                        
                        <th>操作</th>
                    </tr>
                    <tr>
                        <td colspan="2" style="color:Red;">导入必须是EXEL 格式。Exec 数据添加在 Sheet1 文档页 首列（A列上） </td>
                    </tr>
                    <tr>
                        <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                        <td><asp:Button ID="btn_submit" runat="server" Text="导入Exel" 
                                onclick="btn_submit_Click" /></td>                        
                    </tr>
                    <tr>
                        <td colspan="2"><asp:Literal ID="lit_load" runat="server"></asp:Literal></td>
                    </tr>
                </table>
            </div>
        </div>        
    </div>
    <div id="Div1">
        <div class="box-a">
            <h5>敏感词汇列表</h5>
            <div class="pd-5">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="敏感词汇" class="t-list mt-10">
                    <tr>          
                        <th width="60" > </th>
                        <td width="200" > 搜索：<asp:TextBox ID="txt_sear" runat="server"></asp:TextBox></td>
                        <td><asp:Button ID="btn_search" runat="server" Text="搜索" 
                                onclick="btn_search_Click" /></td>                        
                    </tr>
                </table>
                
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="敏感词汇列表" class="t-list mt-10">
                    <tr >
                        <th width="40" >
                            &nbsp;
                        </th>                 
                         <th width="120" >
                            敏感词ID
                        </th>                        
                        <th width="200">
                            敏感词名称
                        </th>                        
                        <th>
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rep_keenness" runat="server" onitemcommand="rep_keenness_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td><%#Eval("k_id")%></td>
                                <td><%#Eval("name")%></td>
                                <td><asp:LinkButton ID="lnkbtn_del" runat="server" CommandName="gdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%#Eval("k_id") %>'>删除</asp:LinkButton></td>
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

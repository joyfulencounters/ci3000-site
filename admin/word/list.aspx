<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="admin_word_list" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../usercontrol/top.ascx" tagname="top" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>词列表</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
    <link rel="stylesheet" type="text/css" href="/style/ymPrompt.css" />
    <script src="../../js/ymPrompt.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        function edit(wid)
        {
            ymPrompt.win({message:'aded.aspx?id='+wid,width:500,height:300,title:'编辑词',iframe:true});
        }
        function winrload()
        {
            ymPrompt.close();
            window.location.href = window.location.href;
        }        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:top ID="top2" runat="server" />
    <div id="main">
        <div class="box-a">
            <h5>词列表</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="词列表" class="t-list mt-10">
                    <tr >
                        <th width="40" >
                            &nbsp;
                        </th>
                        <th width="80" >
                           词ID
                        </th>
                         <th width="80" >
                            词名称
                        </th>
                        <th width="80" >
                            词类型
                        </th>
                        <th width="60">
                            被收藏次数
                        </th>
                        <th width="60">
                            被引用次数
                        </th>
                        <th width="60">
                            <asp:LinkButton ID="lnkbtn_remark" runat="server" onclick="lnkbtn_remark_Click">评论次数</asp:LinkButton>
                        </th>
                        <th width="60">
                            词创建者
                        </th>
                        <th width="80">
                            <asp:LinkButton ID="lnkbtn_addtime" runat="server" 
                                onclick="lnkbtn_addtime_Click">创建时间</asp:LinkButton>
                        </th>                        
                        <th>
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rep_list" runat="server" 
                        onitemdatabound="rep_list_ItemDataBound" 
                        onitemcommand="rep_list_ItemCommand" >
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td><%#Eval("w_id")%></td>
                                <td><%#Eval("name")%></td>                                
                                <td><%#Eval("typename")%></td>
                                <td><%#Eval("collCount")%></td>
                                <td><%#Eval("remarkCount")%></td>
                                <td><%#Eval("r_amount")%></td>
                                <td><%#Eval("realname")%></td>
                                <td><%#Eval("addtime")%></td>                                
                                <td><a href="javascript:edit(<%#Eval("w_id")%>);" >编辑</a> | <asp:LinkButton ID="lnkbtn_del" runat="server" OnClientClick="return confirm('确定要删除该词下的所有信息吗？删除后无法恢复，请谨慎操作！')" CommandName="wdel" CommandArgument='<%#Eval("w_id") %>'>删除</asp:LinkButton></td>
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

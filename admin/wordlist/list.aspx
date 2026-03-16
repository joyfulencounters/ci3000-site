<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="admin_wordlist_list" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../usercontrol/top.ascx" tagname="top" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>词单列表</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
    <link rel="stylesheet" type="text/css" href="/style/ymPrompt.css" />
    <script src="../../js/ymPrompt.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        function edit(wlid)
        {
            ymPrompt.win({message:'aded.aspx?id='+wlid,width:500,height:300,title:'编辑词单',iframe:true});
        }
        function winrload()
        {
            ymPrompt.close();
            window.location.href = window.location.href;
        }        
    </script>
    <style type="text/css">
        .style1
        {
            width: 185px;
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
                        <th class="style1" >名称：</th>  
                        <th class="style1" >内容：</th>                      
                        <th>操作</th>
                    </tr>                    
                    <tr>
                        <td class="style1"> <asp:TextBox ID="txtbox_name" runat="server"></asp:TextBox></td>
                        <td class="style1"> <asp:TextBox ID="txtbox_cont" runat="server"></asp:TextBox></td>
                        <td><asp:Button ID="btn_submit" runat="server" Text="搜索" onclick="btn_submit_Click" /></td>                        
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:HiddenField ID="hideName" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>        
    </div>
    <div id="main">
        <div class="box-a">
            <h5>词单列表</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="词单列表" class="t-list mt-10">
                    <tr >
                        <th width="40" >
                            &nbsp;
                        </th>
                        <th width="60" >
                           词单ID
                        </th>
                         <th width="120" >
                            词单名称
                        </th> 
                         <th width="240" >
                            词单内容
                        </th>                         
                        <th width="60">
                            词数量
                        </th>
                        <th width="120">
                            词单创建者
                        </th>
                        <th width="80">
                            创建时间
                        </th>
                        <th>
                            当前状态
                        </th>
                        <th>
                            操作
                        </th>
                    </tr>
                    <asp:Repeater ID="rep_comment" runat="server" 
                        onitemcommand="rep_comment_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td><asp:Literal ID="lit_wlid" runat="server" Text='<%#Eval("wl_id")%>'></asp:Literal></td>
                                <td><a href="http://www.ci3000.com/wordlist.aspx?w=<%#Eval("wl_id") %>" target="_blank"><%#Eval("name")%></a></td>
                                <td><%#Eval("content")%></td>
                                <td><%#Eval("wordcount")%></td>
                                <td><%#Eval("realname")%></td>
                                <td><%#Eval("addtime")%></td>
                                <td><%# Comment(Eval("wl_state"))%></td>
                                <td><a href="javascript:edit(<%#Eval("wl_id") %>)">编辑</a> | <asp:LinkButton ID="lnkbtn_del" runat="server" CommandName="gdel" OnClientClick="return confirm('确定要删除吗？')" CommandArgument='<%#Eval("wl_id") %>'>删除</asp:LinkButton></td>
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

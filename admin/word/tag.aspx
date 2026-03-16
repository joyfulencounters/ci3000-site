<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tag.aspx.cs" Inherits="admin_word_tag" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register src="../../usercontrol/top.ascx" tagname="top" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>词TAG列表</title>
    <link rel="stylesheet" type="text/css" href="/style/admin.css" />
    <link rel="stylesheet" type="text/css" href="/style/ymPrompt.css" />
    <script src="../../js/ymPrompt.js" type="text/javascript" language="javascript"></script>
    <script language="javascript" type="text/javascript">
        function edit(wid)
        {
            ymPrompt.win({message:'aded.aspx?id='+wid,width:500,height:300,title:'编辑词',iframe:true});
        }
        function rload()
        {
            ymPrompt.close();
            window.location.reload();
        }        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:top ID="top2" runat="server" />
    <div id="main">
        <div class="box-a">
            <h5>词TAG列表</h5>
            <div class="pd-5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" summary="词TAG列表" class="t-list mt-10">
                    <tr >
                        <th width="40" >&nbsp;</th>
                        <th width="120" >词名称</th>
                        <th width="120" >TAG名称</th>
                        <th width="120" >Tag添加者</th>
                        <th width="80">Tag添加时间</th>                    
                        <th>操作</th>
                    </tr>
                    <asp:Repeater ID="rep_tag" runat="server" onitemcommand="rep_tag_ItemCommand" >
                        <ItemTemplate>
                            <tr>
                                <td></td>
                                <td><%#Eval("wordname")%></td>                                
                                <td><%#Eval("name")%></td>
                                <td><%#Eval("realname")%></td>
                                <td><%#Eval("addtime")%></td>                                
                                <td><asp:LinkButton ID="lnkbtn_del" runat="server" OnClientClick="return confirm('确定要删除吗？')" CommandName="tdel" CommandArgument='<%#Eval("wt_id") %>'>删除</asp:LinkButton></td>
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

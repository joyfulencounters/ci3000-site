<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="password.aspx.cs" Inherits="password" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
修改密码<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
    function checkEmail()
    {
        if(is_email($("#ctl00_ContentPlaceHolder1_input_mail").val()))
            return true;
        else
            return false;        
    }
</script>
    <form id="form1" runat="server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <div class="CreateWord">
                <div class="CreateWordA"><img src="images/member/member_22.png" width="209" height="19" /></div>	
                <div class="ForgotPassword">
                    <div class="Black">请输入您在注册时使用的EMAIL:</div>
                </div>		
                <div class="Black">
                    <div class="ForgotPasswordB"><input type="text" runat="server" id="input_mail" class="CreateBtten" name="n" value="你的E-mail是什么..." onfocus="if(this.value=='你的E-mail是什么...')this.value='';" /></div>
                    <div class="ForgotPasswordA">
                        <asp:ImageButton ID="imgbtn_pwd" runat="server" OnClientClick="return checkEmail()" 
                            ImageUrl="images/member/member_33.gif" onclick="imgbtn_pwd_Click" /></div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <div class="CreateWord">
                <div class="CreateWordA"><img src="images/member/member_22.png" width="209" height="19" /></div>	
                <div class="ForgotPassword">
                    <div class="Black">我们已经将您的注册信息发送到<span class="Red"><asp:Literal ID="lit_mail" runat="server"></asp:Literal></span>，请登陆邮箱查收密码。</div>
                </div>		
                <div class="Black">
                    <div class="ForgotPasswordB"><a href="/"><img src="images/member/member_25.gif" width="69" height="25" border="0" alt="" /></a></div>
                </div>
            </div>
        </asp:View>
        <asp:View ID="View3" runat="server">
            <div class="CreateWord">
                <div class="CreateWordA"><img src="images/member/member_22.png" width="209" height="19" /></div>	
                <div class="ForgotPassword">
                    <div class="Black">邮件发送失败请稍候重试。<span class="Red"><a href="/">返回首页</a></span></div>
                </div>		
                <div class="Black">
                    <div class="ForgotPasswordB"><a href="/"><img src="images/member/member_25.gif" width="69" height="25" border="0" alt="" /></a></div>
                </div>
            </div>
        </asp:View>
    </asp:MultiView>
    </form>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="Set.aspx.cs" Inherits="user_Set" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
个人信息修改<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script language="javascript" type="text/javascript">
var setInfo = {upPwd:false,upName:false};
function funClick() {
//    if(getExplorer() == "MSIE")
//        $("#ctl00_ContentPlaceHolder1_file_upload").click();
//    else
        $("#sp_fileUp").show();     
}
function UpdatePwd()
{
    $("#ul_pwd").slideToggle("fast",function(){
    if(document.getElementById("ul_pwd").style.display =="none"){
        setInfo.upPwd = false;
        $("#ctl00_ContentPlaceHolder1_txt_pwdold").val("");
        $("#ctl00_ContentPlaceHolder1_txt_pwdnew").val("");
        $("#ctl00_ContentPlaceHolder1_txt_pwdagain").val("");
    }else{setInfo.upPwd = true;}});
}
function UpdateName()
{
    $("#div_name").slideToggle("fast",function(){
        if(document.getElementById("div_name").style.display =="none"){$("#ctl00_ContentPlaceHolder1_txt_NewName").val("");setInfo.upName = false;}
        else{setInfo.upName = true;}});
}
function Chk_Name() {
    if(!is_name($("#ctl00_ContentPlaceHolder1_txt_NewName").val())) {alert("请正确输入您的昵称"); return false; }
    else{ return true;}
}
function CheckUserInfo()
{   
    if(setInfo.upName) {if(!Chk_Name()) return false;}
    if(setInfo.upPwd) { 
        if(is_empty($("#ctl00_ContentPlaceHolder1_txt_pwdold").val())){
            alert("输入原密码");return false;}               
        if(!Chk_PwdOne()) return false;
        if(!Chk_Pwd_Again()) return false;
    }return true;
}
function Chk_PwdOne() {
    if ( StringTrim($("#ctl00_ContentPlaceHolder1_txt_pwdnew").val()).length < 6) {
        alert("密码必须不得小于6位");
        return false;
    }else{return true;}
}
function Chk_Pwd_Again()
{
    var obj = $("#ctl00_ContentPlaceHolder1_txt_pwdagain").val();    
    if ($("#ctl00_ContentPlaceHolder1_txt_pwdnew").val() != obj) {
        alert("2次密码不一致");
        return false;
    }else {
        if(!is_empty(obj))
            return true;        
        else             
            return false;        
    }
}
function UserPicChange() {
    var filename = $("#ctl00_ContentPlaceHolder1_file_upload").val();
    if(StringTrim(filename) != "")
        $("#ctl00_ContentPlaceHolder1_User_Img").attr("src",filename);
    else    {
        //随机图
    }
}
</script>
<form runat="server" id="form1">
<div class="CreateWord" style="background-color:#fff; background-image:url(../images/word/word_bg_05.gif), linear-gradient(#fff, #fff);">
    <!--<span style="border:1px blue solid; line-height:30px;"><a href="/user/set.aspx">修改密码</a></span>-->
	<div class="CreateWordA1">
		<div style="width:99px; float:left;">
            <div class="Autographedphotos" style="margin-bottom:10px; border-radius:0; width:80px; height:80px; border:1px solid #ccc; padding:5px; box-sizing:content-box;"><img runat="server" id="User_Img" src="/images/word/img_photo.gif" style="border-radius:0;"/></div>
            <div style="text-align:center;"><a href="/user/face.aspx"><img title="修改头像" src="/images/word/word_67.gif" /></a></div>
            <!--<div><img src="/images/member/member_05.gif" /><a href="javascript:;" onclick="funClick()">修改签名照</a></div>-->
        </div>    
        <div style="float:left; margin-left:20px; margin-top:20px;">
            <div style="float:left;"><asp:Literal ID="lit_Msg" runat="server"></asp:Literal></div>
            <div class="Blue" style="float:left;"><asp:Literal ID="lit_username" runat="server"></asp:Literal></div>
		</div>
		<div id="sp_fileUp" style="width:100%; clear:both; display:none;"><asp:FileUpload ID="file_upload" runat="server" onchange="UserPicChange()" /></div>
  </div>
 <div style="clear:both; line-height:50px;">
	<div class="Black">登录email：<span class="Gray"><asp:Literal ID="lit_email" runat="server"></asp:Literal>                   　　　　　登录email不可修改</span></div>	
	<div class="Black">登录密码：***********                  　　　　　　　　　　　<span class="Name"><a href="javascript:UpdatePwd();">修改密码</a></span>
	    <ul id="ul_pwd" style="display:none; background:#f2f2f2; padding-left:20px; font-size:12px;">
	        <li>输入原密码：<asp:TextBox ID="txt_pwdold" CssClass="InputTxtBox" runat="server" TextMode="Password" MaxLength="25"></asp:TextBox></li>
	        <li>输入新密码：<asp:TextBox ID="txt_pwdnew" CssClass="InputTxtBox" runat="server" TextMode="Password" MaxLength="25"></asp:TextBox><span id="sp_pwd1" style="color:Red">　* 该密码是您用于登录本网站的密码，不是您的email的密码哦!至少6位数字或字母组合</span></li>
	        <li>再确认一次：<asp:TextBox ID="txt_pwdagain" CssClass="InputTxtBox" runat="server" TextMode="Password" MaxLength="25"></asp:TextBox><span id="sp_pwd2" style="color:Red">　* 请再输入一遍上面的密码</span></li>
	    </ul>
	</div>	
	<div class="Black" style="width:350px;">昵称：<asp:Literal ID="lit_OldName" runat="server"></asp:Literal>                　　　　　　　　　　　<span class="Name"><a href="javascript:UpdateName();" >修改昵称</a></span></div>
    
	<div id="div_name" style="display:none; color:#000; background:#f2f2f2; padding-left:20px;">输入新昵称：<asp:TextBox ID="txt_NewName" CssClass="InputTxtBox" runat="server" MaxLength="20"></asp:TextBox>
	    <span id="sp_name" style="color:Red;">　* 昵称只能由汉字或数字及英文字母组成</span></div>
	<div style="line-height:60px; margin-top:10px;">        
        <asp:ImageButton ID="imgbtn_submit" runat="server" ImageUrl="/images/word/word_68.gif" OnClientClick="return CheckUserInfo()" onclick="imgbtn_submit_Click" />
	</div>
  </div>
  	
</div>
</form>
</asp:Content>


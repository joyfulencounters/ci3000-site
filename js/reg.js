
var obj = null;
var chkEmail = false;
var RegMess = new Array(
    "<img src=\"/images/member/member_10.gif\" width=\"16\" height=\"16\" /> 该EMAIL地址将作为您的登录名，请真实填写，用于找回密码，一旦确认不可修改",   //默认（未输入）时显示
    "<img src=\"/images/member/accept.png\" width=\"16\" height=\"16\" />",               //正确
    "<img src=\"/images/member/delete.png\" width=\"16\" height=\"16\" /> <font color: \"red\">请输入合法的Email</font>",               //错误的email
    "<img src=\"/images/member/delete.png\" width=\"16\" height=\"16\" /> 当前电子邮箱已被注册，请重新输入",           //EMAIL已经被注册
    "<img src=\"/images/member/member_10.gif\" width=\"16\" height=\"16\" /> 昵称只能由汉字或数字及英文字母组成，请正确填写此昵称将作为您的网站中对外的显示名称",   //
    "<img src=\"/images/member/delete.png\" width=\"16\" height=\"16\" /> 昵称只能由汉字或数字及英文字母组成。",   //未填写真实姓名时显示
	"<img src=\"/images/member/member_10.gif\" width=\"16\" height=\"16\" /> 该密码是您用于登录本网站的密码，不是您的email的密码哦!至少6位数字或字母组合",   //默认（未输入）时显示
	"<img src=\"/images/member/delete.png\" width=\"16\" height=\"16\" /> 密码太过简单",
	"<img src=\"/images/member/member_10.gif\" width=\"16\" height=\"16\" /> 请再输入一遍上面的密码",
	"<img src=\"/images/member/delete.png\" width=\"16\" height=\"16\" /> 您两次输入的密码不一致，请重新填写",
	"<img src=\"/images/member/delete.png\" width=\"16\" height=\"16\" /> 请先同意千言万语注册协议"
);

function Chk_Email_Before()
{
    chkEmail = false;
    $("#sp_email").html(RegMess[0]);
}

function Chk_Email() {
    obj = $("#txt_email").val();    
    if (!is_email(obj)) {        
        $("#sp_email").html(RegMess[2]);
        return false;
    } 
    $.get("/Ajax/AjaxGet.aspx",{ Rid: Math.random(),Action:'ChKEm',email:escape(obj) },
        function(Msg) {                     
            if (Msg == "False") {
                $("#sp_email").html(RegMess[3]);
                chkEmail = false;
                return false;
            }
            else {
                $("#sp_email").html(RegMess[1]);
                chkEmail = true;
                return true;
            }
    });      
    $("#sp_email").html("验证中...");
    return false;
}

function Chk_Name_Before(){
    $("#sp_name").html(RegMess[4]);
}

function Chk_Name() {
    obj = $("#txt_name").val();
    if(!is_name(obj)) {
        $("#sp_name").html(RegMess[5]);
        return false;
    }
    else{
        $("#sp_name").html(RegMess[1]);
        return true;
    }
}

function Chk_PwdOne_Before() {
    $("#sp_pwd1").html(RegMess[6]);
}

function Chk_PwdOne() {
    obj = $("#txt_pwd1").val();
    if ( StringTrim(obj).length < 6) {        
        $("#sp_pwd1").html(RegMess[7]);
        return false;
    }
    else{
        $("#sp_pwd1").html(RegMess[1]);
        return true;
    }    
}

function Chk_Pwd_AgainBef() {
    $("#sp_pwd2").html(RegMess[8]);
}

function Chk_Pwd_Again()
{
    obj = $("#txt_pwd2").val();    
    if ($("#txt_pwd1").val() != obj) {
        $("#sp_pwd2").html(RegMess[9]);
        return false;
    }
    else {
        if(!is_empty(obj)) {
            $("#sp_pwd2").html(RegMess[1]);
            return true;
        }
        else {
            $("#sp_pwd2").html("");            
            return false;
        }
    }
}

function Chk_Agreement() {
    if(!$("#checkbox").attr("checked")) {
        $("#sp_agree").html(RegMess[10]);
        return false;
    }
    else{
        $("#sp_agree").html("");
        return true;
    }    
}

// 表单数据验证
function do_validation() {    
    var ck = true;            
    if (!Chk_Name()) { ck = false; }
    if (!Chk_PwdOne()) { ck = false; }
    if (!Chk_Pwd_Again()) { ck = false; }  
    if (!Chk_Agreement()) { ck = false; }
    if (!chkEmail) { ck = false; }
    return ck;
}

function funClick() {
//    if(getExplorer() == "MSIE")
//        $("#file_upload").click();
//    else
        $("#sp_fileUp").show();     
}

function UserPicChange() {
    var filename = $("#file_upload").val();
    if(StringTrim(filename) != "")
        $("#User_Img").attr("src",filename);
    else    {
        //随机图
    }
}
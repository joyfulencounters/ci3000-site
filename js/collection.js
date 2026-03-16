function is_word(str_input) {
    var reg = /^[\u4e00-\u9fa5]+$/;
    return reg.test(str_input);
}

function StringTrim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}

function Onkeyup(input_id){
    var word = StringTrim($("#"+input_id).val());
    $("#"+input_id).val(word);
    $("#div_wordType").hide();
}

function WordCheck() {
    if(!CkLogin(uid)) return;
    var str_input = $("#Input_word").val(); 
    if(is_word(str_input))  {        
        $.post("/Ajax/AjaxPost.aspx",{ Rid: Math.random(),Action:'CHKWordColl',name:escape(str_input),uID:uid },
            function(Msg) {
                if (Msg == "True") {
                    $("#sp_load").hide();
                    alert("收藏成功！");
                    window.location.href = "/user/collection.aspx?u="+uid;
                }
                else if(Msg == "Go")
                {
                    alert("您是第一个创建该词的人!");
                    $("#sp_load").hide();
                    $("#div_wordType").slideDown("slow");
                }
                else
                {
                    $("#sp_load").hide();
                    alert(Msg);
                }
        });
        $("#sp_Vili").hide();
        $("#sp_load").show();//load...
        $("#div_wordType").hide();
    }
    else
    {
        $("#sp_Vili").show();
        $("#div_wordType").hide();
    }
}

function WordCollection(uid,tid) {
    if(!CkLogin(uid)) return false;
    var name = $("#Input_word").val();
    var txtContent = "";
    $.post("/Ajax/AjaxPost.aspx",{ Action: "WordColl",name:escape(name), txtCont:escape(txtContent),tID:tid,uID:uid },
            function(Msg){
                if(Msg=="True"){                                   
                    $("#div_wordType").hide();                    
                    alert("收藏成功！");
                    window.location.href = "/user/collection.aspx?u="+uid;
                }
                else  {
                    $("#div_wordType").hide();
                    alert("收藏失败！");
                }
            });
    
}

function CkLogin(uid)
{
    if(parseInt(uid) > 0) {
        return true;
    }
    else {
        //alert("您还未登录先登录去");
        ymPrompt.win({message:'/login/log.aspx',width:500,height:300,title:'登录',iframe:true});
        return false;        
    }
}
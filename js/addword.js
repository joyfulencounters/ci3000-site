var word = {wlid:0,type:'true'};

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
        $.get("/Ajax/AjaxGet.aspx",{ Rid: Math.random(),Action:'CHKWdn',name:escape(str_input),uID:uid,wlID:word.wlid },
            function(Msg) {
                $("#sp_load").hide();
                if (Msg == "True") {                    
                    $("#div_wordType").slideDown("slow");
                }
                else if(Msg == "TrueEnd")  {
                    $("#div_wordType").hide();
                    alert("添加成功！");
                    Whow_Word_Page(word.type,word.wlid,1);
                }
                else {   
                    alert(Msg);
                }
        });
        $("#sp_Vili").hide();
        $("#sp_load").show();//load...
    }
    else {
        $("#sp_Vili").show();
        $("#div_wordType").hide();
    }
}
function WordAdd(uid,tid,wlid) {
    if(!CkLogin(uid)) return false;    
    var name = $("#Input_word").val();
    var txtContent = "";
    $.post("/Ajax/AjaxPost.aspx",{ Action: "WdnAdd",name:escape(name), txtCont:escape(txtContent),tID:tid,uID:uid,wlID:wlid },
            function(Msg){
                if(Msg=="True"){
                    //列表重绑定                                        
                    $("#div_wordType").hide();                    
                    alert("添加成功！");                    
                    Whow_Word_Page(word.type,word.wlid,1,'true');
                }
                else  {
                    $("#div_wordType").hide();
                    alert("添加失败！");
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
function Whow_Word_Page(type,wlid,pIndex,add)
{
    if(add == 'true') pIndex = parseInt($("#pagecount").html());
    $("#pages").html("");    
    $("#ShowList").html("<img src=\"/images/load.gif\" />");
    if(type == "true") {
        word.type = "true";
        $("#pl > img").attr("src","images/word/word_22.gif");
        $("#lb > img").attr("src","images/word/word_21.gif");
    }
    else {
        word.type = "false";        
        $("#pl > img").attr("src","images/word/word_23.gif");
        $("#lb > img").attr("src","images/word/word_24.gif");
    }
    $.get("/Ajax/AjaxGet.aspx",{ Rid: Math.random(),Action:'WordList_WordPage',Type:type,Wlid:wlid,PageIndex:pIndex },
            function(Msg) {             
                $("#ShowList").html(Msg);
                var Count = parseInt($("#pagecount").html());
                if(word.type=="true")
                    ShowPage(Count, 60, pIndex);
                else
                    ShowPage(Count, 10, pIndex);
        });    
}
function CurrentPage(count, pSize, pIndex) {
    Whow_Word_Page(word.type, word.wlid, pIndex);
    //alert("word.type=" + word.type + "| word.wlid=" + word.wlid + "| count=" + count + "| pSize=" + pSize);
}
function wlcDel(wid,wlid,uid){
    if(confirm("您确定要删除该词吗？")){
    $.get("/Ajax/AjaxGet.aspx",{ Rid: Math.random(),Action:'Word_Del',Wid:wid, Wlid:wlid,Uid:uid },
            function(Msg) {             
                Whow_Word_Page(word.type, word.wlid, 1);
        });
    }    
}
function wlconmouseover(id){
    $("#showaid_"+id).show();
}
function wlconmouseout(id){
    $("#showaid_"+id).hide();
}

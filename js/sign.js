
function CkSign(uid)
{
    //未登录 0 登录别人'' 0 > && != '' 自己的
    if(uid > 0){}else{return false}         
    var sg = "懒家伙，什么感言都没有留下...点击写下心情，快点！";
    var ThisSg = $("#sp_sign").text();
    if(StringTrim(ThisSg) == sg)
        $("#div_sign").html("<input id=\"input_sign\" type=\"text\" onblur=\"EdtSign("+uid+")\" size=\"30\" name=\"input_sign\" maxlength=\"100\" value=\"\" />");    
    else
        $("#div_sign").html("<input id=\"input_sign\" type=\"text\" onblur=\"EdtSign("+uid+")\" size=\"30\" name=\"input_sign\" maxlength=\"100\" value=\""+ThisSg+"\" />"); 
        
    $("#input_sign").focus();          
}
function EdtSign(uid)
{
    if(!CkLogin(uid)) return false;    
    var sign = $("#input_sign").val();    
    if(StringTrim(sign)==''){ $("#div_sign").html("<span id=\"sp_sign\" onclick=\"CkSign("+uid+")\" >懒家伙，什么感言都没有留下...点击写下心情，快点！</span>");return false;}        
    $.post("/Ajax/AjaxPost.aspx",{ Action: "FeelEdt",txtCont:escape(sign),uID:uid },
            function(Msg){$("#div_sign").html("<span id=\"sp_sign\" onclick=\"CkSign("+uid+")\" >"+sign+"</span>");});
}

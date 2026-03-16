var word = {uid:0,wid:0};
    function CheckUser()
    {   
        if(parseInt(word.uid) <= 0){
            ymPrompt.win({message:'/login/log.aspx',width:350,height:200,title:'登录',iframe:true});
            return false;
         }
         else {            
            return true;            
         }
    }
    function BeforeWordAdd()
    {
        if(CheckUser()) {
            var cont = $("#emid").html();
            ymPrompt.win({message:cont,width:700,height:400,title:'添加到词单'});
        }
    }
    function word_add(wlid)
    {
        if(CheckUser()) {        
            $.get("/Ajax/AjaxGet.aspx",{ Rid: Math.random(),Action:'WdAdd',wID:word.wid,wlID:wlid,uID:word.uid },
            function(Msg) {
                if( parseInt(Msg) == -1) 
                    alert("已收入过该词了");
                else if(parseInt(Msg) > 0)
                    window.location.href = "/wordlist.aspx?w="+wlid;
                    //alert("成功收入到词单中");
            });            
        }
    }    
    function word_collection(wid)
    {    
        if(CheckUser())  {           
            $.get("/Ajax/AjaxGet.aspx",{ Rid: Math.random(),Action:'WdColl',wID:word.wid,uID:word.uid },
            function(Msg) {                
                if(parseInt(Msg) == 1)
                {
                    $("#ctl00_ContentPlaceHolder1_hplnk_collection img").attr("src","/images/word/3.gif");
                    $("#divCname").append("<img id=\"ctl00_ContentPlaceHolder1_ImgHeart\" src=\"/images/word/heart.png\" style=\"border-width:0px;\" />");                    
                }
                else if(parseInt(Msg) == -1)
                {
                    $("#ctl00_ContentPlaceHolder1_hplnk_collection img").attr("src","/images/word/2.gif");
                    $("#ctl00_ContentPlaceHolder1_ImgHeart").remove(); 
                }                
            });
        }
    }    
    function StringTrim(str) {
        return str.replace(/(^\s*)|(\s*$)/g, "");
    }    
    function Onkeyup(input_id){
        var word = StringTrim($("#"+input_id).val());
        $("#"+input_id).val(word);
    }    
    function Tag_add()
    {        
        var tag = $("#txt_Tag").val();
        if (StringTrim(tag) == "" || StringTrim(tag) == "我对这个词的感觉是…") {
            $("#txt_Tag").val("");
            alert("您对该词的感觉是...");
            return;                      
        }
        if(CheckUser())  {
            $.post("/Ajax/AjaxPost.aspx",{ Action:'TagAdd',name: escape(tag) ,wID:word.wid,uID:word.uid},
            function(Msg) {
                if(parseInt(Msg) == 0)
                    alert("存在或添加失败！");
                else if(parseInt(Msg) == -1)
                    alert("很抱歉，过敏性词不允许添加！"); 
                else{                    
                    $(".MeaningWordD").append("<a class=\"MeaningWordTag\" href=\"/search/wordTagSear.aspx?sear="+escape(tag)+"\">"+tag+"</a>");
                    $("#txt_Tag").val("");
                }                        
            });
        }
    }        
    
function getExplorer() { 
    var OsObject = ""; 
    if(navigator.userAgent.indexOf("MSIE")>0) { 
         return "MSIE"; 
    } 
    if(isFirefox=navigator.userAgent.indexOf("Firefox")>0){ 
         return "Firefox"; 
    } 
    if(isSafari=navigator.userAgent.indexOf("Safari")>0) { 
         return "Safari"; 
    } 
    if(isCamino=navigator.userAgent.indexOf("Camino")>0){ 
         return "Camino"; 
    } 
    if(isMozilla=navigator.userAgent.indexOf("Gecko/")>0){ 
         return "Gecko"; 
    }   
}
function CheckInt(String) { 
    var Letters = "1234567890"; 
    var i;var c; 
    for( i = 0; i < String.length; i ++ ){ 
        c = String.charAt( i ); 
        if (Letters.indexOf( c ) ==-1) return false;        
    } 
    return true; 
} 
function StringTrim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}
function is_email(str_input) {
    var re = /^([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\-|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
    return re.test(str_input);
}
function is_name(str_input) {
    var reg = /^[\u4e00-\u9fa5\A-Za-z0-9]+$/;
    return reg.test(str_input);
}
function is_empty(v_input) {
    if (typeof (v_input) != "string") return false;
    if (StringTrim(v_input).length > 0) return false;
    else return true;
}
function CkLogin(uid){
    if(parseInt(uid) > 0) {
        return true;        
    }
    else {
        //alert("您还未登录先登录去");
        ymPrompt.win({message:'/login/log.aspx',width:500,height:300,title:'登录',iframe:true});
        return false;
    }
}
function DrawImage(ImgD,width,height){  
    var image  = new Image();  
    var iwidth = width;           //允许图片宽度  
    var iheight= height;           //允许图片高度 
	image.src = ImgD.src;  
	if(image.width > 0 && image.height > 0){  
		flag=true;  
	if(image.width/image.height >= iwidth/iheight){  
		if(image.width>iwidth){            
			ImgD.width=iwidth;  
			ImgD.height=(image.height*iwidth)/image.width;  
		}else{  
			ImgD.width=image.width;            
			ImgD.height=image.height;  
		}  
			ImgD.alt='http://www.ci3000.com';  
	}else{  
		if(image.height>iheight){            
			ImgD.height=iheight;  
			ImgD.width=(image.width*iheight)/image.height;    
		}else{  
			ImgD.width=image.width;            
			ImgD.height=image.height;  
		}  
			ImgD.alt='http://www.ci3000.com';  
		}
	} 
}






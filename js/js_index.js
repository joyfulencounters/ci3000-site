//ËÑË÷JS

function drop_mouseover(pos){

 try{window.clearTimeout(timer);}catch(e){}

}

function drop_mouseout(pos){

 var posSel=document.getElementById(pos+"Sel").style.display;

 if(posSel=="block"){

  timer = setTimeout("drop_hide('"+pos+"')", 1000);

 }

}

function drop_hide(pos){

 document.getElementById(pos+"Sel").style.display="none";

}

function search_show(pos,searchType,href){

    document.getElementById(pos+"SearchType").value=searchType;

    document.getElementById(pos+"Sel").style.display="none";

    document.getElementById(pos+"Slected").innerHTML=href.innerHTML;

    document.getElementById(pos+'q').focus();

    var sE = document.getElementById("searchExtend");

    if(sE != undefined  &&  searchType == "bar"){

     sE.style.display="block";

    }else if(sE != undefined){

     sE.style.display="none";

    }

 try{window.clearTimeout(timer);}catch(e){}

 return false;

}

//Í¼Æ¬ÇÐ»»
  function jiaohuan(){
   document.getElementById('im').src="/images/word/words_02.png";
   }
   function huanyuan(){
    document.getElementById('im').src="/images/word/words_01.png";
    }





//Í¼Æ¬ÇÐ»»¶þ
function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}







var page = {
    CountPage: 10,
    pageIndex: 1,
    pageSize: 15
};

function ShowPage(CountPage,PageSize,CurentPage)
	{
	    if(parseInt(CountPage) <= 1) return;
	    var tempHTML = "";
	    if (CountPage <= PageSize) {   
			if(CurentPage>1){
				tempHTML = '<span class="previous"><a href="javascript:CurrentPage(' + CountPage + ',' + PageSize + ',1)">首页</a></span><span class="previous"><a href="javascript:CurrentPage('+CountPage+','+PageSize+','+eval(CurentPage-1)+')">上一页</a></span>';
			}
			else{			
				tempHTML = '<span class="previous"><a href="javascript:void(0);">首页</a></span><span class="previous"><a href="javascript:void(0);">上一页</a></span>'
			}			
			for(var i=1;i<=CountPage;i++) //循环分页数据
			{
				if(i==CurentPage){
					tempHTML = tempHTML+'<span  class="previous"> <a href="javascript:void(0);">'+i+'</a></span>';
				}
				else {
				    tempHTML = tempHTML+'<span><a href="javascript:CurrentPage('+CountPage+','+PageSize+','+i+')">'+i+'</a></span>';
				}
			}
			if(CurentPage<CountPage){
			    tempHTML = tempHTML + '<span class="next"><a href="javascript:CurrentPage(' + CountPage + ',' + PageSize + ',' + eval(CurentPage + 1) + ')">下一页</a></span><span class="next"><a href="javascript:CurrentPage(' + CountPage + ',' + PageSize + ',' + CountPage + ')">尾页</a></span>';
			}
			else{
			    tempHTML = tempHTML + '<span class="next"><a href="javascript:void(0);">下一页</a></span><span class="next"><a href="javascript:void(0);">尾页</a></span>';
			}
			$("#pages").html(tempHTML);			
			return;
		}
		//头
		if(CurentPage>1){
				tempHTML = '<span class="previous"><a href="javascript:CurrentPage(' + CountPage + ',' + PageSize + ',1)">首页</a></span><span class="previous"><a href="javascript:CurrentPage('+CountPage+','+PageSize+','+eval(CurentPage-1)+')">上一页</a></span>';
		}
		else{
			tempHTML = '<span class="next"><a href="javascript:void(0);">首页</a></span><span class="next"><a href="javascript:void(0);">上一页</a></span>';
		}
		if(CurentPage==1){
			tempHTML = tempHTML+'<span class="next"><a href="javascript:void(0);">1</a></span>';
		}
		else{			
			tempHTML = tempHTML+'<span><a href="javascript:CurrentPage('+CountPage+','+PageSize+',1)">1</a></span>';
		}		
		var LeftCount=0;
		var RightCount=0;
		var IfDOT_L=0;
		var IfDOT_R=0;
		var middle = parseInt(PageSize/2);
		LeftCount=CurentPage-1;
		RightCount = CountPage - CurentPage;
		
		if((LeftCount>middle)&&(RightCount>middle))
		{
			LeftCount = middle;
			RightCount= PageSize-1-LeftCount;
			IfDOT_L=1;
			IfDOT_R=1;
		}
		else {		    
			if(LeftCount<RightCount) {			   
				if(LeftCount>parseInt(PageSize/2)){
					LeftCount = parseInt(PageSize/2);
				}
				RightCount = PageSize-1-LeftCount;
			}
			else {			    
				if(RightCount>parseInt(PageSize/2)){
					RightCount = parseInt(PageSize/2);
				}
				LeftCount = PageSize-1-RightCount;
            }
             if (CurentPage - 1 > LeftCount) {
				        IfDOT_L=1;
			 }
			 if (CountPage - CurentPage > RightCount) {
				        IfDOT_R=1;
				    }		    
        }

		//左侧
		if(IfDOT_L==1) {		    
			tempHTML = tempHTML+"<span>...</span>";
			for(i=CurentPage-LeftCount+2;i<CurentPage;i++)
			{
				tempHTML = tempHTML+'<span><a href="javascript:CurrentPage('+CountPage+','+PageSize+','+i+')">'+i+'</a></span>';
			}
		}
		else {		    
			for(i=2;i<CurentPage;i++)
			{
				tempHTML = tempHTML+'<span><a href="javascript:CurrentPage('+CountPage+','+PageSize+','+i+')">'+i+'</a></span>';
			}
		}
		
		//当前页		
		if(CurentPage!=1&&CurentPage!=CountPage)
		{
			tempHTML = tempHTML+'<span class="next"><a href="javascript:void(0);">'+CurentPage+'</a></span>';
		}
		//右侧
		if(IfDOT_R==1)
		{			
			for(i=CurentPage+1;i<CurentPage+RightCount-1;i++)
			{
				tempHTML = tempHTML+'<span><a href="javascript:CurrentPage('+CountPage+','+PageSize+','+i+')">'+i+'</a></span>';
			}
			tempHTML = tempHTML+"<span>...</span>";
		}
		else
		{
			for(i=CurentPage+1;i<CurentPage+RightCount;i++)
			{
				tempHTML = tempHTML+'<span><a href="javascript:CurrentPage('+CountPage+','+PageSize+','+i+')">'+i+'</a></span>';
			}
		}
		
		//尾
		if(CurentPage==CountPage){
		    tempHTML = tempHTML + '<span class="next"><a href="javascript:void(0);">' + CountPage + '</a></span>';
		}
		else{
		    tempHTML = tempHTML+'<span><a href="javascript:CurrentPage('+CountPage+','+PageSize+','+CountPage+')">'+CountPage+'</a></span>';
		}
		if(CurentPage<CountPage){
		    tempHTML = tempHTML + '<span class="next"><a href="javascript:CurrentPage(' + CountPage + ',' + PageSize + ',' + eval(CurentPage + 1) + ')">下一页</a></span><span class="next"><a href="javascript:CurrentPage(' + CountPage + ',' + PageSize + ',' + CountPage + ')">尾页</a></span>';
		}
		else{
			tempHTML = tempHTML+'<span class="next"><a href="javascript:void(0);">下一页</a></span><span class="next"><a href="javascript:void(0);">尾页</a></span>';
		}
		$("#pages").html(tempHTML);		
	}
	

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addworlist.aspx.cs" Inherits="iframe_addworlist" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加词单</title>
    <link href="/style/css.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery-1.3.2.min.js" language="javascript" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" >
        function addwordlist(){
            var uid = <%=uc.UserID %>;    
            try{ if(!parent.CkLogin()){return false;}}
            catch(e){ return;}            
            var name = $("#txt_name").val();
            var txtContent = $("#txt_content").val();
            $.post("/Ajax/AjaxPost.aspx",{ Action: "WdltCreate",Name:escape(name), txtCont:escape(txtContent),uID:uid },
                    function(Msg){
                        if(parseInt(Msg) > 0)
                        {
                            var ddp = parent.document.getElementById("ctl00_ContentPlaceHolder1_ddpwordlist");
                            if(ddp == null||ddp == '' || ddp == 'underfind')
                            {
                                parent.$("#input_newwl").before("<div id=\"ctl00_ContentPlaceHolder1_Panel1\"><select name=\"ctl00$ContentPlaceHolder1$ddpwordlist\" id=\"ctl00_ContentPlaceHolder1_ddpwordlist\"><option value=\""+ 
                                                                  Msg +"\" selected='true'>"+ name +"</option></select><input id=\"btn_Addwl\" type=\"button\" value=\"加入词单\" onclick=\"InWordListAdd();\" /></div>");                                
                            }
                            else
                            {
                                var option = new Option(name, Msg);   
                                ddp.options.add(option);
                                option.selected = true;
                            }
                            parent.Wordadd.Wlid = Msg;
                        }
                        else{   
                            alert("创建失败！");
                        }
                        parent.ymClose();                        
                    });
        }
    </script>    
</head>
<body>
    <form id="form1" runat="server">
    <div class="CreateWord">
	    <div class="CreateWordA"><img id="img_show" src="/images/word/word_20.png" alt="" /></div>
	    <div>
		    <div class="CreateWordB">
			    <div class="Black CreateWordC">词单名称：</div>
			    <span><input type="text" id="txt_name" class="CreateBtten" name="n" value="喜欢的名字" onfocus="if(this.value=='喜欢的名字')this.value='';" /></span>		
		    </div>		
		    <div class="CreateWordB1">
		    <div class="Black CreateWordC">词单描述：</div>
		    <span><textarea name="textarea" id="txt_content" class="CreateBtten1" onfocus="if(this.value=='至少……')this.value='';" >至少……</textarea>
		    </span>		
		    </div>    		
		    <div class="CreateWordD"><input id="btn_addwordlist" type="button" value="创建词单" onclick="addwordlist()" /></div>	
	    </div>
    </div>
    </form>
</body>
</html>

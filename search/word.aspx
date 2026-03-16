<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="word.aspx.cs" Inherits="search_word" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
词搜索<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link href="/style/ymPrompt.css" rel="stylesheet" type="text/css" />
<script language="javascript" type="text/javascript">
var Wordadd = {Tid:0,Wlid:0,Name:''};
function SelType(tid,name)
{
    Wordadd.Tid = tid;    
    Wordadd.Name = $("#"+'<%=lbl_Name.ClientID %>').text();
    $("#sp_type").text("该词属于："+ name);
    $("#sp_add").show();    
}
function WordAdd()//添加词
{
    var uid = <%=uc.UserID %>;
    if(!CkLogin()) return false;    
    var txtContent = "";
    $.post("/Ajax/AjaxPost.aspx",{ Action: "WdnIn",name:escape(Wordadd.Name), txtCont:escape(txtContent),tID:Wordadd.Tid,uID:uid },
            function(Msg){
                if(Msg=="True"){
                    alert("添加成功！");
                    $("#div_Next").show();
                }
                else  {                    
                    alert("很抱歉敏感词汇不允许添加！");
                }
            });
}
function InWordListAdd() //词入词单
{
    var uid = <%=uc.UserID %>;
    if(!CkLogin()) return false;
    Wordadd.Wlid = $("#ctl00_ContentPlaceHolder1_ddpwordlist").val();        
    $.post("/Ajax/AjaxPost.aspx",{ Action: "WInWdlt",name:escape(Wordadd.Name), wlid:Wordadd.Wlid,uID:uid },
            function(Msg){                
                window.location.href="/wordlist.aspx?w="+Wordadd.Wlid;
            });
}
function CkLogin()
{    
    var uid = <%=uc.UserID %>;
    if(parseInt(uid) <= 0) {
        ymPrompt.win({message:'/login/log.aspx',width:500,height:300,title:'登录',iframe:true});
        return false;
    }
    else
    {
        return true;
    }
}
function ymClose(){
    ymPrompt.close();
}
function ShowBox(){
    ymPrompt.win({message:'/iframe/addworlist.aspx',width:1000,height:600,title:'创建词单',iframe:true})
}
</script>
<form runat="server" id="form1">
<div class="CreateWord1">
  <div class="MeaningWordA" style="width:880px">
      <asp:Label ID="lbl_Name" runat="server">千言万语</asp:Label>   
      </div>      
  <div class="Black">
		  <div class="CreateWord1A"><img src="/images/member/accept.png" width="16" height="16"/> 这个词尚未存在于<span class="Word">千言万语</span>网站。你愿意成为第一个添加它的人吗？</div>
		  <div><img src="/images/word/word_58.gif"/></div>
  </div>
</div>

<div id="MainBoxSearch">
  <div>
    <div class="CreateWordB">
      <div class="Black CreateWordC1">我认为这个词属于：</div>
      <span style=" height:200px; clear:both; background:#f3f3f3; line-height:30px; background:#FFF; color:#000;"><asp:Literal ID="lit_wordTypeList" runat="server">没有分类</asp:Literal></span> 
      <br />
      <div id="sp_add" style="display:none;"><span id="sp_type"></span>
       　 <input id="btn_submit" type="button" value="添加" onclick="WordAdd();" />
        </div>
      </div>
    <div id="div_Next" style="display:none;">         
    <div class="CreateWordB1" style=" background:#F2F2F2; height:60px;">
     　 <div class="Black CreateWordC1">添加“<asp:Literal ID="lit_Name" runat="server"></asp:Literal>”到：</div>
        <asp:Panel ID="Panel1" runat="server">        
        <asp:DropDownList ID="ddpwordlist" runat="server">
        </asp:DropDownList>
            <input id="btn_Addwl" type="button" value="加入词单" onclick="InWordListAdd();" />
        <%--<asp:Button ID="btn_Addwl" runat="server" Text="加入词单" OnClientClick="return CkLogin();" onclick="btn_Addwl_Click" />        --%>
        </asp:Panel>
        <input id="input_newwl" type="button" value="新建词单" onclick="ShowBox();" />
    </div>
    <div class="CreateWordD1" style="background-image:url(/images/word/word_48.gif); width:440px; font-size:24px; clear:both; margin:30px 0px 0px 20px;">或者 </div>
	<div class="CreateWordD1"><asp:ImageButton ID="ImgBtn_AddColl" ImageUrl="/images/word/word_46.gif" Width="117" Height="52" runat="server" onclick="ImgBtn_AddColl_Click" OnClientClick="return CkLogin();" /></div>	
	</div>
  </div>
</div>
</form>
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="face.aspx.cs" Inherits="user_face" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
头像修改<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">        
       .left{    float:left;	    width:48%;}
.right{    float:left;    width:48%;    margin-left:20px;}
.title{    border-bottom:solid 1px #ccc;   font-size:14px;	}
.photocontainer{	margin-top:10px; height:125px;background:url("/images/Uimgbg4.gif") no-repeat left top; padding:11px 8px 8px 11px;}  
.uploadtooltip{	margin-top:10px;color: #555;line-height:150%;}
.uploaddiv{	margin-top:10px;}
input{	padding:3px;  }
#Step2Container{/*display:none;	*/}
#Canvas{position: relative;width:284px;height:266px;border:2px solid #888888;overflow:hidden;cursor:pointer;}
.smallbig{    cursor:pointer;	}
#bar{ width: 211px; height: 18px; background-image: url("/images/track.gif"); background-repeat: no-repeat; position: relative; }
.child{  width: 11px; height: 16px;background-image: url("/images/grip.gif"); background-repeat: no-repeat;left: 0;top:2px; position: absolute; left:100px; }
.imagePhoto{border-width:0px;position:relative;}
#IconContainer{	position:relative; left:0px;top:-92px;}  
#IconContainer img{	FILTER:alpha(opacity=60);opacity:0.6; background-color:#ccc;	   }
#ImageDragContainer { border: 1px solid #ccc; width: 92px; height: 92px; cursor: pointer; position: relative;top: 87px; left: 96px;overflow: hidden;z-index:1;}
    </style>
    <script  type="text/javascript" src="/js/jquery1.2.6.pack.js" ></script>
    <script  type="text/javascript" src="/js/ui.core.packed.js" ></script>
    <script type="text/javascript" src="/js/ui.draggable.packed.js" ></script>
    <script type="text/javascript" src="/js/CutPic.js"></script>
    <script type="text/javascript">
        function Step1() {
            $("#Step2Container").hide();           
        }
        function Step2() {
            $("#CurruntPicContainer").hide();
        }
        function Step3() {
            $("#Step2Container").hide();          
       }
    </script>
    <form runat="server" id="form1">
    <div class="CreateWord">    
    <!--<span style="border:1px blue solid; line-height:30px; margin-right:20px;"><a href="/user/face.aspx">修改头像</a></span>-->
    <div class="CreateWordA1" style="height:400px;">
     <div class="left">
         <!--当前照片-->
         <div id="CurruntPicContainer">
            <div class="title"><img src="/images/member/member_06.gif" /> <b>当前头像</b></div>
            <div class="photocontainer" style="">
                <asp:Image ID="imgphoto" runat="server" ImageUrl="/images/man.GIF" />
            </div>
            <span style=" line-height:30px; text-align:center;"><a href="/user/set.aspx"><img src="/images/word/word_69.gif" /></a></span>
         </div>
         <!--Step 2-->
         <div id="Step2Container">
           <div class="title"><b> 裁切头像照片</b></div>
           <div class="uploadtooltip">您可以拖动照片以裁剪满意的头像</div>                              
                   <div id="Canvas" class="uploaddiv">                   
                            <div id="ImageDragContainer">                               
                               <asp:Image ID="ImageDrag" runat="server" ImageUrl="/images/blank.jpg" CssClass="imagePhoto" ToolTip=""/>                                                        
                            </div>
                            <div id="IconContainer">                               
                               <asp:Image ID="ImageIcon" runat="server" ImageUrl="/images/blank.jpg" CssClass="imagePhoto" ToolTip=""/>                                                        
                            </div>                          
                    </div>
                    <div class="uploaddiv">
                       <table>
                            <tr>
                                <td id="Min">
                                        <img alt="缩小" src="/images/_c.gif" onmouseover="this.src='/images/_c.gif';" onmouseout="this.src='/images/_h.gif';" id="moresmall" class="smallbig" />
                                </td>
                                <td>
                                    <div id="bar">
                                        <div class="child">
                                        </div>
                                    </div>
                                </td>
                                <td id="Max">
                                        <img alt="放大" src="/images/c.gif" onmouseover="this.src='/images/c.gif';" onmouseout="this.src='/images/h.gif';" id="morebig" class="smallbig" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="uploaddiv" style="display:block;">
                        <asp:Button ID="btn_Image" runat="server" Text="保存头像" OnClick="btn_Image_Click" />
                        <input id="btn_Cannel" type="button" value="取 消" onclick="javascript:history.go(-1);"/>
                    </div>           
                    <div style="display:none;">
                    图片实际宽度： <asp:TextBox ID="txt_width" runat="server" Text="1" ></asp:TextBox><br />
                    图片实际高度： <asp:TextBox ID="txt_height" runat="server" Text="1" ></asp:TextBox><br />
                    距离顶部： <asp:TextBox ID="txt_top" runat="server"  Text="96.5"></asp:TextBox><br />
                    距离左边： <asp:TextBox ID="txt_left" runat="server" Text="87.5"></asp:TextBox><br />
                    截取框的宽： <asp:TextBox ID="txt_DropWidth" runat="server"  Text="91"></asp:TextBox><br />
                    截取框的高： <asp:TextBox ID="txt_DropHeight" runat="server" Text="91"></asp:TextBox><br />
                    放大倍数： <asp:TextBox ID="txt_Zoom" runat="server" ></asp:TextBox>
                   </div>
         </div>     
     </div>
     
     <div class="right">
         <!--Step 1-->
         <div id="Step1Container">
            <div class="title"><img src="/images/member/member_06.gif" /> <b>更换头像</b></div>
            <div id="uploadcontainer">
                <div class="uploadtooltip">自上传图片需为<span class="Red">JPG,BMP、PNG</span>或<span class="Red">GIF</span>格式，大小不要超过<span class="Red">500K</span>，<br />签名照默认尺寸为<span class="Red">91×91</span>，超过该尺寸将自动裁剪</div>
                <div class="uploaddiv"><asp:FileUpload ID="fuPhoto"  runat="server" ToolTip="选择照片"/></div>
                <div class="uploaddiv"><asp:Button ID="btnUpload" runat="server" Text="上 传" onclick="btnUpload_Click" /></div>
            </div>
         
         </div>
     </div>
    </div>

    </div>
    </form>
</asp:Content>


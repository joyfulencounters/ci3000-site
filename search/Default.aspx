<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="Default.aspx.cs"
    Inherits="search_Default" Title="无标题页" EnableViewState="false" %>
  <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  搜索<%= WebQywy.Data_Public.GetTitleAppend()%>
  </asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <script src="/js/SpryTabbedPanels.js" type="text/javascript"></script>
  <script language="javascript" type="text/javascript">
  function WsearchD()
  {
      var locat = "";
      var sear = "";
      var type = TabbedPanels1.currentTabIndex;
      switch(type){
          case 0:
              $("#headqW").focus();
              locat = "word.aspx?w=";
              sear = escape($("#headqW").val());
              break;
          case 1:
              $("#headqWl").focus();
              locat = "wordlistSear.aspx?sear=";
              sear = escape($("#headqWl").val());
              break;
          case 2:
              $("#headqUs").focus();
              locat = "userSear.aspx?sear=";
              sear = escape($("#headqUs").val());
              break;
          case 3:
              $("#headqT").focus();
              locat = "wordTagSear.aspx?sear=";
              sear = escape($("#headqT").val());
              break;
      }
      window.location.href = "/search/"+locat+sear;
  }
  function txtonkeyup(e){
      if(!e)
          document.onkeydown = keyDown;
      else{
          if((event.keyCode == 13)) WsearchD();
      }
  }
  function keyDown(e){
      if(!e) e=window.event;
      if(e.keyCode==13 ) WsearchD();
  }
  function onblurNull(){
      document.onkeydown = null;
  }
  </script>
  <form runat="server" id="form1" class="SearchPage">
  <div class="SearchMainCard">
      <h1 class="SearchMainTitle">发现你想找的词</h1>
      <p class="SearchSubTitle">在词、词单、用户与感觉之间自由搜索</p>

      <div id="TabbedPanels1" class="TabbedPanels SearchTabs">
          <ul class="TabbedPanelsTabGroup">
              <li class="TabbedPanelsTab" tabindex="0">词</li>
              <li class="TabbedPanelsTab" tabindex="0">词单</li>
              <li class="TabbedPanelsTab" tabindex="0">用户</li>
              <li class="TabbedPanelsTab" tabindex="0">凭感觉</li>
          </ul>
          <div class="TabbedPanelsContentGroup">
              <div class="TabbedPanelsContent">
                  <div class="SearchInputRow">
                      <div class="SearchInputCol"><input name="q" type="text" class="SearchInput" id="headqW"
    value="搜索一个词" onkeyup="return txtonkeyup()" onblur="onblurNull()"
    onfocus="if(this.value=='搜索一个词')this.value='';" /></div>
                      <div class="SearchBtnCol"><a href="javascript:void(0);" onclick="WsearchD();"
    class="SearchSubmitBtn">搜索</a></div>
                  </div>
              </div>
              <div class="TabbedPanelsContent">
                  <div class="SearchInputRow">
                      <div class="SearchInputCol"><input name="q" type="text" class="SearchInput" id="headqWl"
    value="搜索词单" onkeyup="return txtonkeyup()" onblur="onblurNull()" onfocus="if(this.value=='搜索词单')this.value='';"
    /></div>
                      <div class="SearchBtnCol"><a href="javascript:void(0);" onclick="WsearchD();"
    class="SearchSubmitBtn">搜索</a></div>
                  </div>
              </div>
              <div class="TabbedPanelsContent">
                  <div class="SearchInputRow">
                      <div class="SearchInputCol"><input name="q" type="text" class="SearchInput" id="headqUs"
    value="搜索用户" onkeyup="return txtonkeyup()" onblur="onblurNull()" onfocus="if(this.value=='搜索用户')this.value='';"
    /></div>
                      <div class="SearchBtnCol"><a href="javascript:void(0);" onclick="WsearchD();"
    class="SearchSubmitBtn">搜索</a></div>
                  </div>
              </div>
              <div class="TabbedPanelsContent">
                  <div class="SearchInputRow">
                      <div class="SearchInputCol"><input name="q" type="text" class="SearchInput" id="headqT"
    value="例如：幸福，惬意，惆怅，无奈，凄凉……" onkeyup="return txtonkeyup()" onblur="onblurNull()"
    onfocus="if(this.value=='例如：幸福，惬意，惆怅，无奈，凄凉……')this.value='';" /></div>
                      <div class="SearchBtnCol"><a href="javascript:void(0);" onclick="WsearchD();"
    class="SearchSubmitBtn">搜索</a></div>
                  </div>
              </div>
          </div>
      </div>

      <script type="text/javascript">
      <!--
      function GetQueryString(name) {
          var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)","i");
          var r = window.location.search.substr(1).match(reg);
          if (r!=null) return unescape(r[2]);
          return 0;
      }
      var index = GetQueryString("index");
      if(CheckInt(index)) {
          if(parseInt(index) < 0 || parseInt(index) > 4)
              index = 0;
      }
      else
          index = 0;
      var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1",parseInt(index));
      //-->
      </script>
  </div>
  </form>
  </asp:Content>

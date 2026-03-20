<%@ Page Language="C#" MasterPageFile="~/Template/MasterHead.master" AutoEventWireup="true" CodeFile="lovers.aspx.cs" Inherits="lovers" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
同好<%= WebQywy.Data_Public.GetTitleAppend()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<style>
.LoversContainer {
    width: 960px;
    margin: 0 auto;
    padding: 30px 20px;
}
.LoversTitle {
    font-size: 20px;
    color: #427e5f;
    text-align: center;
    margin-bottom: 30px;
    padding-left: 14px;
    position: relative;
}
.LoversTitle:before {
    content: "";
    position: absolute;
    left: 50%;
    transform: translateX(-50%);
    top: 30px;
    width: 4px;
    height: 18px;
    background: #427e5f;
    border-radius: 2px;
}
.LoversGrid {
    display: flex;
    flex-wrap: wrap;
    justify-content: flex-start;
    gap: 20px;
}
.LoverCard {
    width: 140px;
    text-align: center;
    padding: 15px;
    background: #f9f9f9;
    border-radius: 8px;
    transition: transform 0.2s, box-shadow 0.2s;
}
.LoverCard:hover {
    transform: translateY(-3px);
    box-shadow: 0 4px 12px rgba(0,0,0,0.1);
}
.LoverAvatar {
    width: 90px;
    height: 90px;
    border-radius: 50%;
    object-fit: cover;
    border: 2px solid #ddd;
    margin-bottom: 10px;
}
.LoverName {
    font-size: 14px;
    color: #333;
    margin-bottom: 5px;
}
.LoverIndex {
    font-size: 12px;
    color: #4e8f6c;
    font-weight: bold;
}
.LoverEmpty {
    text-align: center;
    color: #999;
    font-size: 14px;
    padding: 50px 0;
}
</style>
<div class="LoversContainer">
    <div class="LoversTitle">同好</div>
    <asp:Literal ID="lit_Lovers" runat="server"></asp:Literal>
</div>
</asp:Content>
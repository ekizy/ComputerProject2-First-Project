<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="nerdeyesek._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <div class="background">
  </div>
  <h1 class="text"> Enjoy the best possible meal everyday with NeredeYesek</h1>
  <style>
    .background { 
        position: absolute;
        left: 0;
        right: 0;
        z-index: 1;
        display: block;
        width:100%;
        height:100%;
        background-image: url(Images/background.jpeg);
        background-size:cover;
        -webkit-filter: blur(2px);
        -moz-filter: blur(2px);
        -o-filter: blur(2px);
         filter: blur(2px);
    }
    .text {
         position: relative;
         z-index: 100;
         padding-top:500px;
         text-indent:150px;
         font-family:'Courier New';
         color:midnightblue;
         font-weight:bolder;
    }
  </style>

</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberVotes.aspx.cs" Inherits="nerdeyesek.MemberVotes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div style="text-align:center">
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" ></asp:Panel>        
        <asp:button id="btnAddVotes" runat="server" text="Kaydet" OnClick="btnAddVotes_Click"></asp:button>
        <asp:label id="lblHata" runat="server" forecolor="Red"></asp:label>
    </div>
</asp:Content>


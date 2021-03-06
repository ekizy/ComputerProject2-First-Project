﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberVotes.aspx.cs" Inherits="nerdeyesek.MemberVotes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div style="text-align:center">
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" ></asp:Panel>
        <div style="height:10px;"></div>
        <asp:button id="btnAddVotes" CssClass="btn btn-success" runat="server" text="Vote" OnClick="btnAddVotes_Click"></asp:button>
        <asp:label id="lblHata" runat="server" forecolor="Red"></asp:label>

        <div style="height: 286px;margin-left:400px;">
        <table>
            <tr >
                <td>
                 <asp:GridView CssClass="Restoran" ID="GridView1" runat="server" Height="267px"  Width="400px" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                     <Columns>
                         <asp:BoundField DataField="AD" HeaderText="NAME" SortExpression="AD" />
                         <asp:BoundField DataField="PUAN" HeaderText="RATING" SortExpression="PUAN" />
                     </Columns>
  
                 </asp:GridView>
                    <asp:Repeater  ID="Repeater1" runat="server" DataSourceID="SqlDataSource1"  ></asp:Repeater>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project1DatabaseConnectionString %>" SelectCommand="SELECT  AD,PUAN FROM PUANLAR JOIN RESTORANLAR ON RESTORANLAR.ID=PUANLAR.RESTORANID"></asp:SqlDataSource>
                </td>
            </tr>
        </table>
            </div>
    </div>
    <style>
        body{
            background-image:url(Images/membervotes.jpeg);
            background-size:cover;
        }
    </style>
</asp:Content>


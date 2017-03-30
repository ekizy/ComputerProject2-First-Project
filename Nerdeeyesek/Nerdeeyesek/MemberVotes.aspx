﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberVotes.aspx.cs" Inherits="nerdeyesek.MemberVotes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
    <div style="text-align:center">
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" ></asp:Panel>
        <div style="height:10px;"></div>
        <asp:button id="btnAddVotes" CssClass="btn btn-success" runat="server" text="Kaydet" OnClick="btnAddVotes_Click"></asp:button>
        <asp:label id="lblHata" runat="server" forecolor="Red"></asp:label>

        <div style="height: 286px;margin-left:300px;">
        <table>
            <tr >
                <td>
                 <asp:GridView CssClass="Restoran" ID="GridView1" runat="server" Height="267px"  Width="628px" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                     <Columns>
                         <asp:BoundField DataField="AD" HeaderText="AD" SortExpression="AD" />
                         <asp:BoundField DataField="TAMPUAN" HeaderText="TAMPUAN" SortExpression="TAMPUAN" />
                         <asp:BoundField DataField="ONDALIKPUAN" HeaderText="ONDALIKPUAN" SortExpression="ONDALIKPUAN" />
                     </Columns>
  
                 </asp:GridView>
                    <asp:Repeater  ID="Repeater1" runat="server" DataSourceID="SqlDataSource1"  ></asp:Repeater>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project1DatabaseConnectionString %>" SelectCommand="SELECT  AD,TAMPUAN,ONDALIKPUAN FROM PUANLAR JOIN RESTORANLAR ON RESTORANLAR.ID=PUANLAR.RESTORANID"></asp:SqlDataSource>
                </td>
            </tr>
        </table
            </div>
    </div>
</asp:Content>


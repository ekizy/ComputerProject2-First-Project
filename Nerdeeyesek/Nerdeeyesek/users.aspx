﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="Nerdeeyesek.users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

<h2>Üyeler</h2>
    <div class="s5">
        <table class="tablestyle1">
            <tr>
                <td>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ad" HeaderText="ad" SortExpression="ad" />
            <asp:BoundField DataField="soyad" HeaderText="soyad" SortExpression="soyad" />
            <asp:BoundField DataField="mail" HeaderText="mail" SortExpression="mail" />
        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project1DatabaseConnectionString %>" SelectCommand="SELECT [ad], [soyad], [mail] FROM [UYELER]"></asp:SqlDataSource>
    <asp:Repeater ID="Repeater1" runat="server"></asp:Repeater>  

                </td>
            </tr>

        </table>
    </div>
    <div>
        <asp:Button CssClass="buttons1" ID="useraddbttn" runat="server" onClick="useraddbttn_Click" Text="Üye Ekle" />
    </div>

 </asp:Content>
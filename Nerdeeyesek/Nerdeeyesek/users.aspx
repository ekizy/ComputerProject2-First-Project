<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="Nerdeeyesek.users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >
<%--  --%>
    <div style="height: 286px;margin-top: 100px;margin-left:300px;">
        <table class="tablestyle1">
            <tr>
                <td>
    <asp:GridView ID="GridView1"  CssClass="Restoran" runat="server" Height="267px"  Width="600px" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="ad" HeaderText="NAME" SortExpression="ad" />
            <asp:BoundField  DataField="soyad" HeaderText="SURNAME" SortExpression="soyad" />
            <asp:BoundField DataField="mail" HeaderText="MAIL" SortExpression="mail" />
        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project1DatabaseConnectionString %>" SelectCommand="SELECT [ad], [soyad], [mail] FROM [UYELER]"></asp:SqlDataSource>
    <asp:Repeater ID="Repeater1" runat="server"></asp:Repeater>  
                </td>
            </tr>
        </table>
    </div>
    <div  style="height: 100px;margin-left:320px;">
        <asp:TextBox ID="textname" placeholder="Name" Visible="false" runat="server"></asp:TextBox>
        <asp:TextBox ID="textsurname" placeholder="Surname" Visible="false" runat="server"></asp:TextBox>
        <asp:TextBox ID="textmail" placeholder="E-mail" Visible="false" runat="server"></asp:TextBox>
        <asp:Button ID="adduser" CssClass="btn btn-success" runat="server" Visible="false" OnClick="adduser_Click" Text="+" />
        <asp:Button CssClass="btn btn-primary" style="margin-left:210px; margin-top:10px" ID="useraddbttn" runat="server" onClick="useraddbttn_Click" Text="Add member" />
    </div>
    <style>
        body{
            background-image:url(Images/users.jpg);
            background-size:cover;
        }
    </style>
    
 </asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="Nerdeeyesek.users" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

<h2>Üyeler</h2>
    <div class="s5">
        <table class="tablestyle1">
            <tr>
                <th class="s5">Üye Adı</th>
                <th class="s5">E-mail</th>
            </tr>
            <tr>
                <td class="s5">Yusuf Ekiz</td>
                <td class="s5"><a href="mailto:ekizy@itu.edu.tr?Subject=Hello" target="_top">ekizy@itu.edu.tr</a></td>
            </tr>
            <tr>
                <td class="s5">Hilal Gülşen</td>
                <td class="s5"><a href="mailto:gulsenh@itu.edu.tr?Subject=Hello" target="_top">gulsenh@itu.edu.tr</a></td>
            </tr>
            <tr>
                <td class="s5">Serkan Bekir</td>
                <td class="s5"><a href="mailto:bekir@itu.edu.tr?Subject=Hello" target="_top">bekir@itu.edu.tr</a></td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Button class="buttons1" ID="useraddbttn" runat="server" onClick="useraddbttn_Click" Text="Üye Ekle" />
    </div>

 </asp:Content>

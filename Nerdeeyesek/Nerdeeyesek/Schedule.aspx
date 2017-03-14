<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Nerdeeyesek.Schedule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

    <h2>Gidilecek restoranlar</h2>

    <div class="s5">
        <table  class="tablestyle1">
            <tr class="s6">
                <th class="s5">Gün</th>
                <th class="s5">Restoran adı</th>
                <th class="s5">Ulaşım tipi</th>
                <th class="s5">Hava Duyarlılığı</th>
            </tr>
            <tr class="s6">
                <td class="s5">1</td>
                <td class="s5">Nusret</td>
                <td class="s5">Araba</td>
                <td class="s5">Var</td>
            </tr>
            <tr class="s6">
                <td class="s5">2</td>
                <td class="s5">Varuna Gezgin</td>
                <td class="s5">Yaya</td>
                <td class="s5">Var</td>
            </tr>
            <tr class="s6">
                <td class="s5">3</td>
                <td class="s5">Kumbara</td>
                <td class="s5">Araba</td>
                <td class="s5">Yok</td>
            </tr>
            <tr class="s6">
                <td class="s5">4</td>
                <td class="s5">Baltazar</td>
                <td class="s5">Yaya</td>
                <td class="s5">Var</td>
            </tr>
            <tr class="s6">
                <td class="s5">5</td>
                <td class="s5">Heisenberg</td>
                <td class="s5">Yaya</td>
                <td class="s5">Var</td>
            </tr>
            <tr>
                <td class="s5">6</td>
                <td class="s5">Midpoint</td>
                <td class="s5">Araba</td>
                <td class="s5">Yok</td>
            </tr>

        </table>
    </div>

 </asp:Content>
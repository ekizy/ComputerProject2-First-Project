<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberVotes.aspx.cs" Inherits="nerdeyesek.MemberVotes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

    <form id="form1" >
    <div>
        <table class="style1">
            <td>
                <th>
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1"></asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project1DatabaseConnectionString %>" SelectCommand="SELECT AD FROM [RESTORANLAR]"></asp:SqlDataSource>
                    <asp:Repeater ID="Repeater1" runat="server"></asp:Repeater>
                </th>
                </td>
            <tr>
                <td class="style3">
                     </td>
                <td class="style4">
                     </td>
                <td class="style4">
                     </td>
                <td class="style4">
                     </td>
                <td class="style4">
                     </td>
                <td class="style4">
                     </td>
                <td class="style4">
                     </td>
            </tr>
            <tr>
                <td class="style3">
                    Üye 1
                </td>
                <td>
                    <asp:textbox id="Textbox11" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox12" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox13" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox14" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox15" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox16" runat="server" width="150px"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Üye 2
                </td>
                <td>
                    <asp:textbox id="Textbox21" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox22" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox23" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox24" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox25" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox26" runat="server" width="150px"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Üye 3
                </td>
                <td>
                    <asp:textbox id="Textbox31" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox32" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox33" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox34" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox35" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox36" runat="server" width="150px"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Üye 4
                </td>
                <td>
                    <asp:textbox id="Textbox41" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox42" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox43" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox44" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox45" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox46" runat="server" width="150px"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Üye 5
                </td>
                <td>
                    <asp:textbox id="Textbox51" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox52" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox53" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox54" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox55" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox56" runat="server" width="150px"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Üye 6
                </td>
                <td>
                    <asp:textbox id="Textbox61" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox62" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox63" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox64" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox65" runat="server" width="150px"></asp:textbox>
                </td>
                <td>
                    <asp:textbox id="Textbox66" runat="server" width="150px"></asp:textbox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                     </td>
                <td class="style4">
                     </td>
                <td class="style4">
                     </td>
                <td class="style4">
                     </td>
                <td class="style4">
                     </td>
                <td class="style4">
                     </td>
                <td>
                    <asp:button id="btnAddVotes" runat="server" text="Kaydet">
                </asp:button></td>
            </tr>
            <tr>
                <td class="style3">
                     </td>
                <td class="style4">
                     </td>
                <td class="style4">
                     </td>
                <td class="style4">
                     </td>
                <td class="style4">
                     </td>
                <td class="style4">
                     </td>
                <td>
                    <asp:label id="lblHata" runat="server" forecolor="Red"></asp:label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</asp:Content>


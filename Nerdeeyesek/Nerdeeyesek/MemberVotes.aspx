<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberVotes.aspx.cs" Inherits="nerdeyesek.MemberVotes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

    <form id="form1" >
    <div>
       <table>
   <thead>
            <tr>
                <% foreach(var item in this.restoranlar()){ %>
                    <th style="padding:5px;"><%= item %></th>
                <% } %>
            </tr>
        </thead>
            </table>
                    <%foreach( var item in this.uyeler()){ %>
                   <label for="test"><%=item %></label>
                     <% foreach(var item1 in this.restoranlar()){ %>
                    <asp:TextBox runat="server" Width="100px" ></asp:TextBox>
                    <% } %>
                    <br />
                    <%} %>

                             <asp:button id="btnAddVotes" runat="server" text="Kaydet">
                </asp:button>
                    <asp:label id="lblHata" runat="server" forecolor="Red"></asp:label>
    </div>
    </form>
</asp:Content>


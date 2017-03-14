<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Restaurants.aspx.cs" Inherits="nerdeyesek.Restaurants" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >


    <div style="height: 286px;margin-top: 100px;margin-left:200px;">
  
    
        <table>
            <tr >
                <td>
                 <asp:GridView CssClass="Restoran" ID="GridView1" runat="server" Height="400px"  Width="800">
                 </asp:GridView>
                    <asp:Repeater  ID="Repeater1" runat="server"  ></asp:Repeater>
                </td>
            </tr>
        </table>
        
  
        
 </div>  
    <div style="height: 100px;">
        </div>
     
 </asp:Content>


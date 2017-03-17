<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Restaurants.aspx.cs" Inherits="nerdeyesek.Restaurants" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >


    <div style="height: 286px;margin-top: 100px;margin-left:300px;">
  
    
        <table>
            <tr >
                <td>
                 <asp:GridView CssClass="Restoran" ID="GridView1" runat="server" Height="267px"  Width="628px" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                     <Columns>
                         <asp:BoundField DataField="ad" HeaderText="ad" SortExpression="ad" />
                         <asp:BoundField DataField="ulasimtipi" HeaderText="ulasimtipi" SortExpression="ulasimtipi" />
                         <asp:BoundField DataField="havayaduyarlilik" HeaderText="havayaduyarlilik" SortExpression="havayaduyarlilik" />
                     </Columns>
                 </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Project1DatabaseConnectionString %>" SelectCommand="SELECT * FROM [RESTORANLAR]"></asp:SqlDataSource>
                    <asp:Repeater  ID="Repeater1" runat="server"  ></asp:Repeater>
                </td>
            </tr>
        </table>
        
  
        
 </div>  
    
    <div style="height: 100px;">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        </div>
     
 </asp:Content>


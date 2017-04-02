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
    <!--<style>
        body{
            background-image:url(https://static.pexels.com/photos/306059/pexels-photo-306059.jpeg);
            background-size:cover;
        }
    </style>-->
  
        
 </div>  
    
    <div  style="height: 100px;margin-left:320px;">
        <asp:TextBox  ID="TextBox1"  placeholder="Ad" runat="server" Visible="false" ></asp:TextBox>
        <asp:TextBox  ID="TextBox2" placeholder="Ulasim tipi" runat="server" Visible="false" ></asp:TextBox>
        <asp:TextBox  ID="TextBox3" placeholder="Havaya duyarlilik"  runat="server" Visible="false" ></asp:TextBox>

        <asp:Button ID="Button2" CssClass="btn btn-primary" style="margin-left:210px;" runat="server" Text=" Yeni Restoran Ekle" OnClick="Button2_Click" />
        <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Text="Ekle" OnClick="Button1_Click" Visible="false" />
        </div>
     
 </asp:Content>


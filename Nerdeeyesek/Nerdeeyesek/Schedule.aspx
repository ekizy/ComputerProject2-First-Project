﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Nerdeeyesek.Schedule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

    <h2>Gidilecek restoranlar</h2>

      <div style="height: 286px;margin-top: 100px;margin-left:300px;">
  
    
        <table>
            <tr >
                <td>
                 <asp:GridView CssClass="Restoran" ID="GridView1" runat="server" Height="267px"  Width="628px" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                     <Columns>
                         <asp:BoundField DataField="REALDATE" HeaderText="REALDATE" SortExpression="REALDATE" />
                         <asp:BoundField DataField="CYCLEDAY" HeaderText="CYCLEDAY" SortExpression="CYCLEDAY" />
                         <asp:BoundField DataField="AD" HeaderText="AD" SortExpression="AD" />
                         <asp:BoundField DataField="HAVAYADUYARLILIK" HeaderText="HAVAYADUYARLILIK" SortExpression="HAVAYADUYARLILIK" />
                         <asp:BoundField DataField="ULASIMTIPI" HeaderText="ULASIMTIPI" SortExpression="ULASIMTIPI" />
                         <asp:BoundField DataField="HAVA" HeaderText="HAVA" SortExpression="HAVA" />
                     </Columns>
                 </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Project1DatabaseConnectionString %>" SelectCommand="SELECT REALDATE,CYCLEDAY,RESTORANLAR.AD,HAVAYADUYARLILIK,RESTORANLAR.ULASIMTIPI,TAKVIM.HAVA FROM TAKVIM JOIN RESTORANLAR ON RESTORANLAR.ID=TAKVIM.RESTORANID ORDER BY TAKVIM.CYCLEDAY"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                    <asp:Repeater  ID="Repeater1" runat="server"  ></asp:Repeater>
                </td>
            </tr>
        </table>

  
        
 </div>  

    <!--<style>
        body{
            background-image:url(https://static.pexels.com/photos/67468/pexels-photo-67468.jpeg);
            background-size:cover;
        }
    </style>-->
 </asp:Content>
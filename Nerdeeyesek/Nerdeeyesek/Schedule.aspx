<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Nerdeeyesek.Schedule" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >

    <h2 style="margin-left:450px; margin-top:50px">Destination Restaurants</h2>

      <div style="height: 286px;margin-top: 10px;margin-left:300px;">
  
    
        <table class="tablestyle1">
            <tr >
                <td>
                 <asp:GridView CssClass="Restoran" ID="GridView1" runat="server" Height="267px"  Width="628px" AutoGenerateColumns="False" DataSourceID="SqlDataSource2">
                     <Columns>
                         <asp:BoundField DataField="REALDATE" HeaderText="DATE" SortExpression="REALDATE" />
                         <asp:BoundField DataField="CYCLEDAY" HeaderText="CYCLEDAY" SortExpression="CYCLEDAY" />
                         <asp:BoundField DataField="AD" HeaderText="NAME" SortExpression="AD" />
                         <asp:BoundField DataField="HAVAYADUYARLILIK" HeaderText="WEATHERSENSITIVITY" SortExpression="HAVAYADUYARLILIK" />
                         <asp:BoundField DataField="ULASIMTIPI" HeaderText="TRANSPORTATION" SortExpression="ULASIMTIPI" />
                         <asp:BoundField DataField="HAVA" HeaderText="WEATHER" SortExpression="HAVA" />
                     </Columns>
                 </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Project1DatabaseConnectionString %>" SelectCommand="SELECT REALDATE,CYCLEDAY,RESTORANLAR.AD,HAVAYADUYARLILIK,RESTORANLAR.ULASIMTIPI,TAKVIM.HAVA FROM TAKVIM JOIN RESTORANLAR ON RESTORANLAR.ID=TAKVIM.RESTORANID ORDER BY TAKVIM.CYCLEDAY"></asp:SqlDataSource>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                    <asp:Repeater  ID="Repeater1" runat="server"  ></asp:Repeater>
                </td>
            </tr>
        </table>

          <div style="height:50px;"></div>

  
        
 </div>  

    <style>
        body{
            background-image:url(Images/schedule.jpeg);
            background-size:cover;
        }
    </style>
 </asp:Content>
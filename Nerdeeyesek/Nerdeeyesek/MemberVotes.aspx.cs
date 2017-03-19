using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace nerdeyesek
{
    public partial class MemberVotes : System.Web.UI.Page
    {
        protected string [] restoranlar()
        {
            string conString = String.Format(@"Data Source=nerdeyesek.database.windows.net;Initial Catalog=Project1Database;Integrated Security=False;User ID=ekizy;Password=yusufekiz-10;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            string firstCommand = "SELECT COUNT(distinct ad) FROM RESTORANLAR;";
            cmd.CommandText = firstCommand;
            int restoranSayisi = (int)cmd.ExecuteScalar();
            string command = "SELECT ad FROM RESTORANLAR;";
            cmd.CommandText = command;
            string[] restoranlar = new string[restoranSayisi];
            SqlDataReader reader = cmd.ExecuteReader();
            int counter = 0;
            while (reader.Read())
            {
                restoranlar[counter] = reader.GetString(0);
                counter++;
            }
            con.Close();
            return restoranlar;
        }
        protected string[] uyeler()
        {
            string conString = String.Format(@"Data Source=nerdeyesek.database.windows.net;Initial Catalog=Project1Database;Integrated Security=False;User ID=ekizy;Password=yusufekiz-10;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            string firstCommand = "SELECT COUNT(distinct id) FROM UYELER;";
            cmd.CommandText = firstCommand;
            int uyeSayisi = (int)cmd.ExecuteScalar();
            string command = "SELECT ad,soyad FROM UYELER;";
            cmd.CommandText = command;
            string[] uyeler = new string[uyeSayisi];
            SqlDataReader reader = cmd.ExecuteReader();
            int counter = 0;
            while (reader.Read())
            {
                uyeler[counter] = reader.GetString(0) + " " + reader.GetString(1);
                counter++;
            }
            con.Close();
            return uyeler;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
          
            
        }
    }
}
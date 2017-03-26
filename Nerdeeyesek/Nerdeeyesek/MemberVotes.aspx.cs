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
        public int counter = 0;
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
            initPage();
        }

        protected void initPage()
        {
            int counter = 0;

            Label lbl1 = new Label();
            lbl1.Width = 100;
            lbl1.Font.Bold = true;
            lbl1.Visible = true;
            Panel1.Controls.Add(lbl1);

            foreach (string item1 in this.restoranlar())
            {
                Label lbl = new Label();
                lbl.Width = 100;
                lbl.Text = item1;
                lbl.Font.Bold = true;
                Panel1.Controls.Add(lbl);
            }
            Panel1.Controls.Add(new Literal() { ID = "row", Text = "<br/>" });
           foreach(string item in this.uyeler())
            {
                Label lbl = new Label();
                lbl.Width = 100;
                lbl.Text = item;
                lbl.Font.Bold = true;
                lbl.Visible = true;
                Panel1.Controls.Add(lbl);
               
               foreach(string item1 in this.restoranlar())
               {
                   TextBox tb= new TextBox();
                   tb.Width = 100;
                   string id = "TextBox" + counter.ToString();
                   tb.ID = id;
                   Panel1.Controls.Add(tb);
                   counter++;
               }
               Panel1.Controls.Add(new Literal() { ID = "row"+counter.ToString(), Text = "<br/>" });
            }
        }


        protected void btnAddVotes_Click(object sender, EventArgs e)
        {
            TextBox tb = (TextBox) Panel1.FindControl("TextBox0");
            tb.Text = "asd";
            return;
        }


    }
}
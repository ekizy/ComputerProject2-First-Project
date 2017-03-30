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
    public partial class Restaurants : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

  

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ad = TextBox1.Text.ToString();
            string ulasimtipi = TextBox2.Text.ToString();
            string havayaduyarlilik = TextBox3.Text.ToString();
            int id = 0;

            string conString = String.Format(@"Data Source=nerdeyesek.database.windows.net;Initial Catalog=Project1Database;Integrated Security=False;User ID=ekizy;Password=yusufekiz-10;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string command = "INSERT INTO RESTORANLAR VALUES('"+ad+"','"+ulasimtipi+"','"+havayaduyarlilik+"',0);";
            con.Open();
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
            string secondCommand = "SELECT id FROM RESTORANLAR WHERE ad='"+ad+"';";
            cmd.CommandText = secondCommand;
            id= (int) cmd.ExecuteScalar();

            string thirdCommand = "INSERT INTO PUANLAR VALUES("+id.ToString()+",0,0);";
            cmd.CommandText = thirdCommand;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/Restaurants");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Button1.Visible = true;
            TextBox1.Visible = true;
            TextBox2.Visible = true;
            TextBox3.Visible = true;
            Button2.Visible = false;
        }
  
 
    }
}
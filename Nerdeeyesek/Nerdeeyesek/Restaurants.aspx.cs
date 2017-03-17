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

        private DataSet GetData()
        {
            string connectionString = String.Format(@"Data Source=(localdb)\v11.0;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            using(SqlConnection sqlConnection1 = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM RESTAURANTS", sqlConnection1);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string conString = String.Format(@"Data Source=nerdeyesek.database.windows.net;Initial Catalog=Project1Database;Integrated Security=False;User ID=ekizy;Password=yusufekiz-10;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string value = TextBox1.Text.ToString();
            //string command = "INSERT INTO RESTORANLAR VALUES ( " + value ;
            string command = "SELECT * FROM RESTORANLAR";
            con.Open();
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
            con.Close();
        }
  
 
    }
}
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
            /*string[] array = { "Nusret", "Varuna Gezgin", "Kumbara", "Baltazar", "Heisenberg", "Midpoin" };
            DataSet  ds= GetData();

            GridView1.DataSource = ds;
            GridView1.DataBind();
            
            Repeater1.DataSource = ds;
            Repeater1.DataBind();*/
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
  
 
    }
}
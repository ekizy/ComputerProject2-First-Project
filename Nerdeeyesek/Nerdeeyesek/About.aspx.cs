using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace nerdeyesek
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void serkan_Click(object sender, EventArgs e)
        {

           /* string connectionString = String.Format(@"Data Source=(localdb)\v11.0;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlConnection sqlConnection1 = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "CREATE TABLE DENEME8 ( sayi INTEGER);";
            cmd.Connection = sqlConnection1;

            try {

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();

            }

            catch(Exception f){
                 Console.WriteLine(f);
            }*/
            

            
        }

    }
}
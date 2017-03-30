using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Nerdeeyesek
{
    public partial class algoritma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string gun = DateTime.Now.ToString();

            string conString = String.Format(@"Data Source=nerdeyesek.database.windows.net;Initial Catalog=Project1Database;User ID=ekizy;Password=yusufekiz-10");
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            string query = "SELECT RESTORANLAR.ID,RESTORANLAR.AD FROM RESTORANLAR JOIN PUANLAR ON PUANLAR.RESTORANID=RESTORANLAR.ID";
            cmd.CommandText = query;
            int maxpuan= (int)cmd.ExecuteScalar();

            con.Close();


        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Nerdeeyesek
{
    public partial class users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void useraddbttn_Click(object sender, EventArgs e)
        {
            useraddbttn.Enabled = false;
            textname.Visible = true;
            textsurname.Visible = true;
            textmail.Visible = true;
            adduser.Visible = true;
        }

        protected void adduser_Click(object sender, EventArgs e)
        {
            string name = textname.Text.ToString();
            string surname = textsurname.Text.ToString();
            string mail = textmail.Text.ToString();
            string conString = String.Format(@"Server=tcp:neredenyesek.database.windows.net,1433;Initial Catalog=Computerproject;Persist Security Info=False;User ID=serkanbekir;Password=serkan-94;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            string query = "INSERT INTO UYELER VALUES ('" + name+"','"+surname+"','" + mail + "');";
            cmd.CommandText=query;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("~/users");
        }
    }
}
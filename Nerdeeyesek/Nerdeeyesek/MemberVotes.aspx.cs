﻿using System;
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
        protected string[] restoranlar()
        {
            string conString = String.Format(@"Server=tcp:neredenyesek.database.windows.net,1433;Initial Catalog=Computerproject;Persist Security Info=False;User ID=serkanbekir;Password=serkan-94;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
            string conString = String.Format(@"Server=tcp:neredenyesek.database.windows.net,1433;Initial Catalog=Computerproject;Persist Security Info=False;User ID=serkanbekir;Password=serkan-94;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
            string conString = String.Format(@"Server=tcp:neredenyesek.database.windows.net,1433;Initial Catalog=Computerproject;Persist Security Info=False;User ID=serkanbekir;Password=serkan-94;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            string command = "SELECT distinct isVoted FROM RESTORANLAR ";
            cmd.CommandText = command;
            int isVoted = (int)cmd.ExecuteScalar();

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
                    if (isVoted != 0) lbl.Visible = false; 
                    Panel1.Controls.Add(lbl);
                }
                Panel1.Controls.Add(new Literal() { ID = "row", Text = "<br/>" });
                foreach (string item in this.uyeler())
                {
                    Label lbl = new Label();
                    lbl.Width = 100;
                    lbl.Text = item;
                    lbl.Font.Bold = true;
                    lbl.Visible = true;
                    if (isVoted != 0) lbl.Visible = false; 
                    Panel1.Controls.Add(lbl);

                    foreach (string item1 in this.restoranlar())
                    {
                        TextBox tb = new TextBox();
                        tb.Width = 100;
                        string id = "TextBox" + counter.ToString();
                        tb.ID = id;
                        if (isVoted != 0) tb.Visible = false; 
                        Panel1.Controls.Add(tb);
                        counter++;
                    }
                    Panel1.Controls.Add(new Literal() { ID = "row" + counter.ToString(), Text = "<br/>" });
                }
                Panel1.Controls.Add(new Literal() { ID = "row3" + counter.ToString(), Text = "<br/>" });
                Label cycleLabel = new Label();
                cycleLabel.Width = 100;
                cycleLabel.Text = "Gun sayısı";
                cycleLabel.Font.Bold = true;
                cycleLabel.Visible = true;
                if (isVoted != 0) cycleLabel.Visible = false;
                Panel1.Controls.Add(cycleLabel);

                TextBox cycleTextBox = new TextBox();
                cycleTextBox.Width = 100;
                cycleTextBox.ID = "Textboxcycle";
                if (isVoted != 0) cycleTextBox.Visible = false;
                Panel1.Controls.Add(cycleTextBox);
                
                

                if (isVoted != 0)
                {
                    btnAddVotes.Visible = false;
                    GridView1.Visible = true;
                }
                else
                {
                    GridView1.Visible = false;
                }

            
        }


        protected void btnAddVotes_Click(object sender, EventArgs e)
        {
            string conString = String.Format(@"Server=tcp:neredenyesek.database.windows.net,1433;Initial Catalog=Computerproject;Persist Security Info=False;User ID=serkanbekir;Password=serkan-94;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            string deleteSchedule = "DELETE FROM TAKVIM;";
            cmd.CommandText = deleteSchedule;
            cmd.ExecuteNonQuery();
            int counter = 0;
            List<double> list = new List<double>();
            list = calculateAverage();
            List<int> idlist = new List<int>();
            idlist = getIds();


            for (int i = 0; i < list.Count; i++)
            {
                int id = idlist[counter];
                string firstCommand = "UPDATE PUANLAR SET puan=puan+" + list[i].ToString()+ " WHERE restoranid=" + id + ";";
                cmd.CommandText = firstCommand;
                cmd.ExecuteNonQuery();
                counter++;
            }

            string secondCommand = "UPDATE RESTORANLAR SET isVoted=1;";
            cmd.CommandText = secondCommand;
            cmd.ExecuteNonQuery();

            TextBox tbox =(TextBox) Panel1.FindControl("Textboxcycle");
            string cyclelength = tbox.Text.ToString();
            string thirdCommand = "UPDATE PUANLAR SET cyclelength=" + cyclelength + ";";
            cmd.CommandText = thirdCommand;
            cmd.ExecuteNonQuery();
            con.Close();
            
            Response.Redirect("~/");
            return;
        }

        protected List<double> calculateAverage()
        {
            string conString = String.Format(@"Server=tcp:neredenyesek.database.windows.net,1433;Initial Catalog=Computerproject;Persist Security Info=False;User ID=serkanbekir;Password=serkan-94;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            string firstCommand = "SELECT COUNT(distinct ad) FROM RESTORANLAR;";
            cmd.CommandText = firstCommand;
            int restoranSayisi = (int)cmd.ExecuteScalar();
            string secondCommand = "SELECT COUNT(distinct id) FROM UYELER;";
            cmd.CommandText = secondCommand;
            int uyeSayisi = (int)cmd.ExecuteScalar();
            double total = 0;
            List<double> averageList = new List<double>();

            for (int i = 0; i < restoranSayisi; i++)
            {
                for (int j = i; j <= (uyeSayisi - 1) * restoranSayisi + i; j = j + restoranSayisi)
                {
                    string id = "TextBox" + j.ToString();
                    TextBox tb = (TextBox)Panel1.FindControl(id);
                    total = total + Convert.ToDouble(tb.Text);
                }
                total = total / uyeSayisi;
                averageList.Add(total);
                total = 0;
            }
            return averageList;
        }
        protected List<int> getIds()
        {
            string conString = String.Format(@"Server=tcp:neredenyesek.database.windows.net,1433;Initial Catalog=Computerproject;Persist Security Info=False;User ID=serkanbekir;Password=serkan-94;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            List<int> ids = new List<int>();
            using (var con = new SqlConnection(conString))
            {
                string query = "SELECT id FROM RESTORANLAR;";
                var cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                using (SqlDataReader objReader = cmd.ExecuteReader())
                {
                    while (objReader.Read())
                    {
                        ids.Add(objReader.GetInt32(objReader.GetOrdinal("id")));
                    }

                }
            }
            return ids;
        }
    }
}
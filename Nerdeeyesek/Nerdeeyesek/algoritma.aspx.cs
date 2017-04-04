using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Nerdeeyesek
{
    public partial class algoritma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string gun = DateTime.Now.ToString();
            string conString = String.Format(@"Server=tcp:neredenyesek.database.windows.net,1433;Initial Catalog=Computerproject;Persist Security Info=False;User ID=serkanbekir;Password=serkan-94;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            string firstCommand = "SELECT COUNT(distinct ad) FROM RESTORANLAR;";
            cmd.CommandText = firstCommand;
            int restoranSayisi = (int)cmd.ExecuteScalar();
            Restoran[] restoranlar = new Restoran[restoranSayisi];
            Restoran[] restoranYedek = new Restoran[restoranSayisi];
            string secondCommand = "SELECT RESTORANLAR.ID,AD,havayaduyarlilik,puan,ulasimtipi FROM RESTORANLAR JOIN PUANLAR ON PUANLAR.RESTORANID=RESTORANLAR.ID ORDER BY puan desc";
            cmd.CommandText = secondCommand;
            SqlDataReader reader = cmd.ExecuteReader();
            int counter = 0;
            string havadurumu = "";
            while (reader.Read())
            {
                restoranlar[counter] = new Restoran(reader.GetInt32(0), reader.GetString(1),
                    reader.GetString(2),reader.GetDouble(3),  reader.GetString(4));
                restoranYedek[counter] = new Restoran(reader.GetInt32(0), reader.GetString(1),
                    reader.GetString(2), reader.GetDouble(3), reader.GetString(4));
                counter++;
            }
            reader.Close();
            string accuweather = new WebClient().DownloadString("http://apidev.accuweather.com/currentconditions/v1/318251.json?language=en&apikey=hoArfRosT1215");
            bool isRain = accuweather.Contains("Rain");
            bool isClear = accuweather.Contains("Clear");
            bool isStorm = accuweather.Contains("Storm");
            bool isShower = accuweather.Contains("Shower");
            bool isSnow = accuweather.Contains("Snow");
            bool isIce = accuweather.Contains("Ice");
            bool isFlurries = accuweather.Contains("Flurries");


            int maxDay;
            string thirdCommand = "SELECT MAX(cycleday) FROM TAKVIM;";
            cmd.CommandText = thirdCommand;
            try
                {
                   maxDay = (int)cmd.ExecuteScalar();  

                }

                catch(Exception f)
                {
                    maxDay = 0;
                }
            string cycleCommand = "SELECT DISTINCT CYCLELENGTH FROM PUANLAR;";
            cmd.CommandText = cycleCommand;
            int cycleLength = (int)cmd.ExecuteScalar();
            if (maxDay < cycleLength)
            {
                
                if (maxDay >= 1)
                { /*önceki güne bak
              maxDay'in dbden çek restoran bilgilerini kaydet ve olasılıklardan sil. Arabalıysa 
              arabalı olasılıkları da sil.*/
                    string fourthCommand = "SELECT AD FROM TAKVIM JOIN RESTORANLAR ON TAKVIM.RESTORANID=RESTORANLAR.ID WHERE TAKVIM.CYCLEDAY="
                        + maxDay.ToString() + ";";
                    cmd.CommandText = fourthCommand;
                    string ad = (string)cmd.ExecuteScalar();
                    string transportCommand = "SELECT ULASIMTIPI FROM TAKVIM JOIN RESTORANLAR ON TAKVIM.RESTORANID=RESTORANLAR.ID WHERE TAKVIM.CYCLEDAY="
                        + maxDay.ToString() + ";";
                    cmd.CommandText = transportCommand;
                    string ulasim = (string)cmd.ExecuteScalar();
                    bool araba = false;
                    if (String.Equals("Car", ulasim, StringComparison.OrdinalIgnoreCase))
                        araba = true;
                    for (int i = 0; i < restoranlar.Length; i++)
                    {
                        if (restoranlar[i] != null)
                        {
                            if (String.Equals(ad, restoranlar[i].ad, StringComparison.OrdinalIgnoreCase))
                            {
                                restoranlar[i] = null;
                            }
                            else if (araba && String.Equals("Car", restoranlar[i].ulasimTuru, StringComparison.OrdinalIgnoreCase))
                            {
                                restoranlar[i] = null;
                            }
                        }

                    }
                }
                if (maxDay >= 2)
                {
                    string fifthCommand = "SELECT ULASIMTIPI FROM TAKVIM JOIN RESTORANLAR ON TAKVIM.RESTORANID=RESTORANLAR.ID WHERE (TAKVIM.CYCLEDAY="
                        + (maxDay - 1).ToString() + " OR TAKVIM.CYCLEDAY=" + maxDay.ToString() + ");";
                    cmd.CommandText = fifthCommand;
                    string[] ulasimtipleri = new string[2];
                    SqlDataReader reader1 = cmd.ExecuteReader();
                    int counter1 = 0;
                    while (reader1.Read())
                    {
                        ulasimtipleri[counter1] = reader1.GetString(0);
                        counter1++;
                    }
                    reader1.Close();
                    if (String.Equals("Car", ulasimtipleri[0], StringComparison.OrdinalIgnoreCase)
                        || String.Equals("Car", ulasimtipleri[1], StringComparison.OrdinalIgnoreCase))
                    {
                        for (int j = 0; j < restoranlar.Length; j++)
                        {
                            if (restoranlar[j] != null)
                            {
                                if (String.Equals("Car", restoranlar[j].ulasimTuru,
                                    StringComparison.OrdinalIgnoreCase)
                                 )
                                {
                                    restoranlar[j] = null;
                                }
                            }
                        }
                    }
                    //2 önceki güne bak arabalıysa. Arabalı olasılıkları sil.
                }
                if (isRain || isFlurries || isStorm || isShower || isSnow || isIce)
                {
                    if (isRain) havadurumu = "Raining";
                    else if (isFlurries) havadurumu = "Flurries";
                    else if (isStorm) havadurumu = "Storm";
                    else if (isShower) havadurumu = "Raining";
                    else if (isSnow || isIce) havadurumu = "Snowing";
                    for (int k = 0; k < restoranlar.Length; k++)
                    {
                        if (restoranlar[k] != null)
                        {
                            if (String.Equals("Sensitive", restoranlar[k].duyarlilik, StringComparison.OrdinalIgnoreCase)                             )
                            {
                                restoranlar[k] = null;
                            }
                        }
                    }
                }
                else havadurumu = "Clear";
                int choice = -1;
                double maxPuan = 0;
                for (int m = 0; m < restoranlar.Length; m++)
                {
                    if (restoranlar[m] != null)
                    {
                        if (restoranYedek[m].puan > maxPuan
                               && (restoranlar[m].puan >= 0.5 ||
                                Math.Abs(restoranlar[m].puan - 0.5) < 0.0000001)
                            )
                        {
                            maxPuan = restoranlar[m].puan;
                            choice = m;
                        }
                    }
                }
                Restoran secilmisRestoran = null;
                if (choice == -1) // seçemedik
                {
                    for (int n = 0; n < restoranYedek.Length; n++)
                    {
                        if (restoranYedek[n] != null)
                        {
                            if (restoranYedek[n].puan > maxPuan
                                && (restoranYedek[n].puan >= 0.5 ||
                                Math.Abs(restoranYedek[n].puan - 0.5) < 0.0000001)
                                )
                            {
                                maxPuan = restoranYedek[n].puan;
                                choice = n;
                            }
                        }
                    }
                   /* if (choice == -1)
                    {
                        string eighthCommand = "UPDATE RESTORANLAR SET isVoted=0;";
                        cmd.CommandText = eighthCommand;
                        cmd.ExecuteNonQuery();
                        return;
                    }*/
                    secilmisRestoran = restoranYedek[choice];
                }
                else secilmisRestoran = restoranlar[choice];

                
                string sixthCommand = "INSERT INTO TAKVIM (restoranid,cycleday,hava) VALUES (" + secilmisRestoran.id.ToString() + ","
                    + (maxDay + 1).ToString() + ",'" + havadurumu.ToString() + "');";
                cmd.CommandText = sixthCommand;
                cmd.ExecuteNonQuery();

                string seventhCommand = "UPDATE PUANLAR SET PUAN=PUAN -1 WHERE RESTORANID="
                    + secilmisRestoran.id.ToString() + ";";
                cmd.CommandText = seventhCommand;
                cmd.ExecuteNonQuery();
                //task scheduler işi var bi de.
                string ninethCommand = "SELECT COUNT(DISTINCT AD) FROM UYELER;";
                cmd.CommandText = ninethCommand;
                int uyeSayisi = (int)cmd.ExecuteScalar();
                string[] mails = new string[uyeSayisi];

                string mailCommand = "SELECT MAIL FROM UYELER";
                cmd.CommandText = mailCommand;

                SqlDataReader readerMail = cmd.ExecuteReader();
                int counter2 = 0;
                while (readerMail.Read())
                {
                    mails[counter2] = readerMail.GetString(0);
                    counter2++;
                }
                readerMail.Close();

                string mailstring = "";

                for (int a = 0; a < uyeSayisi; a++)
                {
                    mailstring = mailstring + "," + mails[a];
                }

                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("infoneredeyesek@gmail.com", "hilalserkanyusuf");
                MailMessage mesaj = new MailMessage("infoneredeyesek@gmail.com", mailstring);
                mesaj.Subject = "Restaurant Information";
                mesaj.Body = "Today's(" + (maxDay + 1).ToString() + ".day) restaurant is " + secilmisRestoran.ad;
                client.Send(mesaj);
                con.Close();
               // Response.Redirect("~/");

            }
            else
            {
                lbldongu.Visible = true;
                string openVotes = "UPDATE RESTORANLAR SET ISVOTED=0;";
                cmd.CommandText = openVotes;
                cmd.ExecuteNonQuery();
                con.Close();
            }




        }
    }
}
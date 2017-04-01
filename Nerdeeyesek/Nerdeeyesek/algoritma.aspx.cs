﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;

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
            string firstCommand = "SELECT COUNT(distinct ad) FROM RESTORANLAR;";
            cmd.CommandText = firstCommand;
            int restoranSayisi = (int)cmd.ExecuteScalar();
            Restoran[] restoranlar = new Restoran[restoranSayisi];
            Restoran[] restoranYedek = new Restoran[restoranSayisi];
            string secondCommand = "SELECT RESTORANLAR.ID,AD,havayaduyarlilik,tampuan,ondalikpuan,ulasimtipi FROM RESTORANLAR JOIN PUANLAR ON PUANLAR.RESTORANID=RESTORANLAR.ID ORDER BY tampuan desc";
            cmd.CommandText = secondCommand;
            SqlDataReader reader = cmd.ExecuteReader();
            int counter = 0;
            while (reader.Read())
            {
                restoranlar[counter] = new Restoran(reader.GetInt32(0), reader.GetString(1),
                    reader.GetString(2),reader.GetInt32(3), 
                    reader.GetDouble(4), reader.GetString(5));
                restoranYedek[counter] = new Restoran(reader.GetInt32(0), reader.GetString(1),
                    reader.GetString(2), reader.GetInt32(3),
                    reader.GetDouble(4), reader.GetString(5));
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

            if(maxDay >=1)
            { /*önceki güne bak
              maxDay'in dbden çek restoran bilgilerini kaydet ve olasılıklardan sil. Arabalıysa 
              arabalı olasılıkları da sil.*/
                string fourthCommand = "SELECT AD FROM TAKVIM JOIN RESTORANLAR ON TAKVIM.RESTORANID=RESTORANLAR.ID WHERE TAKVIM.CYCLEDAY=" 
                    + maxDay.ToString() + ";";
                cmd.CommandText = fourthCommand;
                string ad = (string)cmd.ExecuteScalar();
                for (int i = 0; i < restoranlar.Length; i++)
                {
                    if (String.Equals(ad, restoranlar[i].ad, StringComparison.OrdinalIgnoreCase))
                    {
                        restoranlar[i] = null;
                        break;
                    }
                }
            }
            if(maxDay>=2)
            {
                string fifthCommand = "SELECT ULASIMTIPI FROM TAKVIM JOIN RESTORANLAR ON TAKVIM.RESTORANID=RESTORANLAR.ID WHERE (TAKVIM.CYCLEDAY="
                    + (maxDay-1).ToString()+" OR TAKVIM.CYCLEDAY=" + maxDay.ToString()+");";
                cmd.CommandText = fifthCommand;
                string [] ulasimtipleri=new string[2];
                 SqlDataReader reader1 = cmd.ExecuteReader();
                int counter1 = 0;
            while (reader1.Read())
            {
                ulasimtipleri[counter1]=reader1.GetString(0);
                counter1++;
            }
            reader1.Close();
            if(String.Equals("Araba",ulasimtipleri[0],StringComparison.OrdinalIgnoreCase)
                ||String.Equals("Araba",ulasimtipleri[1],StringComparison.OrdinalIgnoreCase))
            {
                for (int j = 0; j < restoranlar.Length; j++)
                {
                    if (restoranlar[j] != null)
                    {
                        if (String.Equals("Araba", restoranlar[j].ulasimTuru, 
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
            if(isRain || isFlurries || isStorm ||isShower|| isSnow || isIce)
            {
                for (int k = 0; k < restoranlar.Length; k++)
                {
                    if(restoranlar[k]!=null)
                    {
                        if(String.Equals("Orta",restoranlar[k].duyarlilik,StringComparison.OrdinalIgnoreCase)
                         || String.Equals("Çok",restoranlar[k].duyarlilik,StringComparison.OrdinalIgnoreCase)
                         )
                        {
                            restoranlar[k] = null;
                        }
                    }
                }
            }
            int choice=-1;
            int maxPuan = 0;
           for(int m=0;m<restoranlar.Length;m++)
            {
                if(restoranlar[m]!=null)
                {
                    if(restoranlar[m].tamPuan>maxPuan)
                    {
                        maxPuan = restoranlar[m].tamPuan;
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
                       if (restoranYedek[n].tamPuan > maxPuan)
                       {
                           maxPuan = restoranYedek[n].tamPuan;
                           choice = n;
                       }
                   }
               }
               secilmisRestoran = restoranYedek[choice];
           }
           else secilmisRestoran = restoranlar[choice];

           string sixthCommand = "INSERT INTO TAKVIM (restoranid,cycleday) VALUES (" + secilmisRestoran.id.ToString() + ","
               + (maxDay + 1).ToString() + ");";
           cmd.CommandText = sixthCommand;
           cmd.ExecuteNonQuery();

           string seventhCommand = "UPDATE PUANLAR SET TAMPUAN=TAMPUAN -1 WHERE RESTORANID="
               + secilmisRestoran.id.ToString() + ";";
           cmd.CommandText = seventhCommand;
           cmd.ExecuteNonQuery();
           //task scheduler işi var bi de.


        }
    }
}
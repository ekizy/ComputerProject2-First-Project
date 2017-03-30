using System;
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
            string secondCommand = "SELECT RESTORANLAR.ID,AD,havayaduyarlilik,tampuan,ondalikpuan,ulasimtipi FROM RESTORANLAR JOIN PUANLAR ON PUANLAR.RESTORANID=RESTORANLAR.ID ORDER BY tampuan desc";
            cmd.CommandText = secondCommand;
            SqlDataReader reader = cmd.ExecuteReader();
            int counter = 0;
            while (reader.Read())
            {
                restoranlar[counter] = new Restoran(reader.GetInt32(0), reader.GetString(1),
                    reader.GetString(2),reader.GetInt32(3), 
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
                if(maxDay>=2)
                {
                    //2 önceki güne bak arabalıysa. Arabalı olasılıkları sil.

                    //önce mekanı puana göre seç. 
                    // havaya hassas değilse git.
                    // havaya hassassa havaya bak güzelse git
                        // hava güzel değilse yeni opsiyon bak.
                }
                    
            } //mekanı seçtik.
            // mekanı cycle tabloya ekle. id,gerçekgün,restoranid,cyclegünü
            //mekanın puanını puanlar tablosundan 1 azalt.
            //task scheduler işi var bi de.


        }
    }
}
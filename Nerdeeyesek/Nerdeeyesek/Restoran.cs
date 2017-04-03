using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nerdeeyesek
{
    public class Restoran
    {
        public int id;
        public string ad;
        public string duyarlilik;
        public double puan;
        public string ulasimTuru;
        
        public Restoran (int id, string ad,string duyarlilik,double puan,string ulasimTuru)
        {
            this.id = id;
            this.ad = ad;
            this.duyarlilik = duyarlilik;
            this.puan = puan;
            this.ulasimTuru = ulasimTuru;
        }
        public Restoran()
        {

        }
    }
}
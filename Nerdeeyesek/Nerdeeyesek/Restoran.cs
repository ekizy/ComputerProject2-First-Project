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
        public int tamPuan;
        public float ondalikPuan;
        public string ulasimTuru;
        
        public Restoran (int id, string ad,string duyarlilik, int tamPuan,float ondalikPuan,string ulasimTuru)
        {
            this.id = id;
            this.ad = ad;
            this.duyarlilik = duyarlilik;
            this.tamPuan = tamPuan;
            this.ondalikPuan = ondalikPuan;
            this.ulasimTuru = ulasimTuru;
        }
    }
}
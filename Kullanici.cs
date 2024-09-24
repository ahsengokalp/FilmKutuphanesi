using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKutuphanesi
{
    public abstract class Kullanici //soyut sınıf
    {
        //prpoertiler
        public string AdSoyad { get; set; }
        public string TC { get; set; }
        public string DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }

        //kurucu methıt
        public Kullanici(string adSoyad, string tc, string dogumTarihi, string cinsiyet)
        {
            AdSoyad = adSoyad;
            TC = tc;
            DogumTarihi = dogumTarihi;
            Cinsiyet = cinsiyet;
        }

        public abstract void OzellikleriGoster();//abstract methot oluşturma
    }
}

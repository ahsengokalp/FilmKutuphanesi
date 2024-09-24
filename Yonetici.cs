using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKutuphanesi
{
    public class Yonetici
    {
        //propertiler
        public string AdSoyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

        //kurucu methot
        public Yonetici(string adSoyad, string kullaniciAdi, string sifre)
        {
            AdSoyad = adSoyad;
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
        }

        //film kütüphanesine film eklemek için methot
        public void FilmEkle(FilmKutuphanesi filmKutuphanesi, Film film)
        {
            filmKutuphanesi.FilmEkle(film);
            Console.WriteLine($"Yönetici {this.AdSoyad}, {film.Ad} filmi kutuphaneye ekledi.");
        }

    }

}

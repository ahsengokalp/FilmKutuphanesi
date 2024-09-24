using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKutuphanesi
{
    public class FilmKutuphanesi
    {
        //property tanimlama
        public List<Film> Filmler { get; set; }
        public List<Kullanici> Kullanicilar { get; set; }


        public FilmKutuphanesi()
        {
            Filmler = new List<Film>();
            Kullanicilar = new List<Kullanici>();
        }

        public void FilmEkle(Film film)
        {
            Filmler.Add(film);
        }

        // Kullanicilar listesine kullanıcı ekleme methodu
        public void KullaniciEkle(Kullanici kullanici)
        {
            Kullanicilar.Add(kullanici);
        }

        // Kullanicilar listesine kullanıcı silme methodu

        public void KullaniciSil(Kullanici kullanici)
        {
            Kullanicilar.Remove(kullanici);
        }

        //arama kelimesine göre filmleri bulan ve listeleyen fonksiyon
        public List<Film> FilmAra(string aramaKelimesi)
        {
            
            List<Film> bulunanFilmler = Filmler.FindAll(film =>
                film.Ad.Contains(aramaKelimesi) || //film adi, arama kelimesini içeriyorsa
                film.Yonetmen.Contains(aramaKelimesi) || // yonetmen adi arama kelimesini içeriyorsa
                film.Tur.Contains(aramaKelimesi) //film turu arama kelimesini iceriyorsa
            );
            return bulunanFilmler; //bulunanFilmleri dondür
        }


        
    }
}

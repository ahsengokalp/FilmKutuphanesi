using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKutuphanesi
{
    public class StandartKullanici:Kullanici//kullanıcıdan türeterek sınıf olusturma
    {
        //propertiyler
        public List<Film> IzlemeListesi { get; set; }
        public double UyelikUcreti { get; set; }

        //kurucu methot oluşturma
        public StandartKullanici(string adSoyad, string tc, string dogumTarihi, string cinsiyet)
            : base(adSoyad, tc, dogumTarihi, cinsiyet)
        {
            IzlemeListesi = new List<Film>();
            UyelikUcreti = 100; 
        }
        public override void OzellikleriGoster() //özellikleri gösteren soyut methot
        {
            Console.WriteLine("Standart Kullanıcı Özellikleri:");
            Console.WriteLine($"Ad Soyad: {AdSoyad}");
            Console.WriteLine($"TC: {TC}");
            Console.WriteLine($"Doğum Tarihi: {DogumTarihi}");
            Console.WriteLine($"Cinsiyet: {Cinsiyet}");
        }
    }
}

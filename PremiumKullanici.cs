using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKutuphanesi
{
    public class PremiumKullanici : Kullanici //kullanicidan türetilmiş sınıf
    {
        //propertiy leri oluşturma
        public List<Film> IzlemeListesi { get; set; }
        public double UyelikUcreti { get; set; }

        //kurucu methot
        public PremiumKullanici(string adSoyad, string tc, string dogumTarihi, string cinsiyet)
            : base(adSoyad, tc, dogumTarihi, cinsiyet)
        {
            IzlemeListesi = new List<Film>();//IzlemeListesini baslat ve uyelik ücretini hesapla
            UyelikUcreti = HesaplaUyelikUcreti();
        }

        //film ekleme methotu
        public void FilmEkle(Film film)
        {
            IzlemeListesi.Add(film);
        }

        //film çıkarma methodu
        public void FilmCikar(Film film)
        {
            IzlemeListesi.Remove(film);
        }

        public void UyelikUcretiniGuncelle()
        {
            UyelikUcreti = HesaplaUyelikUcreti();
        }

        //üyelik ücreti için methot
        private double HesaplaUyelikUcreti()
        {
            double baslangicUcreti = 100;
            double artisOrani = 0.25;

            return baslangicUcreti * (1 + artisOrani);
        }

        public override void OzellikleriGoster()//kulllanıcı özelliklerini gösteren abstact methot
        {
            Console.WriteLine("Premium Kullanıcı Özellikleri:");
            Console.WriteLine($"Ad Soyad: {AdSoyad}");
            Console.WriteLine($"TC: {TC}");
            Console.WriteLine($"Doğum Tarihi: {DogumTarihi}");
            Console.WriteLine($"Cinsiyet: {Cinsiyet}");

        }
    }
}

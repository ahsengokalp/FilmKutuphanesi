using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmKutuphanesi
{
    public partial class FormKullanıcıKayıt : Form
    {
        public FormKullanıcıKayıt()
        {
            InitializeComponent();
        }
        //veritabanına baglanma 
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=9999; Database=dbfilm; user Id=postgres; password=1234");

        //
        private void KullaniciOzellikleriGoster(Kullanici kullanici)
        {
            kullanici.OzellikleriGoster();
        }
        private void btnKayit_Click(object sender, EventArgs e)
        {
            Kullanici yeniKullanici = new StandartKullanici(
                      adSoyad: $"{txtAd.Text} {txtSoyad.Text}",
                       tc: txtTc.Text,
                       dogumTarihi: txtDogum.Text,
                       cinsiyet: cmbCinsiyet.SelectedItem.ToString()
                        ); //yeni kullanici nesnesi oluşturma

            //cmbHesapTuru'nden secilen ögenin Premium olup olmadığını kontrol etme
            bool isPremium = cmbHesapTuru.SelectedItem.ToString() == "Premium"; 
            baglanti.Open(); //veritabanı baglantisinin acilmasi
            //veritabanına ekleme yapacak NpgsqlCommand nesnesi oluşturma
            NpgsqlCommand komut1 = new NpgsqlCommand("Insert into kullanici (adi, soyadi, kullaniciadi, sifre, tc, dogumtarihi, cinsiyet, premium) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)", baglanti);
           //veritabanına bilgileri girme
            komut1.Parameters.AddWithValue("p1", txtAd.Text);
            komut1.Parameters.AddWithValue("p2", txtSoyad.Text);
            komut1.Parameters.AddWithValue("p3", txtKulAdi.Text);
            komut1.Parameters.AddWithValue("p4", txtSifre.Text);
            komut1.Parameters.AddWithValue("p5", BigInteger.Parse(txtTc.Text));
            komut1.Parameters.AddWithValue("p6", txtDogum.Text);
            komut1.Parameters.AddWithValue("p7", cmbCinsiyet.SelectedItem.ToString());
            komut1.Parameters.AddWithValue("p8", isPremium); komut1.ExecuteNonQuery();
            baglanti.Close();//veritabani baglantisini kapatma
            MessageBox.Show("Kullanıcı Kaydınız Başarıyla Oluşturuldu.");
            this.Close();//form sayfasını kapatma
            KullaniciOzellikleriGoster(yeniKullanici);//Yeni kullanıcı özelliklerini gösteren bir metodu çağırma
        }
    }
}


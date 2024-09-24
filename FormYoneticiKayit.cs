using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmKutuphanesi
{
    public partial class FormYoneticiKayit : Form
    {
        public FormYoneticiKayit()
        {
            InitializeComponent();
        }
        //veri tabanı baglantısı
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=9999; Database=dbfilm; user Id=postgres; password=1234");

        private void btnKayit_Click(object sender, EventArgs e)
        {
            Yonetici yeniYonetici = new Yonetici(
                adSoyad: txtAdsoyad.Text,
                kullaniciAdi: txtKulAdi.Text,
                sifre: txtSifre.Text
            );// yeni yönetici nesnesi oluştur
            baglanti.Open(); //baglantıyı ac
            //yonetici bilgilerinin eklenme sorgusunı kommut1 e ata
            NpgsqlCommand komut1 = new NpgsqlCommand("Insert into yoneticiler (adi, kullaniciadi, sifre) values (@p1, @p2, @p3)", baglanti);
           //parametrelerin girisi
            komut1.Parameters.AddWithValue("@p1", txtAdsoyad.Text);
            komut1.Parameters.AddWithValue("@p2", txtKulAdi.Text);
            komut1.Parameters.AddWithValue("@p3", txtSifre.Text);
            //sql sorgusunu calıştırma
            komut1.ExecuteNonQuery();
            baglanti.Close();//baglantıyı kapatma
            MessageBox.Show("Yönetici Kaydınız Başarıyla Oluşturuldu.");
            this.Close();//sayfayı kapatma
        }
    }
}

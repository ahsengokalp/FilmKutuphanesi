using FilmKutuphanesi;
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
    public partial class FormKullaniciGiris : Form
    {
        public FormKullaniciGiris()
        {
            InitializeComponent();
        }

        private void FormKullaniciGiris_Load(object sender, EventArgs e)
        {

        }
        //veri tabanina baglanmak icin 
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=9999; Database=dbfilm; user Id=postgres; password=1234");

        private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();//baglantiyi acma
            NpgsqlCommand komut1 = new NpgsqlCommand("Select * From kullanici Where kullaniciadi = @p1 and sifre = @p2", baglanti);//kullanici tablosundaki kullanici adi ve sifresini veritabanından cekme
            //parametreleri atama
            komut1.Parameters.AddWithValue("@p1", txtKulAdi.Text); 
            komut1.Parameters.AddWithValue("@p2", txtSifre.Text);
            //veritabanındaki veriler okunmaya başlama
            NpgsqlDataReader dr = komut1.ExecuteReader();
            if (dr.Read()) //eger okunursa
            {

                //veritabanından bilgileri alma
                int kullaniciID = Convert.ToInt32(dr["id"]);
                string ad = dr["adi"].ToString();
                string soyad = dr["soyadi"].ToString();
                string kullaniciadi = dr["kullaniciadi"].ToString();
                string sifre = dr["sifre"].ToString();
                string tc = dr["tc"].ToString();
                string dogumtarihi = dr["dogumtarihi"].ToString();
                string cinsiyet = dr["cinsiyet"].ToString();


                FormKullaniciSayfa fr = new FormKullaniciSayfa();
                //form kullanıcısayfadaki kullanicibilgileriniAyarla fonksiyonuna parametreleri gönderme
                fr.KullaniciBilgileriniAyarla(ad, soyad, kullaniciadi, sifre, tc, dogumtarihi, cinsiyet,kullaniciID);
                fr.Show();

                this.Close();
                
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("\"Yanlış Kullanıcı Adı veya Şifre Girdiniz!!!\"");
            }
        }

        private void linkKayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormKullanıcıKayıt fr = new FormKullanıcıKayıt(); //kayıt sayfasınna gitme
            fr.Show();
        }
    }
}

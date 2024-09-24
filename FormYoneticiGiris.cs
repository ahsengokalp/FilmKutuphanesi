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
    public partial class FormYoneticiGiris : Form
    {
        public FormYoneticiGiris()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=9999; Database=dbfilm; user Id=postgres; password=1234");
 
        private void btnGiris_Click(object sender, EventArgs e)
        {

            baglanti.Open();//baglantıyı acma
            //yoneticiler tablosundan kullanıcı adı ve sifre bilgilerini arama
            NpgsqlCommand komut1 = new NpgsqlCommand("Select * From yoneticiler Where kullaniciadi = @p1 and sifre = @p2", baglanti);
           //parametreleri ekleme
            komut1.Parameters.AddWithValue("@p1", txtKulAdi.Text);
            komut1.Parameters.AddWithValue("@p2", txtSifre.Text);
            //sql sorgu sonuclarını okuma
            NpgsqlDataReader dr = komut1.ExecuteReader();
            if (dr.Read())//bulunursa
            {
                FormYoneticiSayfa fr = new FormYoneticiSayfa();//yonetici sayfasını aç
                fr.Show();
                this.Close();
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre Girdiniz!!!");
            }
        }

        private void linkKayit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormYoneticiKayit fr = new FormYoneticiKayit();//kayıt sayfasına gitme
            fr.Show();
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKulAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

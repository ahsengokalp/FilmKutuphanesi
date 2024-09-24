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
    public partial class FormKullaniciSil : Form
    {
        public FormKullaniciSil()
        {
            InitializeComponent();
        }
        //veri tabanına bağlanma
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=9999; Database=dbfilm; user Id=postgres; password=1234");

        private void btnGiris_Click(object sender, EventArgs e)
        {
            //sifre bilgisini kullanıcıdan alma
            string sifre = txtKulAdi.Text;
            baglanti.Open();//baglantı acma
            //belirlenenen kullanıcıyı veritabanından silme
            NpgsqlCommand komut = new NpgsqlCommand("Delete From kullanici Where kullaniciadi = @p1 and sifre = @p2", baglanti);
            komut.Parameters.AddWithValue("@p1", sifre);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            //sorgunnun etkilendiği satır sayısıni atama
            int etki = komut.ExecuteNonQuery();
            if (etki > 0)
            {
                MessageBox.Show("Profil Başarıyla Silinmiştir.");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre Girdiniz!!!");
                baglanti.Close();
            }
        }
    }
}

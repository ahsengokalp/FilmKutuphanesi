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
    public partial class FormPremium : Form
    {
        public FormPremium()
        {
            InitializeComponent();
        }
        private FormKullaniciSayfa kullaniciSayfa; 
        //veritabana bağlanma bağlantısı
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=9999; Database=dbfilm; user Id=postgres; password=1234");

        public FormPremium(FormKullaniciSayfa kullaniciSayfa)
        {
            InitializeComponent();
            this.kullaniciSayfa = kullaniciSayfa;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();//baglantıyı açma

            //premium kolonunu kontrol etme
            NpgsqlCommand kontrolKomut = new NpgsqlCommand("SELECT premium FROM kullanici WHERE kullaniciadi = @p1", baglanti);
            kontrolKomut.Parameters.AddWithValue("@p1", txtKulAdi.Text);

            bool kullaniciPremium = false; //ilk değer olarak false atadık

            //kolon okuma
            using (NpgsqlDataReader reader = kontrolKomut.ExecuteReader())
            {
                if (reader.Read())
                {
                    kullaniciPremium = reader.GetBoolean(0);
                }
            }

            
            if (kullaniciPremium)//kullanıcı premium durumu true ise
            {
                baglanti.Close();
                MessageBox.Show("Hesabınız zaten premium.");
            }
            else
            {
                //kullanıcıyı premium yap
                NpgsqlCommand komut1 = new NpgsqlCommand("UPDATE kullanici SET premium = true WHERE kullaniciadi = @p1", baglanti);
                komut1.Parameters.AddWithValue("@p1", txtKulAdi.Text);
                komut1.ExecuteNonQuery();
                baglanti.Close();

                this.Hide();
                MessageBox.Show("Ödeme işleminiz başarıyla gerçekleşti. Hesabınız artık premium.");
            }
        }

    }
}

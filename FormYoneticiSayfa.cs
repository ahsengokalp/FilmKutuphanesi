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
    public partial class FormYoneticiSayfa : Form
    {
        public FormYoneticiSayfa()
        {
            InitializeComponent();
        }
        //veri tabanı bağlantısı
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=9999; Database=dbfilm; user Id=postgres; password=1234");

        private int GetFilmId(string filmAdi)
        {

            NpgsqlCommand filmidAl = new NpgsqlCommand("SELECT id FROM filmler WHERE adi = @p1", baglanti);
            filmidAl.Parameters.AddWithValue("@p1", filmAdi);

            // Veritabanından film ID'sini alıyoruz
            object result = filmidAl.ExecuteScalar();

            // Eğer film bulunamazsa -1 döndürülebilir veya başka bir hata kontrolü yapılabilir
            return result != null ? Convert.ToInt32(result) : -1;
        }
        private void btnFilmEkle_Click(object sender, EventArgs e)
        {
            FilmKutuphanesi filmKutuphanesi = new FilmKutuphanesi(); //yeni film kütüphanesi nesnesi oluşturma
            Yonetici myYonetici = new Yonetici("Yonetici Adı", "yonetici_kullanici_adi", "yonetici_sifre"); //yonetici nesnesi oluşturma
            Film yeniFilm = new Film(
            ad: txtFilmAdi.Text,
            yonetmen: txtFilmYonetmen.Text,
            oyuncular: new List<string>(),
            tur: txtFilmTur.Text,
            yayinYili: txtFilmYayinYili.Text,
            degerlendirmePuani: 0.0
            );// yeni film nesnesi oluşturma
            try
            {
                baglanti.Open();//baglantıyı acma

                //film ekleyen sorguyu filmEkleKomuta atama
                NpgsqlCommand filmEkleKomut = new NpgsqlCommand("INSERT INTO filmler (adi, yonetmen, tur, yayinyili) VALUES (@p1, @p2, @p3, @p4) RETURNING id", baglanti);
                //parametreleri ekleme
                filmEkleKomut.Parameters.AddWithValue("@p1", txtFilmAdi.Text);
                filmEkleKomut.Parameters.AddWithValue("@p2", txtFilmYonetmen.Text);
                filmEkleKomut.Parameters.AddWithValue("@p3", txtFilmTur.Text);
                filmEkleKomut.Parameters.AddWithValue("@p4", txtFilmYayinYili.Text);

                //film idsini veritanından alma
                int filmId = (int)filmEkleKomut.ExecuteScalar();

                
                string[] oyuncular = richOyuncular.Text.Split(',');//virgüllerinden ayırarak oyuncuları diziye ekleme

                foreach (string oyuncu in oyuncular)
                {
                    //herbir oyuncu için insert methodu oluşturma
                    NpgsqlCommand oyuncuEkleKomut = new NpgsqlCommand("INSERT INTO oyuncular (adi, filmid) VALUES (@p5, @p6)", baglanti);
                    //sorguda kullanılacak parametreleri belirleme
                    oyuncuEkleKomut.Parameters.AddWithValue("@p5", oyuncu.Trim());
                    oyuncuEkleKomut.Parameters.AddWithValue("@p6", filmId);
                    //insert sorgusunu veritabanında çalıştırma
                    oyuncuEkleKomut.ExecuteNonQuery();
                }
                myYonetici.FilmEkle(filmKutuphanesi, yeniFilm); //myyonetici classıı film ekleme methotunun kullanılması
                MessageBox.Show("Film başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();//en sonunda baglantıyı kapatma
            }

        }
        private void btnFilmDuzAra_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Select * from filmler Where adi = @p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtAraDuz.Text);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        }
        private void btnFilmSilAra_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("Select * from filmler Where adi = @p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", txtAraSil.Text);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void btnDznle_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void btnFilmDuzAra_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();//baglantı ac
                //ada göre veritabanında arama
                NpgsqlCommand komut2 = new NpgsqlCommand("Select * from filmler Where adi = @p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", txtAraDuz.Text); //parametreyi ayarlma

                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut2); 
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0) // eger sorguda en az bir satır varsa
                {
                    DataRow row = dt.Rows[0]; //ilk satırı alma
                    //film bilgilerini textboxlara atama
                    FAdGuncelletextBox.Text = row["adi"].ToString();
                    FTurGuncelleTextBox.Text = row["tur"].ToString();
                    YonetmenAdGuncelleTextBox.Text = row["yonetmen"].ToString();
                    FYayinYiliGuncelleTextBox.Text = row["yayinyili"].ToString();
                    //film idsi ile film ile ilişkili oyuncuları getirme
                    int filmId = Convert.ToInt32(row["id"]); 
                    NpgsqlCommand oyuncuKomut = new NpgsqlCommand("Select * from oyuncular Where filmid = @p1", baglanti);
                    oyuncuKomut.Parameters.AddWithValue("@p1", filmId);

                    NpgsqlDataAdapter oyuncuDa = new NpgsqlDataAdapter(oyuncuKomut);
                    DataTable oyuncuDt = new DataTable();
                    oyuncuDa.Fill(oyuncuDt);
                    //oyuncuları görüntüleme
                    foreach (DataRow oyuncuRow in oyuncuDt.Rows)
                    {
                        OyuncularGuncelleRichTextBox.AppendText(oyuncuRow["adi"].ToString() + Environment.NewLine);
                    }
                }
                else
                {
                    MessageBox.Show("Film bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnFilmDuzKayd_Click(object sender, EventArgs e)
        {
            baglanti.Open();//veri tabanını aç
            //kullanıcıdan bilgileri alma
            string adi = FAdGuncelletextBox.Text;
            string tur = FTurGuncelleTextBox.Text;
            string yonetmen = YonetmenAdGuncelleTextBox.Text;
            string yayinYili = FYayinYiliGuncelleTextBox.Text;
            //sorgu oluşturma
            NpgsqlCommand updateCommand = new NpgsqlCommand("UPDATE filmler SET tur = @tur, yonetmen = @yonetmen, yayinyili = @yayinYili WHERE adi = @adi", baglanti);
            //parametreleri ayarlama
            updateCommand.Parameters.AddWithValue("@adi", adi);
            updateCommand.Parameters.AddWithValue("@tur", tur);
            updateCommand.Parameters.AddWithValue("@yonetmen", yonetmen);
            updateCommand.Parameters.AddWithValue("@yayinYili", yayinYili);

            //sql sorgusunu çalıştırınca etkilenecek satır sayısını alma
            int affectedRows = updateCommand.ExecuteNonQuery();

            if (affectedRows > 0)//etkilenen satır olursa
            {
                MessageBox.Show("Film başarıyla güncellendi.");
            }
            else
            {
                MessageBox.Show("Film güncellenirken bir hata oluştu.");
            }
            baglanti.Close();
        }

        private void SilButton_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                NpgsqlCommand komut1 = new NpgsqlCommand("SELECT id FROM filmler WHERE adi = @p1", baglanti);
                komut1.Parameters.AddWithValue("@p1", txtAraSil.Text);

                int id = 0;

                using (NpgsqlDataReader reader = komut1.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = reader.GetInt32(0); // Veya doğru indeks değerini belirleyin
                    }
                }
                NpgsqlCommand komut3 = new NpgsqlCommand("DELETE FROM oyuncular WHERE filmid = @p1", baglanti);
                komut3.Parameters.AddWithValue("@p1", id);
                komut3.ExecuteNonQuery();

                NpgsqlCommand komut2 = new NpgsqlCommand("DELETE FROM filmler WHERE adi = @p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", txtAraSil.Text);
                komut2.ExecuteNonQuery();

                MessageBox.Show("Silme İşlemi Başarıyla Gerçekleşti!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata:",ex.Message);
            }
            finally 
            {
                baglanti.Close();
            }

            
        }
        private void ListViewYazdırma(NpgsqlCommand command)
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            SilinecekListView.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["adi"].ToString());
                item.SubItems.Add(row["puan"].ToString());
                item.SubItems.Add(row["yayinyili"].ToString());
                item.SubItems.Add(row["yonetmen"].ToString());
                item.SubItems.Add(row["tur"].ToString());

                SilinecekListView.Items.Add(item);
            }
        }

        private void btnFilmSilAra_Click_1(object sender, EventArgs e)
        {
            string aranacak = txtAraSil.Text;//silinecek film bilgisini kullanıcıdan alma
            string selectQuery = "SELECT * FROM filmler WHERE adi = @aranacak"; //filmi bulma sorgusu
            NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, baglanti);
            selectCommand.Parameters.AddWithValue("@aranacak", aranacak);//parametreleri ayarlama
            ListViewYazdırma(selectCommand);//yazdırmak için fonksiyon çağırma
            baglanti.Close();//baglantıyı kapatma
        }
    }
}

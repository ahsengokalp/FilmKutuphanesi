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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Numerics;

namespace FilmKutuphanesi
{
    public partial class FormKullaniciSayfa : Form
    {
        public FormKullaniciSayfa()
        {
            InitializeComponent();
            InitializeNotifyIcon(); //notifyicon sayfa açıldığında çalışması

        }
        //veritabanı bağlantısı
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=9999; Database=dbfilm; user Id=postgres; password=1234");

        // form içinde dolaşma butonları
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

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        private void btnAra_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
        private void btnDeg_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }
        private void btnEn_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;

        }
        private void btnProfil_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }


        //kullanici silme formuna gotüren fonksiyon
        private void btnHesapKapat_Click(object sender, EventArgs e)
        {
            FormKullaniciSil fr = new FormKullaniciSil();
            fr.Show();
        }

        //premium sayfsına gotüren fonksiyon
        private void btnPremium_Click(object sender, EventArgs e)
        {
            FormPremium fr = new FormPremium();
            OpenPremiumForm();
            fr.Show();
        }



        private void btnFilmDuzAra_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (FilmAdiradioButton.Checked)
            {
                NpgsqlCommand komut1 = new NpgsqlCommand("Select * from filmler Where adi = @p1", baglanti);
                komut1.Parameters.AddWithValue("@p1", txtArama.Text);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();

            }

        }

        private void btnFilmDegAra_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("Select * from filmler Where adi = @p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", txtArama.Text);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();

        }

        private void GuncelleButton_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            string komut = "SELECT * FROM filmler ORDER BY puan DESC LIMIT 10";
            NpgsqlCommand bulunan = new NpgsqlCommand(komut, baglanti);

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(bulunan);
            DataTable dt = new DataTable();
            da.Fill(dt);

            listView1.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["adi"].ToString());
                item.SubItems.Add(row["puan"].ToString());

                listView1.Items.Add(item);
            }
        }

        //film arama butonu
        private void btnFilmDuzAra_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();//baglanyiyi ac

                string aranan = txtArama.Text; //aranacak kelimeyi arama değişkenine ata

                if (FilmAdiradioButton.Checked) //filmadi radiobutonu seçili ise
                {
                    // Filmler tablosunda arama
                    string komut = "SELECT * FROM filmler WHERE adi = @searchValue";
                    NpgsqlCommand bulunan = new NpgsqlCommand(komut, baglanti);
                    bulunan.Parameters.AddWithValue("@searchValue", aranan);

                    FillListView(bulunan);//Listelemek için olan fonksiyonu cagir
                }
                else if (YonetmenAdradioButton.Checked) //yonetmenadi radiobutonu seçili ise
                {
                    // filmler tablosunda yönetmen adına göre arama
                    string komut = "SELECT * FROM filmler WHERE yonetmen = @searchValue";
                    NpgsqlCommand bulunan = new NpgsqlCommand(komut, baglanti);
                    bulunan.Parameters.AddWithValue("@searchValue", aranan);

                    FillListView(bulunan);//Listelemek için olan fonksiyonu cagir
                }
                else if (FilmTururadioButton.Checked)
                {
                    // filmler tablosunda türüne göre sorgula
                    string komut = "SELECT * FROM filmler WHERE tur = @searchValue";
                    NpgsqlCommand bulunan = new NpgsqlCommand(komut, baglanti);
                    bulunan.Parameters.AddWithValue("@searchValue", aranan);

                    FillListView(bulunan);//Listelemek için olan fonksiyonu cagir
                }
            }
            catch (Exception h) //hata alırsa h ye ata message box ile hatayı göster
            {
                MessageBox.Show(h.Message);
            }
            finally
            {
                baglanti.Close(); //islemler bittiginde baglantiyi kapat
            }
        }

        private void FillListView(NpgsqlCommand command) //list viewe yazdırmak için fonksiyon
        {
            //NpgsqlCommand nesnesi üzerinden veritabanından veri çekme ve DataTable nesnesine doldurma
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);
            //dt adında datatable nesnesi oluşturma
            DataTable dt = new DataTable();
            //veritabanından gelen verileri DataTable nesnesine doldurma
            da.Fill(dt);

            listView2.Items.Clear();

            //listviewe bilgileri girme
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem item = new ListViewItem(row["adi"].ToString());
                item.SubItems.Add(row["puan"].ToString());
                item.SubItems.Add(row["yayinyili"].ToString());
                item.SubItems.Add(row["yonetmen"].ToString());
                item.SubItems.Add(row["puan"].ToString());
                item.SubItems.Add(row["tur"].ToString());

                listView2.Items.Add(item);
            }
        }

        private void btnPremium_Click_1(object sender, EventArgs e)
        {
            FormPremium formPremium = new FormPremium(); //premium sayfasına gitme
            formPremium.Show();
        }


        private void btnHesapKapat_Click_1(object sender, EventArgs e)
        {
            FormKullaniciSil formKullaniciSil = new FormKullaniciSil(); //hesap kapatma sayfasına gitme
            formKullaniciSil.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;

        }

        private void btnDeg_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;

        }

        private void btnEn_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;

        }

        private void btnProfil_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void btnProfGun_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("UPDATE kullanici SET adi = @p1, soyadi = @p2, kullaniciadi = @p3, sifre = @p4, tc = @p5, dogumtarihi =  @p6 where id=@p7", baglanti);
            komut1.Parameters.AddWithValue("@p1", textBox10.Text);
            komut1.Parameters.AddWithValue("@p2", textBox9.Text);
            komut1.Parameters.AddWithValue("@p3", textBox8.Text);
            komut1.Parameters.AddWithValue("@p4", textBox4.Text);
            komut1.Parameters.AddWithValue("@p5",BigInteger.Parse(textBox7.Text));
            komut1.Parameters.AddWithValue("@p6", textBox3.Text);
            komut1.Parameters.AddWithValue("@p7",Convert.ToInt32( lblID.Text));
            
            komut1.ExecuteNonQuery();
            baglanti.Close();
        }
        public void KullaniciBilgileriniAyarla(string ad, string soyad, string kullaniciadi, string sifre, string tc, string dogumtarihi, string cinsiyet,int kullaniciID)
        {
            textBox10.Text = ad;
            textBox9.Text = soyad;
            textBox8.Text = kullaniciadi;
            textBox4.Text = sifre;
            textBox7.Text = tc;
            textBox3.Text = dogumtarihi;
            comboBox1.SelectedItem = cinsiyet;
            lblID.Text=kullaniciID.ToString();
        }

        private void GuncelleButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                // filmleri puanlarına göre azalan şekilde sıralama
                string selectQuery = "SELECT * FROM filmler ORDER BY puan DESC LIMIT 10";
                //filmleri degerlendirme sayilarina göre azalan şekilde sıralama
                string selectQuery2 = "SELECT * FROM filmler ORDER BY degerlendirme_sayisi DESC LIMIT 10";

                //verileri veri tabanından al
                NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, baglanti);
                NpgsqlCommand selectCommand2 = new NpgsqlCommand(selectQuery2, baglanti);

                //eritabanından verileri çek ve DataTable nesnesine doldur
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(selectCommand);
                NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(selectCommand2);
                //DataTable nesnelerinin bellekteki tablo yapısıyla veritabanından çekilen veriyi sakla
                DataTable dt = new DataTable();
                DataTable dt2 = new DataTable();
                //veritabanından çekilen veriyi DataTable nesnesine doldur
                da.Fill(dt);
                da2.Fill(dt2);

                // ListViewleri temizleme
                listView3.Items.Clear();
                listView4.Items.Clear();


                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["adi"].ToString()); //adi kolonundaki veriyi al
                    item.SubItems.Add(row["puan"].ToString()); //adi kolonuna karşılık gelen puan kolonunu al

                    listView3.Items.Add(item); //verileri listviewe ekle
                }
                foreach (DataRow row in dt2.Rows)
                {
                    ListViewItem item = new ListViewItem(row["adi"].ToString());//adi kolonundaki veriyi al
                    item.SubItems.Add(row["degerlendirme_sayisi"].ToString());//adi kolonuna karşılık gelen degerlendirme_sayisi kolonunu verisini a

                    listView4.Items.Add(item);//verileri listviewe ekle
                }

            }
            catch (Exception ex) //hata alırsan hatayı messsagebox yoluyla göster
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void btnFilmDegAra_Click_1(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();//baglantiyi ac

                string filmAdi = FilmAdiTextBox.Text;//aranacak kelimeyi  filmAdi degiskenine ata

                //filmeler tablosundan ad göre arama yapma
                string selectQuery = "SELECT * FROM filmler WHERE adi = @filmAdi";
                //veritabanında çalıştırılacak sorguyu temsil eden bir NpgsqlCommand nesnesi oluşturma
                NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, baglanti);
                //Sorgu içinde kullanılacak parametre ekleme
                selectCommand.Parameters.AddWithValue("@filmAdi", filmAdi);
                //veritabanından veri çekmek ve DataTable nesnesine doldurma
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(selectCommand);
                //DataTable nesnelerinin bellekteki tablo yapısıyla veritabanından çekilen veriyi saklama
                DataTable dt = new DataTable();
                //veritabanından çekilen veriyi DataTable nesnesine doldurma
                da.Fill(dt);

                //listView temizleme
                listView1.Items.Clear();

                foreach (DataRow row in dt.Rows) //satırdaki verileri sırsaıyla al ve listviewe ekle
                {
                    ListViewItem item = new ListViewItem(row["adi"].ToString());
                    item.SubItems.Add(row["puan"].ToString());
                    item.SubItems.Add(row["yayinyili"].ToString());
                    item.SubItems.Add(row["yonetmen"].ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)//hata çıkarsa messagebox aracışığı ile bildirme
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        
        private void OpenPremiumForm()
        {
            FormPremium premiumForm = new FormPremium(this); //FormKullaniciSayfasına gitme
            premiumForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();//baglantı ac

                //film adını kullanıcıdan al
                string filmAdi = FilmAdiTextBox.Text;
                string kullaniciAdi = textBox8.Text;

                //kullanıcı adına göre kullanıcının premium bilgisini al
                string selectUserQuery = "SELECT premium FROM kullanici WHERE kullaniciadi = @kullaniciAdi";
                NpgsqlCommand selectUserCommand = new NpgsqlCommand(selectUserQuery, baglanti);
                selectUserCommand.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                string tur = Convert.ToString(selectUserCommand.ExecuteScalar());


                //değerlendirme puanını alma
                int degerlendirmePuan = Convert.ToInt32(DegerlendirmePuaniTextBox.Text);

                //eğer Premium verisi true ise, film adına göre puanı ekleyin
                if (tur == "True")
                {
                    //film adına göre filmi filmler tablosundan bul
                    string selectQuery = "SELECT * FROM filmler WHERE adi = @filmAdi";
                    // NpgsqlCommand nesnesi oluşturuluyor ve sorgu parametreleri atama
                    NpgsqlCommand selectCommand = new NpgsqlCommand(selectQuery, baglanti);
                    selectCommand.Parameters.AddWithValue("@filmAdi", filmAdi);
                    //
                    using (NpgsqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())//film bulunursa
                        {
                            //eğer puan değeri null ise 0 döndür değilse puan değerini intager a çevirir mevcut puana ata
                            double mevcutPuan = reader["puan"] is DBNull ? 0 : Convert.ToInt32(reader["puan"]);
                            //eger degerlendirme sayisi boşsa 0 değilse içindeki degeri değiskene ata
                            int mevcutDegerlendirmeSayisi = reader["degerlendirme_sayisi"] is DBNull ? 0 : Convert.ToInt32(reader["degerlendirme_sayisi"]);
                            //mevcut degerlendirme sayısına 1 ekle
                            int yeniDegerlendirmeSayisi = mevcutDegerlendirmeSayisi + 1;
                            //yeni puan ortalamasını hesapllama
                            double yeniPuan = (mevcutPuan * mevcutDegerlendirmeSayisi + degerlendirmePuan) / yeniDegerlendirmeSayisi; // Yeni puanı hesapla (ortalama)
                            reader.Close(); //okumayı durdur

                            //film puanını güncelle
                            string updateQuery = "UPDATE filmler SET puan = @yeniPuan, degerlendirme_sayisi = @yeniDegerlendirmeSayisi WHERE adi = @filmAdi";
                            //
                            NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, baglanti);
                            //sorguya parametreler ekleyip bu parametrelerin sorguda kullanılacak yer tutuculara değer sağlamasını sağlama
                            updateCommand.Parameters.AddWithValue("@yeniPuan", yeniPuan);
                            updateCommand.Parameters.AddWithValue("@yeniDegerlendirmeSayisi", yeniDegerlendirmeSayisi);
                            updateCommand.Parameters.AddWithValue("@filmAdi", filmAdi);
                            //sql sorgusunu calistirma
                            updateCommand.ExecuteNonQuery();

                            MessageBox.Show("Değerlendirme puanı başarıyla güncellendi.");
                           
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen film bulunamadı.");
                        }
                    }
                    listView1.Items.Clear();
                }
                else
                {
                    //kullanici premium değilse
                    MessageBox.Show("Değerlendirme için Premium kullanıcı olmalısınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void InitializeNotifyIcon()
        {
            notifyIcon1 = new NotifyIcon();
            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.Visible = true;
            notifyIcon1.Text = "Eklenen Filmler";

            notifyIcon1.BalloonTipTitle = "Eklenen Filmler:";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

            //NpgsqlConnection oluştur
            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=9999; Database=dbfilm; user Id=postgres; password=1234"))
            {
                baglanti.Open();

                //filmleri alma
                using (NpgsqlCommand komut1 = new NpgsqlCommand("SELECT adi FROM filmler", baglanti))
                {
                    using (NpgsqlDataReader reader = komut1.ExecuteReader())
                    {
                        //film adlarını okuyup NotifyIcon üzerinde gösterme
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string filmAdi = reader.GetString(0);
                                notifyIcon1.BalloonTipText += filmAdi + Environment.NewLine;
                            }
                        }
                    }
                }
            }

            notifyIcon1.ShowBalloonTip(2000);

            notifyIcon1.DoubleClick += (s, e) =>
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
            };
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//gerekli kütüphanelerin import edilmesi

namespace FilmKutuphanesi
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
            InitializeNotifyIcon();//sayfa açıldığında notifyicon fonksiyonunun çalışması
            
        }

        private void btnYonetici_Click(object sender, EventArgs e)
        {
            FormYoneticiGiris fr = new FormYoneticiGiris(); //yonetici giris sayfasının acılması
            fr.Show();
        }

        private void btnKullanici_Click(object sender, EventArgs e)
        {
            FormKullaniciGiris fr = new FormKullaniciGiris(); //butona basıldığında kullanıcı giris sayfasının acilmasi
            fr.Show();
        }
        private void InitializeNotifyIcon()
        {
            // notifyicon nesnesi oluşturma
            notifyIcon1 = new NotifyIcon();
            notifyIcon1.Icon = SystemIcons.Information;
            notifyIcon1.Visible = true; // bildirim simgesi görüntülemek için
            notifyIcon1.Text = "Hoşgeldiniz!";
            notifyIcon1.BalloonTipTitle = "Film Kütüphanesine Hoşgeldiniz!";
            notifyIcon1.BalloonTipText = "Mutlu Seyirler!";
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ShowBalloonTip(2000);


            notifyIcon1.DoubleClick += (s, e) =>
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
            };
        }
    }
}

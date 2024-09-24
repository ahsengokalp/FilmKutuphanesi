namespace FilmKutuphanesi
{
    partial class Anasayfa
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anasayfa));
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnKullanici = new System.Windows.Forms.Button();
            this.btnYonetici = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(397, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(298, 59);
            this.label5.TabIndex = 13;
            this.label5.Text = "Hoşgeldiniz";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(296, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(466, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Lütfen Giriş Yapmak İstediğiniz Türü Seçiniz.";
            // 
            // btnKullanici
            // 
            this.btnKullanici.BackColor = System.Drawing.Color.Transparent;
            this.btnKullanici.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnKullanici.BackgroundImage")));
            this.btnKullanici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnKullanici.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKullanici.FlatAppearance.BorderSize = 0;
            this.btnKullanici.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKullanici.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnKullanici.Location = new System.Drawing.Point(609, 369);
            this.btnKullanici.Name = "btnKullanici";
            this.btnKullanici.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnKullanici.Size = new System.Drawing.Size(121, 108);
            this.btnKullanici.TabIndex = 11;
            this.btnKullanici.TabStop = false;
            this.btnKullanici.UseVisualStyleBackColor = false;
            this.btnKullanici.Click += new System.EventHandler(this.btnKullanici_Click);
            // 
            // btnYonetici
            // 
            this.btnYonetici.BackColor = System.Drawing.Color.Transparent;
            this.btnYonetici.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnYonetici.BackgroundImage")));
            this.btnYonetici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnYonetici.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYonetici.FlatAppearance.BorderSize = 0;
            this.btnYonetici.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYonetici.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnYonetici.Location = new System.Drawing.Point(344, 369);
            this.btnYonetici.Name = "btnYonetici";
            this.btnYonetici.Size = new System.Drawing.Size(121, 108);
            this.btnYonetici.TabIndex = 10;
            this.btnYonetici.UseVisualStyleBackColor = false;
            this.btnYonetici.Click += new System.EventHandler(this.btnYonetici_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(628, 498);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Kullanıcı Giriş";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(340, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Yönetici Giriş";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Tomato;
            this.label1.Location = new System.Drawing.Point(208, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(667, 172);
            this.label1.TabIndex = 7;
            this.label1.Text = "Film Kütüphanesi\r\nYönetim Sistemi ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1088, 657);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnKullanici);
            this.Controls.Add(this.btnYonetici);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Anasayfa";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnKullanici;
        private System.Windows.Forms.Button btnYonetici;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}


namespace SentinelApp.UI
{
    partial class AnaKasaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvHesaplar = new DataGridView();
            txtPlatform = new TextBox();
            txtKullaniciAdi = new TextBox();
            txtParola = new TextBox();
            pbSifreGucu = new ProgressBar();
            btnEkle = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvHesaplar).BeginInit();
            SuspendLayout();
            // 
            // dgvHesaplar
            // 
            dgvHesaplar.AllowUserToAddRows = false;
            dgvHesaplar.AllowUserToDeleteRows = false;
            dgvHesaplar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHesaplar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHesaplar.Location = new Point(265, 50);
            dgvHesaplar.Name = "dgvHesaplar";
            dgvHesaplar.ReadOnly = true;
            dgvHesaplar.RowHeadersWidth = 51;
            dgvHesaplar.Size = new Size(560, 317);
            dgvHesaplar.TabIndex = 0;
            // 
            // txtPlatform
            // 
            txtPlatform.Location = new Point(25, 50);
            txtPlatform.Name = "txtPlatform";
            txtPlatform.Size = new Size(204, 27);
            txtPlatform.TabIndex = 1;
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(25, 124);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(204, 27);
            txtKullaniciAdi.TabIndex = 2;
            // 
            // txtParola
            // 
            txtParola.Location = new Point(25, 203);
            txtParola.Name = "txtParola";
            txtParola.Size = new Size(204, 27);
            txtParola.TabIndex = 3;
            txtParola.TextChanged += txtParola_TextChanged;
            // 
            // pbSifreGucu
            // 
            pbSifreGucu.Location = new Point(25, 281);
            pbSifreGucu.Name = "pbSifreGucu";
            pbSifreGucu.Size = new Size(204, 29);
            pbSifreGucu.TabIndex = 4;
            // 
            // btnEkle
            // 
            btnEkle.FlatStyle = FlatStyle.Flat;
            btnEkle.ForeColor = SystemColors.Highlight;
            btnEkle.Location = new Point(25, 338);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(204, 29);
            btnEkle.TabIndex = 5;
            btnEkle.Text = "Şifreyi Güvenli Kaydet";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(25, 27);
            label1.Name = "label1";
            label1.Size = new Size(112, 20);
            label1.TabIndex = 6;
            label1.Text = "Platform / Site :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(25, 180);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 7;
            label2.Text = "Parola / Şifre :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(25, 101);
            label3.Name = "label3";
            label3.Size = new Size(99, 20);
            label3.TabIndex = 8;
            label3.Text = "Kullanıcı Adı :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(25, 258);
            label4.Name = "label4";
            label4.Size = new Size(83, 20);
            label4.TabIndex = 9;
            label4.Text = "Şifre Gücü :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(283, 28);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 10;
            label5.Text = "label5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.White;
            label6.Location = new Point(265, 27);
            label6.Name = "label6";
            label6.Size = new Size(124, 20);
            label6.TabIndex = 11;
            label6.Text = "Kayıtlı Şifreleriniz";
            // 
            // AnaKasaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(837, 391);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEkle);
            Controls.Add(pbSifreGucu);
            Controls.Add(txtParola);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(txtPlatform);
            Controls.Add(dgvHesaplar);
            Name = "AnaKasaForm";
            Text = "SentinelPass - Şifre Kasası";
            ((System.ComponentModel.ISupportInitialize)dgvHesaplar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvHesaplar;
        private TextBox txtPlatform;
        private TextBox txtKullaniciAdi;
        private TextBox txtParola;
        private ProgressBar pbSifreGucu;
        private Button btnEkle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
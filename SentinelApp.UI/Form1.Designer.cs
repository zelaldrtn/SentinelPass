namespace SentinelApp.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtAnaSifre = new TextBox();
            btnGiris = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(62, 91);
            label1.Name = "label1";
            label1.Size = new Size(200, 20);
            label1.TabIndex = 0;
            label1.Text = "Ana Şifre (Master Password): ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.White;
            label2.Location = new Point(62, 9);
            label2.Name = "label2";
            label2.Size = new Size(346, 38);
            label2.TabIndex = 1;
            label2.Text = "SentinelPass Giriş Kontrolü";
            // 
            // txtAnaSifre
            // 
            txtAnaSifre.Location = new Point(283, 84);
            txtAnaSifre.Name = "txtAnaSifre";
            txtAnaSifre.Size = new Size(125, 27);
            txtAnaSifre.TabIndex = 2;
            // 
            // btnGiris
            // 
            btnGiris.BackColor = SystemColors.ActiveCaptionText;
            btnGiris.FlatStyle = FlatStyle.Flat;
            btnGiris.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnGiris.ForeColor = SystemColors.Highlight;
            btnGiris.Location = new Point(126, 140);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(233, 43);
            btnGiris.TabIndex = 3;
            btnGiris.Text = "Giriş";
            btnGiris.UseVisualStyleBackColor = false;
            btnGiris.Click += btnGiris_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(502, 218);
            Controls.Add(btnGiris);
            Controls.Add(txtAnaSifre);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "SentinelPass - Güvenli Giriş";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtAnaSifre;
        private Button btnGiris;
    }
}

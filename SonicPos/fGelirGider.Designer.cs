namespace SonicPos
{
    partial class fGelirGider
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
            this.lGelirGider = new SonicPos.lStandart();
            this.cmbOdemeTuru = new System.Windows.Forms.ComboBox();
            this.lStandart2 = new SonicPos.lStandart();
            this.tNakit = new SonicPos.tNumeric();
            this.tKart = new SonicPos.tNumeric();
            this.lStandart3 = new SonicPos.lStandart();
            this.lStandart4 = new SonicPos.lStandart();
            this.tAciklama = new SonicPos.tStandart();
            this.lStandart5 = new SonicPos.lStandart();
            this.dtTarih = new System.Windows.Forms.DateTimePicker();
            this.lStandart6 = new SonicPos.lStandart();
            this.bEkle = new SonicPos.bStandart();
            this.SuspendLayout();
            // 
            // lGelirGider
            // 
            this.lGelirGider.AutoSize = true;
            this.lGelirGider.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lGelirGider.ForeColor = System.Drawing.Color.Maroon;
            this.lGelirGider.Location = new System.Drawing.Point(30, 9);
            this.lGelirGider.Name = "lGelirGider";
            this.lGelirGider.Size = new System.Drawing.Size(107, 17);
            this.lGelirGider.TabIndex = 0;
            this.lGelirGider.Text = "GELİR GİDER";
            this.lGelirGider.Click += new System.EventHandler(this.lGelirGider_Click);
            // 
            // cmbOdemeTuru
            // 
            this.cmbOdemeTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOdemeTuru.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbOdemeTuru.FormattingEnabled = true;
            this.cmbOdemeTuru.Items.AddRange(new object[] {
            "NAKİT ",
            "KREDİ KARTI",
            "KART-NAKİT"});
            this.cmbOdemeTuru.Location = new System.Drawing.Point(29, 79);
            this.cmbOdemeTuru.Name = "cmbOdemeTuru";
            this.cmbOdemeTuru.Size = new System.Drawing.Size(219, 28);
            this.cmbOdemeTuru.TabIndex = 2;
            this.cmbOdemeTuru.SelectedIndexChanged += new System.EventHandler(this.cmbOdemeTuru_SelectedIndexChanged);
            // 
            // lStandart2
            // 
            this.lStandart2.AutoSize = true;
            this.lStandart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lStandart2.ForeColor = System.Drawing.Color.Maroon;
            this.lStandart2.Location = new System.Drawing.Point(30, 56);
            this.lStandart2.Name = "lStandart2";
            this.lStandart2.Size = new System.Drawing.Size(98, 17);
            this.lStandart2.TabIndex = 3;
            this.lStandart2.Text = "Ödeme Türü";
            this.lStandart2.Click += new System.EventHandler(this.lStandart2_Click);
            // 
            // tNakit
            // 
            this.tNakit.BackColor = System.Drawing.Color.White;
            this.tNakit.Enabled = false;
            this.tNakit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tNakit.Location = new System.Drawing.Point(29, 142);
            this.tNakit.Name = "tNakit";
            this.tNakit.Size = new System.Drawing.Size(87, 26);
            this.tNakit.TabIndex = 4;
            this.tNakit.Text = "0";
            this.tNakit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tKart
            // 
            this.tKart.BackColor = System.Drawing.Color.White;
            this.tKart.Enabled = false;
            this.tKart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tKart.Location = new System.Drawing.Point(161, 142);
            this.tKart.Name = "tKart";
            this.tKart.Size = new System.Drawing.Size(87, 26);
            this.tKart.TabIndex = 5;
            this.tKart.Text = "0";
            this.tKart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lStandart3
            // 
            this.lStandart3.AutoSize = true;
            this.lStandart3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lStandart3.ForeColor = System.Drawing.Color.Maroon;
            this.lStandart3.Location = new System.Drawing.Point(30, 119);
            this.lStandart3.Name = "lStandart3";
            this.lStandart3.Size = new System.Drawing.Size(45, 17);
            this.lStandart3.TabIndex = 6;
            this.lStandart3.Text = "Nakit";
            this.lStandart3.Click += new System.EventHandler(this.lStandart3_Click);
            // 
            // lStandart4
            // 
            this.lStandart4.AutoSize = true;
            this.lStandart4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lStandart4.ForeColor = System.Drawing.Color.Maroon;
            this.lStandart4.Location = new System.Drawing.Point(155, 119);
            this.lStandart4.Name = "lStandart4";
            this.lStandart4.Size = new System.Drawing.Size(85, 17);
            this.lStandart4.TabIndex = 7;
            this.lStandart4.Text = "Kredi Kartı";
            this.lStandart4.Click += new System.EventHandler(this.lStandart4_Click);
            // 
            // tAciklama
            // 
            this.tAciklama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tAciklama.Location = new System.Drawing.Point(29, 203);
            this.tAciklama.Multiline = true;
            this.tAciklama.Name = "tAciklama";
            this.tAciklama.Size = new System.Drawing.Size(219, 114);
            this.tAciklama.TabIndex = 0;
            this.tAciklama.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lStandart5
            // 
            this.lStandart5.AutoSize = true;
            this.lStandart5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lStandart5.ForeColor = System.Drawing.Color.Maroon;
            this.lStandart5.Location = new System.Drawing.Point(30, 180);
            this.lStandart5.Name = "lStandart5";
            this.lStandart5.Size = new System.Drawing.Size(72, 17);
            this.lStandart5.TabIndex = 8;
            this.lStandart5.Text = "Açıklama";
            this.lStandart5.Click += new System.EventHandler(this.lStandart5_Click);
            // 
            // dtTarih
            // 
            this.dtTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dtTarih.Location = new System.Drawing.Point(29, 354);
            this.dtTarih.Name = "dtTarih";
            this.dtTarih.Size = new System.Drawing.Size(219, 26);
            this.dtTarih.TabIndex = 9;
            // 
            // lStandart6
            // 
            this.lStandart6.AutoSize = true;
            this.lStandart6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lStandart6.ForeColor = System.Drawing.Color.Maroon;
            this.lStandart6.Location = new System.Drawing.Point(29, 331);
            this.lStandart6.Name = "lStandart6";
            this.lStandart6.Size = new System.Drawing.Size(46, 17);
            this.lStandart6.TabIndex = 10;
            this.lStandart6.Text = "Tarih";
            this.lStandart6.Click += new System.EventHandler(this.lStandart6_Click);
            // 
            // bEkle
            // 
            this.bEkle.BackColor = System.Drawing.Color.Maroon;
            this.bEkle.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.bEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bEkle.ForeColor = System.Drawing.Color.White;
            this.bEkle.Image = global::SonicPos.Properties.Resources.Ekle24;
            this.bEkle.Location = new System.Drawing.Point(148, 393);
            this.bEkle.Margin = new System.Windows.Forms.Padding(1);
            this.bEkle.MaximumSize = new System.Drawing.Size(100, 41);
            this.bEkle.MinimumSize = new System.Drawing.Size(100, 41);
            this.bEkle.Name = "bEkle";
            this.bEkle.Size = new System.Drawing.Size(100, 41);
            this.bEkle.TabIndex = 11;
            this.bEkle.Text = "   Ekle";
            this.bEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bEkle.UseVisualStyleBackColor = false;
            this.bEkle.Click += new System.EventHandler(this.bEkle_Click);
            // 
            // fGelirGider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(291, 462);
            this.Controls.Add(this.bEkle);
            this.Controls.Add(this.lStandart6);
            this.Controls.Add(this.dtTarih);
            this.Controls.Add(this.lStandart5);
            this.Controls.Add(this.tAciklama);
            this.Controls.Add(this.lStandart4);
            this.Controls.Add(this.lStandart3);
            this.Controls.Add(this.tKart);
            this.Controls.Add(this.tNakit);
            this.Controls.Add(this.lStandart2);
            this.Controls.Add(this.cmbOdemeTuru);
            this.Controls.Add(this.lGelirGider);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(307, 501);
            this.MinimumSize = new System.Drawing.Size(307, 501);
            this.Name = "fGelirGider";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GELİR-GİDER İŞLEMLERİ";
            this.Load += new System.EventHandler(this.fGelirGider_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lStandart lGelirGider;
        private System.Windows.Forms.ComboBox cmbOdemeTuru;
        private lStandart lStandart2;
        private tNumeric tNakit;
        private tNumeric tKart;
        private lStandart lStandart3;
        private lStandart lStandart4;
        private tStandart tAciklama;
        private lStandart lStandart5;
        private System.Windows.Forms.DateTimePicker dtTarih;
        private lStandart lStandart6;
        private bStandart bEkle;
    }
}
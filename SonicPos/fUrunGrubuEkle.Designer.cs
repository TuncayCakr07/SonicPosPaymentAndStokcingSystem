namespace SonicPos
{
    partial class fUrunGrubuEkle
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
            this.lStandart1 = new SonicPos.lStandart();
            this.tUrunGrupAd = new SonicPos.tStandart();
            this.listUrunGrup = new System.Windows.Forms.ListBox();
            this.bSil = new SonicPos.bStandart();
            this.bEkle = new SonicPos.bStandart();
            this.SuspendLayout();
            // 
            // lStandart1
            // 
            this.lStandart1.AutoSize = true;
            this.lStandart1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lStandart1.ForeColor = System.Drawing.Color.Maroon;
            this.lStandart1.Location = new System.Drawing.Point(13, 13);
            this.lStandart1.Name = "lStandart1";
            this.lStandart1.Size = new System.Drawing.Size(132, 19);
            this.lStandart1.TabIndex = 0;
            this.lStandart1.Text = "Ürün Grubu Adı:";
            // 
            // tUrunGrupAd
            // 
            this.tUrunGrupAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tUrunGrupAd.Location = new System.Drawing.Point(17, 36);
            this.tUrunGrupAd.Name = "tUrunGrupAd";
            this.tUrunGrupAd.Size = new System.Drawing.Size(240, 26);
            this.tUrunGrupAd.TabIndex = 0;
            this.tUrunGrupAd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listUrunGrup
            // 
            this.listUrunGrup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listUrunGrup.FormattingEnabled = true;
            this.listUrunGrup.ItemHeight = 20;
            this.listUrunGrup.Location = new System.Drawing.Point(17, 86);
            this.listUrunGrup.Name = "listUrunGrup";
            this.listUrunGrup.Size = new System.Drawing.Size(240, 164);
            this.listUrunGrup.TabIndex = 1;
            // 
            // bSil
            // 
            this.bSil.BackColor = System.Drawing.Color.Maroon;
            this.bSil.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.bSil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSil.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bSil.ForeColor = System.Drawing.Color.White;
            this.bSil.Image = global::SonicPos.Properties.Resources.cancel24;
            this.bSil.Location = new System.Drawing.Point(30, 254);
            this.bSil.Margin = new System.Windows.Forms.Padding(1);
            this.bSil.MaximumSize = new System.Drawing.Size(97, 61);
            this.bSil.MinimumSize = new System.Drawing.Size(97, 61);
            this.bSil.Name = "bSil";
            this.bSil.Size = new System.Drawing.Size(97, 61);
            this.bSil.TabIndex = 0;
            this.bSil.Text = "Sil";
            this.bSil.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bSil.UseVisualStyleBackColor = false;
            this.bSil.Click += new System.EventHandler(this.bSil_Click);
            // 
            // bEkle
            // 
            this.bEkle.BackColor = System.Drawing.Color.Olive;
            this.bEkle.FlatAppearance.BorderColor = System.Drawing.Color.Olive;
            this.bEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEkle.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bEkle.ForeColor = System.Drawing.Color.White;
            this.bEkle.Image = global::SonicPos.Properties.Resources.Ekle24;
            this.bEkle.Location = new System.Drawing.Point(150, 254);
            this.bEkle.Margin = new System.Windows.Forms.Padding(1);
            this.bEkle.MaximumSize = new System.Drawing.Size(97, 61);
            this.bEkle.MinimumSize = new System.Drawing.Size(97, 61);
            this.bEkle.Name = "bEkle";
            this.bEkle.Size = new System.Drawing.Size(97, 61);
            this.bEkle.TabIndex = 0;
            this.bEkle.Text = "Ekle";
            this.bEkle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bEkle.UseVisualStyleBackColor = false;
            this.bEkle.Click += new System.EventHandler(this.bEkle_Click);
            // 
            // fUrunGrubuEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(274, 325);
            this.Controls.Add(this.bSil);
            this.Controls.Add(this.bEkle);
            this.Controls.Add(this.listUrunGrup);
            this.Controls.Add(this.tUrunGrupAd);
            this.Controls.Add(this.lStandart1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(290, 364);
            this.MinimumSize = new System.Drawing.Size(290, 364);
            this.Name = "fUrunGrubuEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Grubu İşlemleri";
            this.Load += new System.EventHandler(this.FUrunGrubuEkle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private lStandart lStandart1;
        private tStandart tUrunGrupAd;
        private System.Windows.Forms.ListBox listUrunGrup;
        private bStandart bEkle;
        private bStandart bSil;
    }
}
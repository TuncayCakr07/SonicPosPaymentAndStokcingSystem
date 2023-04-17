﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode.Internal;

namespace SonicPos
{
    public partial class fUrunGiris : Form
    {
        public fUrunGiris()
        {
            InitializeComponent();
        }

        SonicPosDbEntities db = new SonicPosDbEntities();
        private void tBarkod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string barkod = tBarkod.Text.Trim();
                if (db.Urun.Any(a => a.Barkod == barkod))
                {
                    var urun = db.Urun.Where(a => a.Barkod == barkod).SingleOrDefault();
                    tUrunAdi.Text = urun.UrunAd;
                    tAciklama.Text = urun.Aciklama;
                    cmbUrunGrup.Text = urun.UrunGrup;
                    tAlisFiyati.Text = urun.AlisFiyat.ToString();
                    tSatisFiyati.Text = urun.SatisFiyat.ToString();
                    tMiktar.Text = urun.Miktar.ToString();
                    tKdvOrani.Text = urun.KdvOrani.ToString();
                    if (urun.Birim=="Kg")
                    {
                        chUrunIslemi.Checked = true;
                    }
                    else
                    {
                       chUrunIslemi.Checked=false;  
                    }
                }
                else
                {
                    MessageBox.Show("Ürün Kayıtlı Değil,Kayıt Edilebilir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {

            if (tBarkod.Text != "" && tUrunAdi.Text != "" && cmbUrunGrup.Text != "" && tAlisFiyati.Text != "" && tSatisFiyati.Text != "" && tKdvOrani.Text != "" && tMiktar.Text != "")
            {
                if (db.Urun.Any(a => a.Barkod == tBarkod.Text))
                {
                    var guncelle = db.Urun.Where(a => a.Barkod == tBarkod.Text).SingleOrDefault();
                    guncelle.UrunAd = tUrunAdi.Text;
                    guncelle.Aciklama = tAciklama.Text;
                    guncelle.UrunGrup = cmbUrunGrup.Text;
                    guncelle.AlisFiyat = Convert.ToDouble(tAlisFiyati.Text);
                    guncelle.SatisFiyat = Convert.ToDouble(tSatisFiyati.Text);
                    guncelle.KdvOrani = Convert.ToInt32(tKdvOrani.Text);
                    guncelle.KdvTutari = Math.Round(Islemler.DoubleYap(tSatisFiyati.Text) * Convert.ToInt32(tKdvOrani.Text) / 100, 2);
                    guncelle.Miktar += Convert.ToDouble(tMiktar.Text);
                    if (chUrunIslemi.Checked)
                    {
                        guncelle.Birim = "Kg";
                    }
                    else
                    {
                        guncelle.Birim = "Adet";
                    }
                    guncelle.Tarih = DateTime.Now;
                    guncelle.Kullanici = lKullanici.Text;
                    db.SaveChanges();
                    MessageBox.Show("Ürün Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Temizle();
                    gridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(10).ToList();
                    Islemler.GridDuzenle(gridUrunler);
                   
                }
                else
                {
                    Urun urun = new Urun();
                    urun.Barkod = tBarkod.Text;
                    urun.UrunAd = tUrunAdi.Text;
                    urun.Aciklama = tAciklama.Text;
                    urun.UrunGrup = cmbUrunGrup.Text;
                    urun.AlisFiyat = Convert.ToDouble(tAlisFiyati.Text);
                    urun.SatisFiyat = Convert.ToDouble(tSatisFiyati.Text);
                    urun.KdvOrani = Convert.ToInt32(tKdvOrani.Text);
                    urun.KdvTutari = Math.Round(Islemler.DoubleYap(tSatisFiyati.Text) * Convert.ToInt32(tKdvOrani.Text) / 100, 2);
                    urun.Miktar = Convert.ToDouble(tMiktar.Text);
                    if (chUrunIslemi.Checked)
                    {
                        urun.Birim = "Kg";
                    }
                    else
                    {
                        urun.Birim = "Adet";
                    }
                    urun.Tarih = DateTime.Now;
                    urun.Kullanici = lKullanici.Text;
                    db.Urun.Add(urun);
                    db.SaveChanges();
                    MessageBox.Show("Ürün Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (tBarkod.Text.Length == 8)
                    {
                        var ozelbarkod = db.Barkod.First();
                        ozelbarkod.BarkodNo += 1;
                        db.SaveChanges();
                    }
                    gridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(10).ToList();
                    Islemler.GridDuzenle(gridUrunler);
                }
                Islemler.StokHareket(tBarkod.Text,tUrunAdi.Text,"Adet",Convert.ToDouble(tMiktar.Text),cmbUrunGrup.Text,lKullanici.Text);
                Temizle();
               
            }
            else
            {
                MessageBox.Show("Bilgileri Kontrol Ediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (tUrunAra.Text.Length > 2)
            {
                string urunad = tUrunAra.Text;
                gridUrunler.DataSource = db.Urun.Where(a => a.UrunAd.Contains(urunad)).ToList();
                Islemler.GridDuzenle(gridUrunler);
            }
        }

        private void bIptal_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void Temizle()
        {
            tBarkod.Clear();
            tUrunAdi.Clear();
            tAciklama.Clear();
            tAlisFiyati.Text = "0";
            tSatisFiyati.Text = "0";
            tMiktar.Text = "0";
            tKdvOrani.Text = "8";
            tBarkod.Focus();
            chUrunIslemi.Checked = false;
                
        }

        private void fUrunGiris_Load(object sender, EventArgs e)
        {
                tBarkod.Focus();
                tUrunSayisi.Text =db.Urun.Count().ToString();
                gridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();
                GrupListele();
                Islemler.GridDuzenle(gridUrunler);

        }

        public void GrupListele()
        {
            cmbUrunGrup.DisplayMember = "UrunGrupAd";
            cmbUrunGrup.ValueMember = "Id";
            cmbUrunGrup.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAd).ToList();
        }

        private void bUrunGrubuEkle_Click(object sender, EventArgs e)
        {
            fUrunGrubuEkle f = new fUrunGrubuEkle();
            f.ShowDialog();
        }

        private void bBarkodOlustur_Click(object sender, EventArgs e)
        {
          
            var barkodno = db.Barkod.First();
            int karakter = barkodno.BarkodNo.ToString().Length;
            string sifirlar = string.Empty;
            for (int i = 0; i < 8-karakter; i++)
            {
                sifirlar = sifirlar + "0";
            }
            string olusanbarkod = sifirlar + barkodno.BarkodNo.ToString();  
            tBarkod.Text= olusanbarkod;
            tUrunAdi.Focus();
        }

        private void tSatisFiyati_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)==false && e.KeyChar!=(char)08 && e.KeyChar!=(char)44)
            {
                e.Handled = true;
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridUrunler.Rows.Count>0)
            {
                int urunid = Convert.ToInt32(gridUrunler.CurrentRow.Cells["UrunId"].Value.ToString());
                string urunad = gridUrunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                string barkod = gridUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                DialogResult onay = MessageBox.Show(urunad + "Ürününü Silmek İstiyor musunuz?", "Ürün Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (onay == DialogResult.Yes)
                {
                    var urun = db.Urun.Find(urunid);
                    db.Urun.Remove(urun);
                    db.SaveChanges();
                    var hizliurun=db.HizliUrun.Where(x=> x.Barkod==barkod).SingleOrDefault();
                    hizliurun.Barkod = "-";
                    hizliurun.UrunAd = "-";
                    hizliurun.Fiyat = 0;
                    db.SaveChanges();
                    MessageBox.Show("Ürün Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridUrunler.DataSource = db.Urun.OrderByDescending(a => a.UrunId).Take(20).ToList();
                    Islemler.GridDuzenle(gridUrunler);
                    tBarkod.Focus();
                }
            }
            
        }

        private void chUrunIslemi_CheckedChanged(object sender, EventArgs e)
        {
            if (chUrunIslemi.Checked)
            {
                chUrunIslemi.Text = "Gramajlı Ürün İşlemi";
                bBarkodOlustur.Enabled = false;
            }
            else
            {
                chUrunIslemi.Text = "Barkodlu Ürün İşlemi";
                bBarkodOlustur.Enabled=true;
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridUrunler.Rows.Count>0)
            {
                tBarkod.Text = gridUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                tUrunAdi.Text = gridUrunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                tAciklama.Text = gridUrunler.CurrentRow.Cells["Aciklama"].Value.ToString();
                cmbUrunGrup.Text= gridUrunler.CurrentRow.Cells["UrunGrup"].Value.ToString();
                tAlisFiyati.Text = gridUrunler.CurrentRow.Cells["AlisFiyat"].Value.ToString();
                tSatisFiyati.Text = gridUrunler.CurrentRow.Cells["SatisFiyat"].Value.ToString();
                tKdvOrani.Text = gridUrunler.CurrentRow.Cells["KdvOrani"].Value.ToString();
                tMiktar.Text = gridUrunler.CurrentRow.Cells["Miktar"].Value.ToString();
                string birim = gridUrunler.CurrentRow.Cells["Birim"].Value.ToString();
                if (birim=="Kg")
                {
                    chUrunIslemi.Checked = true;
                }
                else
                {
                    chUrunIslemi.Checked= false;
                }
            }
        }

        private void bRaporAl_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Raporlar.Baslik = chUrunIslemi.Text + " ";
            Raporlar.TarihBaslangic = DateTime.Now.ToShortDateString();
            Raporlar.TarihBitis = DateTime.Now.ToShortDateString();
            Raporlar.StokRaporu(gridUrunler);


            Cursor.Current = Cursors.Default;
        }

        private void bFiyatGuncelle_Click(object sender, EventArgs e)
        {
            fFiyatGuncelle f=new fFiyatGuncelle();
            f.ShowDialog();
        }

        private void etiketYazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridUrunler.Rows.Count > 0)
            {
                var adi = gridUrunler.CurrentRow.Cells["UrunAd"].Value.ToString();
                var fiyat = Convert.ToDouble(gridUrunler.CurrentRow.Cells["SatisFiyat"].Value.ToString());
                var aciklama = gridUrunler.CurrentRow.Cells["Aciklama"].Value.ToString();
                var barkod = gridUrunler.CurrentRow.Cells["Barkod"].Value.ToString();
                var stokkod = gridUrunler.CurrentRow.Cells["UrunId"].Value.ToString();

                CreateSalesLabel(adi, fiyat, barkod,stokkod);
            }
        }
        PrintDocument pd = new PrintDocument();
        PictureBox pb = new PictureBox();
        string adi;
        string fiyati;
        string stokkodu;

        public void CreateSalesLabel(string productName, double productPrice, string barcodeText,string stockcode)
        {


            // Etiket formu oluşturma
            SatisEtiketi labelForm = new SatisEtiketi();
            labelForm.Text = "Ürün Etiketi";
            labelForm.Width = 250;
            labelForm.Height = 150;

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 80,
                    Width = 250
                }
            };
            var barcodeBitmap = writer.Write(barcodeText);
            var image = barcodeBitmap;

            // Barkod resmini PictureBox kontrolüne yerleştirme
            pb.Image = image;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Dock = DockStyle.Left;

            // Ürün bilgilerini Label kontrollerine yerleştirme
            adi = "Ürün Adi = " + productName;
            fiyati = "Ürün Fiyati = "+productPrice.ToString("C2");
            stokkodu = "Stok Kodu = " + stockcode;

            // Etiket formunu gösterme
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pd.Print();


        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {


            int kagituzunluk = 120;

            PaperSize ps58 = new PaperSize("58mm Termal", 220, kagituzunluk + 120);
            pd.DefaultPageSettings.PaperSize = ps58;


            Font fontBaslik = new Font("Calibri", 10, FontStyle.Bold);
            Font fontBilgi = new Font("Calibri", 8, FontStyle.Bold);
            Font fontIcerikBaslik = new Font("Calibri", 8, FontStyle.Underline);
            StringFormat ortala = new StringFormat(StringFormatFlags.FitBlackBox);
            ortala.Alignment = StringAlignment.Center;
            RectangleF rcUnvanKonum = new RectangleF(0, 20, 220, 20);

            // PictureBox'taki resmi 180 derece saat yönünde çevir
            pb.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);

            // Resmi sol üst köşeye çiz
            e.Graphics.DrawImage(pb.Image, new PointF(0, 0));


            e.Graphics.Transform = new Matrix { };
            e.Graphics.DrawString(adi, fontBilgi, Brushes.Black, new Point(100, 45));
            e.Graphics.DrawString("-------------------------------------------------------------", fontBilgi, Brushes.Black, new Point(100, 60));

            e.Graphics.DrawString(stokkodu, fontBilgi, Brushes.Black, new Point(100, 70));
            e.Graphics.DrawString("-------------------------------------------------------------", fontBilgi, Brushes.Black, new Point(100, 80));

            e.Graphics.DrawString(fiyati.ToString(), fontBilgi, Brushes.Black, new Point(100, 90));
            e.Graphics.DrawString("-------------------------------------------------------------", fontBilgi, Brushes.Black, new Point(100, 105));

        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SonicPos
{
    public partial class fAyarlar : Form
    {
        public fAyarlar()
        {
            InitializeComponent();
        }
        private void Temizle()
        {
            tAdSoyad.Clear();
            tTelefon.Clear();
            tEposta.Clear();
            tKullaniciadi.Clear();
            tSifre.Clear();
            tSifretekrar.Clear();
            chSatisEkrani.Checked = false;
            chRapor.Checked = false;
            chStok.Checked = false;
            chUrunGiris.Checked = false;
            chAyarlar.Checked = false;
            chFiyatGuncelle.Checked = false;
            chYedek.Checked = false;
        }
        private void bKaydet_Click(object sender, EventArgs e)
        {
            if (bKaydet.Text=="Kaydet")
            {
                if (tAdSoyad.Text!="" && tTelefon.Text!="" && tKullaniciadi.Text!="" && tSifre.Text!="" && tSifretekrar.Text!="")
                {
                    if (tSifre.Text==tSifretekrar.Text)
                    {
                        try
                        {
                            using (var db=new SonicPosDbEntities())
                            {
                                if (!db.Kullanicis.Any(x=> x.KullaniciAd==tKullaniciadi.Text))
                                {
                                    Kullanici k=new Kullanici();
                                    k.AdSoyad = tAdSoyad.Text;
                                    k.Telefon = tTelefon.Text;
                                    k.EPosta=tEposta.Text;
                                    k.KullaniciAd=tKullaniciadi.Text.Trim();
                                    k.Sifre = tSifre.Text;
                                    k.Satis = chSatisEkrani.Checked;
                                    k.Rapor=chRapor.Checked;
                                    k.Stok=chStok.Checked;
                                    k.UrunGiris=chUrunGiris.Checked;
                                    k.Ayarlar=chAyarlar.Checked;
                                    k.FiyatGuncelle=chFiyatGuncelle.Checked;
                                    k.Yedekleme=chYedek.Checked;
                                    db.Kullanicis.Add(k);
                                    db.SaveChanges();
                                    Doldur();
                                    MessageBox.Show("Kullanıcı Kayıt Edildi!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Kullanıcı Kayıtlı!");
                                }
                            }
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Hata Oluştu !","Uyarı!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Uyuşmamaktadır. Kontrol Ediniz!","Uyarı!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Bilgileri Kontrol Ediniz!" + "\nAd Soyad \nTelefon \nKullanıcı Adı","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else if (bKaydet.Text=="Düzenle/Kaydet")
            {
                if (tAdSoyad.Text != "" && tTelefon.Text != "" && tKullaniciadi.Text != "" && tSifre.Text != "" && tSifretekrar.Text != "")
                {
                    if (tSifre.Text == tSifretekrar.Text)
                    {
                     int id=Convert.ToInt32(LKullaniciId.Text);
                        using (var db=new SonicPosDbEntities())
                        {
                            var guncelle = db.Kullanicis.Where(x => x.Id == id).FirstOrDefault();
                            guncelle.AdSoyad = tAdSoyad.Text;
                            guncelle.Telefon = tTelefon.Text;
                            guncelle.EPosta = tEposta.Text;
                            guncelle.KullaniciAd = tKullaniciadi.Text.Trim();
                            guncelle.Sifre = tSifre.Text;
                            guncelle.Satis = chSatisEkrani.Checked;
                            guncelle.Rapor = chRapor.Checked;
                            guncelle.Stok = chStok.Checked;
                            guncelle.UrunGiris = chUrunGiris.Checked;
                            guncelle.Ayarlar = chAyarlar.Checked;
                            guncelle.FiyatGuncelle = chFiyatGuncelle.Checked;
                            guncelle.Yedekleme = chYedek.Checked;
                            db.SaveChanges();
                            MessageBox.Show("Kullanıcı Bilgileri Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            bKaydet.Text = "Kaydet";
                            Temizle();
                            Doldur();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Uyuşmamaktadır. Kontrol Ediniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Bilgileri Kontrol Ediniz!" + "\nAd Soyad \nTelefon \nKullanıcı Adı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fAyarlar_Load(object sender, EventArgs e)
        {
            Doldur(); 
        }
        private void Doldur()
        {
            using (var db = new SonicPosDbEntities())
            {
                gridListeKullanici.DataSource = db.Kullanicis.Select(x => new {x.Id, x.AdSoyad, x.KullaniciAd, x.Telefon, x.EPosta, }).ToList();
            }
            
        }

       
    }
}

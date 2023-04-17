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
           tKullaniciAdi.Clear();
           tSifre.Clear();
           tSifretekrar.Clear();    
           chSatisEkrani.Checked = false;
           chRapor.Checked = false;
           chStok.Checked = false;
           chUrunGiris.Checked = false;
           chAyarlar.Checked = false;   
           chFiyatGuncelle.Checked = false;
           chYedekleme.Checked = false; 
        }
        private void bKaydet_Click(object sender, EventArgs e)
        {
            if (bKaydet.Text=="Kaydet")
            {
                if (tAdSoyad.Text!="" && tTelefon.Text!="" && tKullaniciAdi.Text!="" && tSifre.Text!="" && tSifretekrar.Text!="")
                {
                    if (tSifre.Text==tSifretekrar.Text)
                    {
                        try
                        {
                            using (var db=new SonicPosDbEntities())
                            {
                                if (!db.Kullanicis.Any(x=> x.KullaniciAd==tKullaniciAdi.Text))
                                {
                                    Kullanici k = new Kullanici();
                                    k.AdSoyad = tAdSoyad.Text;
                                    k.Telefon=tTelefon.Text;
                                    k.EPosta=tEposta.Text;
                                    k.KullaniciAd = tKullaniciAdi.Text.Trim();
                                    k.Sifre = tSifre.Text;
                                    k.Satis = chSatisEkrani.Checked;
                                    k.Rapor = chRapor.Checked;
                                    k.Stok= chStok.Checked;
                                    k.UrunGiris= chUrunGiris.Checked;
                                    k.Ayarlar=chAyarlar.Checked;
                                    k.FiyatGuncelle=chFiyatGuncelle.Checked;
                                    k.Yedekleme=chYedekleme.Checked;
                                    db.Kullanicis.Add(k);
                                    db.SaveChanges();
                                     Doldur();
                                     Temizle();
                                }
                                else
                                {
                                    MessageBox.Show("Kullanıcı Kayıtlı", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Hata Durumu!","Uyarı!",MessageBoxButtons.OK,MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Uyuşmamaktadır! Kontrol Ediniz","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Zorunlu Alanları Doldurunuz!"+"\nAd Soyad \nTelefon \nKullanıcı Adı \nŞifre","Uyarı!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else if (bKaydet.Text=="Düzenle")
            {
                if (tAdSoyad.Text != "" && tTelefon.Text != "" && tKullaniciAdi.Text != "" && tSifre.Text != "" && tSifretekrar.Text != "")
                {
                    if (tSifre.Text == tSifretekrar.Text)
                    {
                        int id = Convert.ToInt32(lKullaniciid.Text);
                        using (var db=new SonicPosDbEntities())
                        {
                            var guncelle = db.Kullanicis.Where(x => x.Id == id).FirstOrDefault();
                            guncelle.AdSoyad = tAdSoyad.Text;
                            guncelle.Telefon = tTelefon.Text;
                            guncelle.EPosta = tEposta.Text;
                            guncelle.KullaniciAd = tKullaniciAdi.Text.Trim();
                            guncelle.Sifre = tSifre.Text;
                            guncelle.Satis = chSatisEkrani.Checked;
                            guncelle.Rapor = chRapor.Checked;
                            guncelle.Stok = chStok.Checked;
                            guncelle.UrunGiris = chUrunGiris.Checked;
                            guncelle.Ayarlar = chAyarlar.Checked;
                            guncelle.FiyatGuncelle = chFiyatGuncelle.Checked;
                            guncelle.Yedekleme = chYedekleme.Checked;
                            db.SaveChanges();
                            MessageBox.Show("Kullanıcı Bilgileri Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            bKaydet.Text = "Kaydet";
                            Temizle();
                            Doldur();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şifreler Uyuşmamaktadır! Kontrol Ediniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen Zorunlu Alanları Doldurunuz!" + "\nAd Soyad \nTelefon \nKullanıcı Adı \nŞifre", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridListeKullanici.Rows.Count>0)
            {
                int id = Convert.ToInt32(gridListeKullanici.CurrentRow.Cells["Id"].Value.ToString());
                lKullaniciid.Text=id.ToString();
                using (var db=new SonicPosDbEntities())
                {
                    var getir = db.Kullanicis.Where(x => x.Id == id).FirstOrDefault();
                    tAdSoyad.Text = getir.AdSoyad;
                    tTelefon.Text= getir.Telefon;
                    tEposta.Text = getir.EPosta;
                    tKullaniciAdi.Text = getir.KullaniciAd;
                    tSifre.Text= getir.Sifre;
                    tSifretekrar.Text = getir.Sifre;
                    chSatisEkrani.Checked = (bool)getir.Satis;
                    chRapor.Checked= (bool)getir.Rapor;
                    chStok.Checked= (bool)getir.Stok;
                    chUrunGiris.Checked=(bool)getir.UrunGiris;
                    chAyarlar.Checked=(bool)getir.Ayarlar;
                    chFiyatGuncelle.Checked=(bool)getir.FiyatGuncelle;
                    chYedekleme.Checked=(bool)getir.Yedekleme;
                    bKaydet.Text = "Düzenle";
                    Doldur();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Seçiniz", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fAyarlar_Load(object sender, EventArgs e)
        {
            Doldur();
            using (var db=new SonicPosDbEntities())
            {
                gridListeKullanici.DataSource = db.Kullanicis.Select(x => new { x.Id, x.AdSoyad, x.Telefon, x.EPosta }).ToList();
            }
           

        }

        private void Doldur()
        {
            using (var db = new SonicPosDbEntities())
            {
                if (db.Kullanicis.Any())
                {
                    gridListeKullanici.DataSource = db.Kullanicis.Select(x => new { x.Id, x.AdSoyad, x.Telefon, x.EPosta }).ToList();
                   
                }
                Islemler.SabitVArsayilan();
                var yazici = db.Sabit.FirstOrDefault();
                chYazmadurumu.Checked = (bool)yazici.Yazici;
                
                var sabitler=db.Sabit.FirstOrDefault();
                tKartKomisyon.Text = sabitler.KartKomisyon.ToString();

                var terazionek = db.Terazi.ToList();
                cmbTeraziOnEk.DisplayMember = "TeraziOnEk";
                cmbTeraziOnEk.ValueMember = "Id";
                cmbTeraziOnEk.DataSource= terazionek;

                tIsyeriAdSoyad.Text = sabitler.AdSoyad;
                tISyeriUnvan.Text = sabitler.Unvan;
                tIsyeriAdres.Text = sabitler.Adres;
                tIsyeriTelefon.Text = sabitler.Telefon;
                tIsyeriEposta.Text = sabitler.Eposta;
            }
       
        }

        private void chYazmadurumu_CheckedChanged(object sender, EventArgs e)
        { 
            using (var db=new SonicPosDbEntities())
          {
            if (chYazmadurumu.Checked)
            {
               
                    Islemler.SabitVArsayilan();
                    var ayarla = db.Sabit.FirstOrDefault();
                    ayarla.Yazici = true;
                    db.SaveChanges();
                    chYazmadurumu.Text = "Yazma Durumu AKTİF";
              

            }
            else
            {
                    Islemler.SabitVArsayilan();
                    var ayarla=db.Sabit.FirstOrDefault();
                    ayarla.Yazici = false;
                    db.SaveChanges();
                    chYazmadurumu.Text = "Yazma Durumu PASİF";
            }
          }
        }

        private void bKartKomisyon_Click(object sender, EventArgs e)
        {
            if (tKartKomisyon.Text!="")
            {
                using (var db = new SonicPosDbEntities())
                {
                    var sabit=db.Sabit.FirstOrDefault();
                    sabit.KartKomisyon = Convert.ToInt32(tKartKomisyon.Text);
                    db.SaveChanges();
                    MessageBox.Show("Kart Komisyonu Tanımlandı!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Bilgileri Kontrol Ediniz!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
         
        }

        private void bTeraziOnEkKaydet_Click(object sender, EventArgs e)
        {
            if (tTeraziOnEk.Text!="")
            {
                int onek = Convert.ToInt16(tTeraziOnEk.Text);
                using (var db=new SonicPosDbEntities())
                {
                    if (db.Terazi.Any(x=> x.TeraziOnEk==onek))
                    {
                        MessageBox.Show(onek.ToString()+" Ön Ek Kayıtlıdır!","Uyarı!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        Terazi t=new Terazi();
                        t.TeraziOnEk = onek;    
                        db.Terazi.Add(t);
                        db.SaveChanges();
                        MessageBox.Show("Ön Ek Kaydedildi!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        cmbTeraziOnEk.DisplayMember = "TeraziOnEk";
                        cmbTeraziOnEk.ValueMember = "Id";
                        cmbTeraziOnEk.DataSource= db.Terazi.ToList();
                        tTeraziOnEk.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Bilgileri Kontrol Ediniz!","Uyarı!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void bTeraziOnEkSil_Click(object sender, EventArgs e)
        {
            if (cmbTeraziOnEk.Text!="")
            {
                int onekid = Convert.ToInt16(cmbTeraziOnEk.SelectedValue);
                DialogResult onay = MessageBox.Show(cmbTeraziOnEk.Text+" ön eki silmek istiyor musunuz?","Ön Ek Silme İşlemi",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (onay==DialogResult.Yes)
                {
                    using (var db=new SonicPosDbEntities())
                    {
                        var onek = db.Terazi.Find(onekid);
                        db.Terazi.Remove(onek);
                        db.SaveChanges();
                        cmbTeraziOnEk.DisplayMember = "TeraziOnEk";
                        cmbTeraziOnEk.ValueMember = "Id";
                        cmbTeraziOnEk.DataSource = db.Terazi.ToList();
                        MessageBox.Show("Ön Ek Silindi!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
            MessageBox.Show("Ön Ek Seçiniz!","Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bIsyeriKaydet_Click(object sender, EventArgs e)
        {
            if (tIsyeriAdSoyad.Text!="" && tISyeriUnvan.Text!="" && tIsyeriAdres.Text!="" && tIsyeriTelefon.Text!="")
            {
                using (var db=new SonicPosDbEntities())
                {
                    var isyeri = db.Sabit.FirstOrDefault();
                    isyeri.AdSoyad = tAdSoyad.Text;
                    isyeri.Unvan = tISyeriUnvan.Text;
                    isyeri.Adres = tIsyeriAdres.Text;
                    isyeri.Telefon = tIsyeriTelefon.Text;
                    isyeri.Eposta = tIsyeriEposta.Text;
                    db.SaveChanges();
                    MessageBox.Show("İş Yeri Bilgileri Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var yeni=db.Sabit.FirstOrDefault();
                    tIsyeriAdSoyad.Text = yeni.AdSoyad;
                    tISyeriUnvan.Text = yeni.Unvan;
                    tIsyeriAdres.Text=yeni.Adres;
                    tIsyeriTelefon.Text=yeni.Telefon;
                    tIsyeriEposta.Text = yeni.Eposta;
                    

                }
            }
        }

      
    }
}

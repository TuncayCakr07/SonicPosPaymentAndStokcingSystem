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
    public partial class fMusteri : Form
    {
        SonicPosDbEntities db = new SonicPosDbEntities();
        public fMusteri()
        {
            InitializeComponent();
        }

        private void FrmRehber_Load(object sender, EventArgs e)
        {
            tMusteriAdi.Focus();
            Listele();
            Islemler.GridDuzenle(grdMusteri);
        }
        public void Listele()
        {
           
            tMusteriSayisi.Text = db.Musteris.Count().ToString();
            var data = (from m in db.Musteris  orderby m.Id descending select m).Take(20).ToList();
            //    db.Musteris.OrderByDescending(a => a.Musteri_Ad).Take(20).ToList();
            grdMusteri.DataSource = data;
           
        }
        private void Temizle()
        {
            Id = 0;
            tMusteriAdi.Clear();
            tMusteriSoyad.Clear();
            tAciklama.Clear();
            tMusteriAdres.Clear();
            tTelefon.Clear();
            tMusteriVd.Clear();
            tMusteriVknTc.Clear();
        }
        private void bSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (Id > 0)
                {
                    DialogResult res = MessageBox.Show("Kayıt Silinsin mi?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        var musteri = db.Musteris.First(x => x.Id == Id);
                        db.Musteris.Remove(musteri);
                        db.SaveChanges();
                        Temizle();
                        Listele();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void tMusteriAra_TextChanged(object sender, EventArgs e)
        {
            if (tMusteriAra.Text.Length > 2)
            {
                string musteriad = tMusteriAra.Text;
                grdMusteri.DataSource = db.Musteris.Where(a => a.Musteri_Ad.Contains(musteriad)).ToList();
                Islemler.GridDuzenle(grdMusteri);
            }
        }

        private void bKaydet_Click(object sender, EventArgs e)
        {

            
            if (tMusteriAdi.Text != "" && tMusteriSoyad.Text != "" && tMusteriAdres.Text != "" && tMusteriVknTc.Text != "")
            {
                Musteri musteri = new Musteri();
                musteri.Musteri_Ad = tMusteriAdi.Text;
                musteri.Musteri_Soyad = tMusteriSoyad.Text;
                musteri.Musteri_Telefon = tTelefon.Text;
                musteri.Musteri_Adres = tMusteriAdres.Text;
                musteri.Musteri_Vd = tMusteriVd.Text;
                musteri.Musteri_Vkn_Tc = tMusteriVknTc.Text;
                musteri.Musteri_Aciklama = tAciklama.Text;
                db.Musteris.Add(musteri);
                db.SaveChanges();
                musteri.Musteri_Kodu = musteri.Id;
                db.SaveChanges();


                MessageBox.Show("Müşteri Kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();

                grdMusteri.DataSource = db.Musteris.OrderByDescending(a => a.Musteri_Kodu).Take(10).ToList();
                Islemler.GridDuzenle(grdMusteri);
                Listele();

            }
            else
            {
                MessageBox.Show("Bilgileri Kontrol Ediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bDuzenle_Click(object sender, EventArgs e)
        {

            var guncelle = db.Musteris.Where(a => a.Id == Id).SingleOrDefault();
            guncelle.Musteri_Ad = tMusteriAdi.Text;
            guncelle.Musteri_Soyad = tMusteriSoyad.Text;
            guncelle.Musteri_Telefon = tTelefon.Text;
            guncelle.Musteri_Adres = tMusteriAdres.Text;
            guncelle.Musteri_Vd = tMusteriVd.Text;
            guncelle.Musteri_Vkn_Tc = tMusteriVknTc.Text;
            guncelle.Musteri_Aciklama = tAciklama.Text;

            db.SaveChanges();
            MessageBox.Show("Müşteri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            grdMusteri.DataSource = db.Musteris.OrderByDescending(a => a.Musteri_Kodu).Take(20).ToList();
            Islemler.GridDuzenle(grdMusteri);
            Listele();

        }

        private void bRaporAl_Click(object sender, EventArgs e)
        {
            Raporlar.Baslik = "Müşteri Bilgileri Raporu";
            Raporlar.TarihBaslangic = DateTime.Now.ToShortDateString();
            Raporlar.TarihBitis = DateTime.Now.ToShortDateString();
            Raporlar.MusteriRaporu(grdMusteri);
        }

        private void bAra_Click(object sender, EventArgs e)
        {

        }

        private void grdMusteri_DoubleClick(object sender, EventArgs e)
        {

        }

        public int Id = 0;
        public string musteriadi = "";
        public string musterisoyad = "";
        private void grdMusteri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(grdMusteri["Id", e.RowIndex].Value);
            musteriadi = grdMusteri["Musteri_Ad", e.RowIndex].Value.ToString();
            tMusteriAdi.Tag = Convert.ToInt32(grdMusteri["Id", e.RowIndex].Value);
            tMusteriAdi.Text = grdMusteri["Musteri_Ad", e.RowIndex].Value.ToString();
            tMusteriSoyad.Text = grdMusteri["Musteri_Soyad", e.RowIndex].Value.ToString();
            tTelefon.Text = grdMusteri["Musteri_Telefon", e.RowIndex].Value.ToString();
            tMusteriAdres.Text = grdMusteri["Musteri_Adres", e.RowIndex].Value.ToString();
            tMusteriVd.Text = grdMusteri["Musteri_Vd", e.RowIndex].Value.ToString();
            tMusteriVknTc.Text = grdMusteri["Musteri_Vkn_Tc", e.RowIndex].Value.ToString();
            tAciklama.Text = grdMusteri["Musteri_Aciklama", e.RowIndex].Value.ToString();
            this.Close();
        }

       

        private void grdMusteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = Convert.ToInt32(grdMusteri["Id", e.RowIndex].Value);
            tMusteriAdi.Tag = Convert.ToInt32(grdMusteri["Id", e.RowIndex].Value);
            tMusteriAdi.Text = grdMusteri["Musteri_Ad", e.RowIndex].Value.ToString();
            tMusteriSoyad.Text = grdMusteri["Musteri_Soyad", e.RowIndex].Value.ToString();
            musterisoyad = grdMusteri["Musteri_Soyad", e.RowIndex].Value.ToString();
            tTelefon.Text = grdMusteri["Musteri_Telefon", e.RowIndex].Value.ToString();
            tMusteriAdres.Text = grdMusteri["Musteri_Adres", e.RowIndex].Value.ToString();
            tMusteriVd.Text = grdMusteri["Musteri_Vd", e.RowIndex].Value.ToString();
            tMusteriVknTc.Text = grdMusteri["Musteri_Vkn_Tc", e.RowIndex].Value.ToString();
            tAciklama.Text = grdMusteri["Musteri_Aciklama", e.RowIndex].Value.ToString();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (grdMusteri.Rows.Count > 0)
            {
                int musteriId = Convert.ToInt32(grdMusteri.CurrentRow.Cells["No"].Value.ToString());
                string musteriad = grdMusteri.CurrentRow.Cells["Musteri_Ad"].Value.ToString();
                string musterisoyad = grdMusteri.CurrentRow.Cells["Musteri_Soyad"].Value.ToString();
                DialogResult onay = MessageBox.Show(musteriId +"Müşteriyi Silmek İstiyor musunuz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (onay == DialogResult.Yes)
                {
                    var musteri = db.Musteris.Find(musteriId);
                    db.Musteris.Remove(musteri);
                    db.SaveChanges();
                    var musteritablo = db.Musteris.Where(x => x.Musteri_Ad == musteriad).SingleOrDefault();
                    db.SaveChanges();
                    MessageBox.Show("Müşteri Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grdMusteri.DataSource = db.Musteris.OrderByDescending(a => musteriad).Take(20).ToList();
                    Islemler.GridDuzenle(grdMusteri);
                    tMusteriAdi.Focus();
                }
            }
        }
    }
}

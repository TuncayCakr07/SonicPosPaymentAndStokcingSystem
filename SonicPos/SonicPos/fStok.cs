using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SonicPos
{
    public partial class fStok : Form
    {
        public fStok()
        {
            InitializeComponent();
        }
        
        private void bAra_Click(object sender, EventArgs e)
        {
            gridListe.DataSource = null;
            using (var db=new SonicPosDbEntities())
            {
                if (cmbİslemTuru.Text!="")
                {
                    string urungrubu=cmbUrunGrubu.Text;
                    if (cmbİslemTuru.SelectedIndex==0)
                    {
                        if (rdTumu.Checked)
                        {
                            db.Urun.OrderBy(x => x.Miktar).Load();
                            gridListe.DataSource=db.Urun.Local.ToBindingList();
                        }
                        else if (rdUrunGrubunaGore.Checked)
                        {
                            db.Urun.Where(x=> x.UrunGrup==urungrubu).OrderBy(x=> x.Miktar).Load();
                            gridListe.DataSource = db.Urun.Local.ToBindingList();
                        }
                        else 
                        {
                            MessageBox.Show("Filtreleme Türü'nü Seçiniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (cmbİslemTuru.SelectedIndex==1)
                    {
                        DateTime baslangic = DateTime.Parse(dateBaslangic.Value.ToShortDateString());
                        DateTime bitis=DateTime.Parse(dateBitisTarihi.Value.ToShortDateString());
                        bitis=bitis.AddDays(1);
                        if (rdTumu.Checked)
                        {
                            db.StokHareket.OrderByDescending(x => x.Tarih).Where(x => x.Tarih >= baslangic && x.Tarih <= bitis).Load();
                            gridListe.DataSource=db.StokHareket.Local.ToBindingList();

                        }
                        else if (rdUrunGrubunaGore.Checked)
                        {
                            db.StokHareket.OrderByDescending(x => x.Tarih).Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.UrunGrup.Contains(urungrubu)).Load();
                            gridListe.DataSource = db.StokHareket.Local.ToBindingList();

                        }
                        else
                        {
                            MessageBox.Show("Filtreleme Türü'nü Seçiniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("İşlem Türünü Seçiniz!","Uyarı!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            Islemler.GridDuzenle(gridListe);
        }
        SonicPosDbEntities dbx = new SonicPosDbEntities();
        private void fStok_Load(object sender, EventArgs e)
        {
                cmbUrunGrubu.DisplayMember = "UrunGrupAd";
                cmbUrunGrubu.ValueMember = "Id";
                cmbUrunGrubu.DataSource = dbx.UrunGrup.ToList();
         
           
        }

        private void tUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (tUrunAra.Text.Length>=2)
            {
                string urunad = tUrunAra.Text;
                using (var db=new SonicPosDbEntities())
                {
                    if (cmbİslemTuru.SelectedIndex==0)
                    {
                        db.Urun.Where(x => x.UrunAd.Contains(urunad)).Load();
                        gridListe.DataSource=db.Urun.Local.ToBindingList();
                    }
                    else if (cmbİslemTuru.SelectedIndex==1)
                    {
                        db.StokHareket.Where(x => x.UrunAd.Contains(urunad)).Load();
                        gridListe.DataSource=db.StokHareket.Local.ToBindingList();
                    }
                }
                Islemler.GridDuzenle(gridListe);
            }
        }

        private void bRaporAl_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (cmbİslemTuru.SelectedIndex==0)
            {
                Raporlar.Baslik = cmbİslemTuru.Text + " Raporu";
                Raporlar.TarihBaslangic = dateBaslangic.Value.ToShortDateString();
                Raporlar.TarihBitis = dateBitisTarihi.Value.ToShortDateString();
                Raporlar.StokRaporu(gridListe);
            }
            else if (cmbİslemTuru.SelectedIndex==1)
            {
                Raporlar.Baslik = cmbİslemTuru.Text + " Raporu";
                Raporlar.TarihBaslangic = dateBaslangic.Value.ToShortDateString();
                Raporlar.TarihBitis = dateBitisTarihi.Value.ToShortDateString();
                Raporlar.StokIzlemeRaporu(gridListe);
            }
            
           
                
                
           Cursor.Current = Cursors.Default;
        }
    }
}

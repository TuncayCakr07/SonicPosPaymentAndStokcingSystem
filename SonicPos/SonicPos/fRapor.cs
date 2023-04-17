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
    public partial class fRapor : Form
    {
        public fRapor()
        {
            InitializeComponent();
        }

        public void bGoster_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime baslangic=DateTime.Parse(dtBaslangic.Value.ToShortDateString());
            DateTime bitis=DateTime.Parse(dtBitis.Value.ToShortDateString());
            bitis = bitis.AddDays(1);
            using (var db=new SonicPosDbEntities())
            {
                if (listFiltreleme.SelectedIndex==0) //Tümünü Getir
                {
                    db.IslemOzets.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis).OrderByDescending(x => x.Tarih).Load();
                    var islemozet=db.IslemOzets.Local.ToBindingList();
                    gridListe.DataSource = islemozet;

                    tSatisNakit.Text = Convert.ToDouble(islemozet.Where(x => x.Iade == false && x.Gelir == false && x.Gider == false).Sum(x => x.Nakit)).ToString("C2");
                    tSatisKart.Text = Convert.ToDouble(islemozet.Where(x => x.Iade == false && x.Gelir == false && x.Gider == false).Sum(x => x.KrediKartı)).ToString("C2");

                    tIadeNakit.Text = Convert.ToDouble(islemozet.Where(x => x.Iade == true).Sum(x => x.Nakit)).ToString("C2");
                    tIadeKart.Text = Convert.ToDouble(islemozet.Where(x => x.Iade== true).Sum(x => x.KrediKartı)).ToString("C2");

                    tGelirNakit.Text=Convert.ToDouble(islemozet.Where(x=> x.Gelir==true).Sum(x=> x.Nakit)).ToString("C2");
                    tGelirKart.Text = Convert.ToDouble(islemozet.Where(x => x.Gelir == true).Sum(x => x.KrediKartı)).ToString("C2");

                    tGiderNakit.Text = Convert.ToDouble(islemozet.Where(x => x.Gider == true).Sum(x => x.Nakit)).ToString("C2");
                    tGiderKart.Text = Convert.ToDouble(islemozet.Where(x => x.Gider == true).Sum(x => x.KrediKartı)).ToString("C2");

                    db.Satis.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis).Load();
                    var satistablosu = db.Satis.Local.ToBindingList();
                    double kdvtutarisatis = Islemler.DoubleYap(satistablosu.Where(x => x.Iade == false).Sum(x => x.KdvTutari).ToString());
                    double kdvtutariiade=Islemler.DoubleYap(satistablosu.Where(x=> x.Iade==true).Sum(x=> x.KdvTutari).ToString());
                    tKdvToplam.Text = (kdvtutarisatis - kdvtutariiade).ToString("C2");

                }
                else if (listFiltreleme.SelectedIndex==1) //Satışları Getir
                {
                    db.IslemOzets.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.Iade == false && x.Gelir == false && x.Gider == false).Load();
                    var islemozet = db.IslemOzets.Local.ToBindingList();
                    gridListe.DataSource= islemozet;
                }
                else if (listFiltreleme.SelectedIndex==2) //İadeleri Getir
                {
                    db.IslemOzets.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.Iade == true).Load();
                    gridListe.DataSource = db.IslemOzets.Local.ToBindingList();
                }
                else if (listFiltreleme.SelectedIndex == 3) //Gelirleri Getir
                {
                    db.IslemOzets.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.Gelir == true).Load();
                    gridListe.DataSource = db.IslemOzets.Local.ToBindingList();
                }
                else if (listFiltreleme.SelectedIndex == 4) //Giderleri Getir
                {
                    db.IslemOzets.Where(x => x.Tarih >= baslangic && x.Tarih <= bitis && x.Gider == true).Load();
                    gridListe.DataSource = db.IslemOzets.Local.ToBindingList();
                }
            }


            Islemler.GridDuzenle(gridListe);
            Cursor.Current= Cursors.Default;
        }

        private void fRapor_Load(object sender, EventArgs e)
        {
            listFiltreleme.SelectedIndex= 0;
            tKartKomisyon.Text = Islemler.KartKomisyon().ToString();
            bGoster_Click(null, null);
        }

        private void gridListe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex==2 ||e.ColumnIndex==6 || e.ColumnIndex==7)
            {
                if (e.Value is bool)
                {
                    bool value = (bool)e.Value;
                    e.Value = (value) ? "Evet" : "Hayır";
                    e.FormattingApplied= true;
                }
            }
        }

        private void bGelirEkle_Click(object sender, EventArgs e)
        {
            fGelirGider f=new fGelirGider();
            f.gelirgider = "GELİR";
            f.kullanici = lKullanici.Text;
            
            f.ShowDialog();
        }

        private void bGiderEkle_Click(object sender, EventArgs e)
        {
            fGelirGider f = new fGelirGider();
            f.gelirgider = "GİDER";
            f.kullanici = lKullanici.Text;
            f.ShowDialog();
        }

        private void detayGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridListe.Rows.Count>0)
            {
                int islemno =Convert.ToInt32(gridListe.CurrentRow.Cells["IslemNo"].Value.ToString());
                if (islemno!=0)
                {
                    fDetayGoster f = new fDetayGoster();
                    f.islemno= islemno;
                    f.ShowDialog();
                }

            }
        }

        private void bRaporAl_Click(object sender, EventArgs e)
        {
            Raporlar.Baslik = "GENEL RAPOR";
            Raporlar.SatisKart = tSatisKart.Text;
            Raporlar.SatisNakit= tSatisNakit.Text;
            Raporlar.IadeNakit= tIadeNakit.Text;
            Raporlar.IadeKart= tIadeKart.Text;
            Raporlar.GelirKart= tGelirKart.Text;
            Raporlar.GelirNakit=tGelirNakit.Text;
            Raporlar.GiderKart= tGiderKart.Text;
            Raporlar.GiderNakit= tGiderNakit.Text;
            Raporlar.TarihBaslangic=dtBaslangic.Value.ToShortDateString();
            Raporlar.TarihBitis=dtBitis.Value.ToShortDateString();
            Raporlar.KdvToplam = tKdvToplam.Text;
            Raporlar.KartKomisyon=tKartKomisyon.Text;

            Raporlar.RaporSayfasiRaporu(gridListe);
        }
    }
}

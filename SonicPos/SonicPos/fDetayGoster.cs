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
    public partial class fDetayGoster : Form
    {
        public fDetayGoster()
        {
            InitializeComponent();
        }
        public int islemno { get; set; }
        public int tarih { get; set; }
        public int kullanici { get; set; }

        private void fDetayGoster_Load(object sender, EventArgs e)
        {
            lKullanici.Text=kullanici.ToString();
            lIslemNo.Text="İşlem No : " + islemno.ToString();
            using (var db=new SonicPosDbEntities())
            {
                gridListe.DataSource = db.Satis.Select(s=> new {s.IslemNo,s.UrunAd,s.Miktar,s.Birim,s.SatisFiyat,s.Toplam}).Where(x => x.IslemNo == islemno).ToList();
                Islemler.GridDuzenle(gridListe);
            }
        }

    }
}

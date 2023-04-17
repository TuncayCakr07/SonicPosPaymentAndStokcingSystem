using System;
using System.Linq;
using System.Windows.Forms;

namespace SonicPos
{
    public partial class fUrunGrubuEkle : Form
    {
        public fUrunGrubuEkle()
        {
            InitializeComponent();
        }

        SonicPosDbEntities db = new SonicPosDbEntities();
       
        private void FUrunGrubuEkle_Load(object sender, EventArgs e)
        {
            GrupListele();
        }

        private void bEkle_Click(object sender, EventArgs e)
        {
            if (tUrunGrupAd.Text != "")
            {
                UrunGrup ug = new UrunGrup();
                ug.UrunGrupAd = tUrunGrupAd.Text;
                db.UrunGrup.Add(ug);
                db.SaveChanges();
                GrupListele();
                tUrunGrupAd.Clear();
                MessageBox.Show("Ürün Grubu Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fUrunGiris f = (fUrunGiris)Application.OpenForms["fUrunGiris"];
                if (f != null)
                    f.GrupListele();
                

                
            }
            else
            {
                MessageBox.Show("Grup Bilgisi Ekleyiniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GrupListele()
        {
            listUrunGrup.DisplayMember = "UrunGrupAd";
            listUrunGrup.ValueMember = "Id";
            listUrunGrup.DataSource = db.UrunGrup.OrderBy(a => a.UrunGrupAd).ToList();
        }

        private void bSil_Click(object sender, EventArgs e)
        {
            int grupid = Convert.ToInt32(listUrunGrup.SelectedValue.ToString());
            string grupad = listUrunGrup.Text;
            DialogResult onay = MessageBox.Show(grupad + "Grubunu Silmek İstiyor musunuz?","Silme İşlemi",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (onay == DialogResult.Yes)
            {
                var grup = db.UrunGrup.FirstOrDefault(x => x.Id == grupid);
                db.UrunGrup.Remove(grup);
                db.SaveChanges();
                GrupListele();
                tUrunGrupAd.Focus();
                MessageBox.Show(grupad + "Ürün Grubu Silindi","Bilgi",MessageBoxButtons.OK);
                fUrunGiris f = (fUrunGiris)Application.OpenForms["fUrunGiris"];
                f.GrupListele();
            }
        }
    }
}

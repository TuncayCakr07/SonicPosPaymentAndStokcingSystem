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
    public partial class fBaslangic : Form
    {
        public fBaslangic()
        {
            InitializeComponent();
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            fsatis f=new fsatis();
            f.lKullanici.Text = lKullanici.Text;
            f.ShowDialog();
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            fRapor f=new fRapor();
            f.lKullanici.Text = lKullanici.Text;
            f.ShowDialog();
        }

        private void btnStok_Click(object sender, EventArgs e)
        {
            fStok f=new fStok();
            f.lKullanici.Text= lKullanici.Text;
            f.ShowDialog();
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            fUrunGiris f=new fUrunGiris();
            f.lKullanici.Text=lKullanici.Text;
            f.ShowDialog();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult onay=MessageBox.Show("Çıkış Yapılsın mı ? ", "Uyarı !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (onay==DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            fMusteri f=new fMusteri();
            f.lKullanici.Text = lKullanici.Text;
            f.ShowDialog();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            fAyarlar f= new fAyarlar();
            f.ShowDialog();
        }
    }
}

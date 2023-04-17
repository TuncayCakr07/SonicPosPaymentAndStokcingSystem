using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace SonicPos
{
    public partial class SatisEtiketi : Form
    {
        PrintDocument pd = new PrintDocument();

        public SatisEtiketi()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

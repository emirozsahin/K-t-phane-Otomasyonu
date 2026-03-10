using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_otomasyonu
{
    public partial class FrmRaporMenu : Form
    {
        public FrmRaporMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKitapRapor frm = new FrmKitapRapor();
            frm.Show();





        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUyeRapor frm = new FrmUyeRapor();
            frm.Show();
        }
    }
}

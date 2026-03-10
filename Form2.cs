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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKitapIslemleri frm = new FrmKitapIslemleri();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUyeIslemleri frm = new FrmUyeIslemleri();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmRaporMenu frm = new FrmRaporMenu();
            frm.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmKitapAra frm = new FrmKitapAra();
            frm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Kütüphane_otomasyonu
{
    public partial class Form1 : Form
    {
        public static string girenKullanici;
        


        SqlConnection baglanti = new SqlConnection(
    "Server=EMOZSAHIN\\SQLEXPRESS;Database=KutuphaneOtomasyonu;Trusted_Connection=True;"
);

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciadi = textBox1.Text;
            string sifre=textBox2.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM Yoneticiler WHERE KullaniciAdi=@kadi AND Sifre=@sifre", baglanti);
            komut.Parameters.AddWithValue("@kadi", kullaniciadi);
            komut.Parameters.AddWithValue("@sifre", sifre);
            int sonuc = (int)komut.ExecuteScalar();
            baglanti.Close();
            if(sonuc>0)
            {
                girenKullanici = kullaniciadi;
                Form2 menu = new Form2();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya sifre yanlıs!");
            }

        }
    }
    

}

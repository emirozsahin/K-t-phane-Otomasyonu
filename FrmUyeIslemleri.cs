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
    public partial class FrmUyeIslemleri : Form
    {
        SqlConnection baglanti = new SqlConnection(
    "Server=EMOZSAHIN\\SQLEXPRESS;Database=KutuphaneOtomasyonu;Trusted_Connection=True;"
);
        int secilenId = 0;

        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Uyeler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        public FrmUyeIslemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand(
                "INSERT INTO Uyeler (AdSoyad, Telefon, Email, UyeTarihi) VALUES (@ad, @tel, @mail, @tarih)",
                baglanti
            );

            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@tel", textBox2.Text);
            komut.Parameters.AddWithValue("@mail", textBox3.Text);
            komut.Parameters.AddWithValue("@tarih", textBox4.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Üye eklendi");
            Listele();
        }

        private void FrmUyeIslemleri_Load(object sender, EventArgs e)
        {
            Listele();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                secilenId = Convert.ToInt32(
                    dataGridView1.Rows[e.RowIndex].Cells["UyeID"].Value
                );

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["AdSoyad"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Telefon"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["UyeTarihi"].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (secilenId == 0)
            {
                MessageBox.Show("Lütfen silmek için bir üye seçin");
                return;
            }

            baglanti.Open();

            SqlCommand komut = new SqlCommand(
                "DELETE FROM Uyeler WHERE UyeID=@id",
                baglanti
            );

            komut.Parameters.AddWithValue("@id", secilenId);
            komut.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Üye silindi");
            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (secilenId == 0)
            {
                MessageBox.Show("Güncellemek için bir üye seçin");
                return;
            }

            baglanti.Open();

            SqlCommand komut = new SqlCommand(
                "UPDATE Uyeler SET AdSoyad=@ad, Telefon=@tel, Email=@mail, UyeTarihi=@tarih WHERE UyeID=@id",
                baglanti
            );

            komut.Parameters.AddWithValue("@ad", textBox1.Text);
            komut.Parameters.AddWithValue("@tel", textBox2.Text);
            komut.Parameters.AddWithValue("@mail", textBox3.Text);
            komut.Parameters.AddWithValue("@tarih", textBox4.Text);
            komut.Parameters.AddWithValue("@id", secilenId);

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Üye güncellendi");
            Listele();
        }
    }
    }
    


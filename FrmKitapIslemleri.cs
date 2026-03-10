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
    public partial class FrmKitapIslemleri : Form
    {
        SqlConnection baglanti = new SqlConnection(
    "Server=EMOZSAHIN\\SQLEXPRESS;Database=KutuphaneOtomasyonu;Trusted_Connection=True;"
);
        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Kitaplar", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        int secilenId = 0;


        public FrmKitapIslemleri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand(
                "INSERT INTO Kitaplar (KitapAdi, Yazar, Tur, YayinYili) VALUES (@adi, @yazar, @tur, @yil)",
                baglanti
            );

            komut.Parameters.AddWithValue("@adi", textBox1.Text);
            komut.Parameters.AddWithValue("@yazar", textBox2.Text);
            komut.Parameters.AddWithValue("@tur", textBox3.Text);
            komut.Parameters.AddWithValue("@yil", textBox4.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kitap eklendi");

            Listele();

        }

        private void FrmKitapIslemleri_Load(object sender, EventArgs e)

        {
            void Listele()
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Kitaplar", baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                Listele();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                secilenId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["KitapID"].Value);

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["KitapAdi"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["Yazar"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["Tur"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["YayinYili"].Value.ToString();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (secilenId == 0)
            {
                MessageBox.Show("Silmek için bir kitap seçin");
                return;
            }

            baglanti.Open();

            SqlCommand komut = new SqlCommand(
                "DELETE FROM Kitaplar WHERE KitapID=@id",
                baglanti
            );

            komut.Parameters.AddWithValue("@id", secilenId);
            komut.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Kitap silindi");

            Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (secilenId == 0)
            {
                MessageBox.Show("Güncellemek için bir kitap seçin");
                return;
            }

            int yil;
            if (!int.TryParse(textBox4.Text, out yil))
            {
                MessageBox.Show("Yayın yılı sayı olmalıdır");
                return;
            }

            baglanti.Open();

            SqlCommand komut = new SqlCommand(
                "UPDATE Kitaplar SET KitapAdi=@adi, Yazar=@yazar, Tur=@tur, YayinYili=@yil WHERE KitapID=@id",
                baglanti
            );

            komut.Parameters.AddWithValue("@adi", textBox1.Text);
            komut.Parameters.AddWithValue("@yazar", textBox2.Text);
            komut.Parameters.AddWithValue("@tur", textBox3.Text);
            komut.Parameters.AddWithValue("@yil", yil);
            komut.Parameters.AddWithValue("@id", secilenId);

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kitap güncellendi");

            Listele();
        }
    }
    }
    



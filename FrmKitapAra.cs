using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_otomasyonu
{
    public partial class FrmKitapAra : Form
    {
        SqlConnection baglanti = new SqlConnection(
    "Server=EMOZSAHIN\\SQLEXPRESS;Database=KutuphaneOtomasyonu;Trusted_Connection=True;"
);

        public FrmKitapAra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter(
       "SELECT * FROM Kitaplar WHERE KitapAdi LIKE @p1",
       baglanti
   );

            da.SelectCommand.Parameters.AddWithValue(
                "@p1", "%" + textBox1.Text + "%"
            );

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}

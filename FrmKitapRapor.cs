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
    public partial class FrmKitapRapor : Form
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

        public FrmKitapRapor()
        {
            InitializeComponent();
        }
        private void FrmKitapRapor_Load(object sender, EventArgs e)
        {
            Listele();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

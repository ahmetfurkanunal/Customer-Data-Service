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

namespace Customer_Data_Service
{
    public partial class KategorilerFrm : Form
    {
        public KategorilerFrm()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-3399AHH;Initial Catalog=SatisVT;Integrated Security=True");
        private void btnListele_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From TBLKategori", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command2 = new SqlCommand("insert into TBLKategori (KATEGORIAD) VALUES (@p1)", connection);
            command2.Parameters.AddWithValue("@p1", txtKategoriAD.Text);
            command2.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kategori ekleme işleri başarıyla gerçekleşti.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKategoriID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKategoriAD.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command3 = new SqlCommand("Delete From TBLKategori where KATEGORIID=@p1", connection);
            command3.Parameters.AddWithValue("@p1", txtKategoriID.Text);
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Silme işlemi gerçekleşti");
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command4 = new SqlCommand("UPDATE TBLKategori set KATEGORIAD=@p1 where KATEGORIID=@p2", connection);
            command4.Parameters.AddWithValue("@p1", txtKategoriAD.Text);
            command4.Parameters.AddWithValue("@p2", txtKategoriID.Text);
            command4.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Güncelleme işlemi gerçekleşti");
        }
    }

    //Data Source=DESKTOP-3399AHH;Initial Catalog=SatisVT;Integrated Security=True
}

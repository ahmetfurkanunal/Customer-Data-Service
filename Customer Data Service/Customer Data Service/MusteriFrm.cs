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
    public partial class MusteriFrm : Form
    {
        public MusteriFrm()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-3399AHH;Initial Catalog=SatisVT;Integrated Security=True");

        void Listele()
        {
            SqlCommand command = new SqlCommand("Select * From TBLMUSTERI", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void MusteriFrm_Load(object sender, EventArgs e)
        {
            Listele();

            connection.Open();
            SqlCommand command1 = new SqlCommand("Select * From TBLSEHIRLER", connection);
            SqlDataReader dataReader = command1.ExecuteReader();
            while (dataReader.Read())
            {
                comboBoxSehir.Items.Add(dataReader["Sehirler"]);
            }
            connection.Close(); 
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBoxSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command2 = new SqlCommand("insert into TBLMUSTERI (MUSTERIAD,MUSTERISOYAD,MUSTERISEHIR,MUSTERIBAKIYE) VALUES (@p1,@P2,@P3,@P4)", connection);
            command2.Parameters.AddWithValue("@p1", txtAd.Text);
            command2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            command2.Parameters.AddWithValue("@p3", comboBoxSehir.Text);
            command2.Parameters.AddWithValue("@p4", decimal.Parse(txtBakiye.Text));
            command2.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Müşteri sisteme kaydedildi.");
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command3 = new SqlCommand("Delete From TBLMUSTERI where MUSTERIID=@p1", connection);
            command3.Parameters.AddWithValue("@p1", txtID.Text);
            command3.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Silme işlemi gerçekleşti");
            Listele();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command4 = new SqlCommand("UPDATE TBLMUSTERI set MUSTERIAD=@p1, MUSTERISOYAD=@p2, MUSTERISEHIR=@p3, MUSTERIBAKIYE=@p4 where MUSTERIID=@p5", connection);
            command4.Parameters.AddWithValue("@p1", txtAd.Text);
            command4.Parameters.AddWithValue("@p2", txtSoyad.Text);
            command4.Parameters.AddWithValue("@p3", comboBoxSehir.Text);
            command4.Parameters.AddWithValue("@p4", decimal.Parse(txtBakiye.Text));
            command4.Parameters.AddWithValue("@p5", txtID.Text);
            command4.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Güncelleme işlemi gerçekleşti");
            Listele();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand command5 = new SqlCommand("Select * From TBLMUSTERI where MUSTERIAD=@P1", connection);
            command5.Parameters.AddWithValue("@p1",txtAd.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command5);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

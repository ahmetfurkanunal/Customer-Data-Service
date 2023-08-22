using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_Data_Service
{
    public partial class SqlVeriKayıtFrm : Form
    {
        public SqlVeriKayıtFrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            KategorilerFrm productsFrm = new KategorilerFrm();
            productsFrm.Show();
        }

        private void btnMusteri_Click(object sender, EventArgs e)
        {
            MusteriFrm musteriFrm = new MusteriFrm();
            musteriFrm.Show();
        }
    }
}

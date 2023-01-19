using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneme1
{
    public partial class CreditSale : Form
    {
        public CreditSale()
        {
            InitializeComponent();
        }
        Model1 ent = new Model1();

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreSsale_Click(object sender, EventArgs e)
        {

        }

        private void CreSback_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void CreditSale_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = ent.Urun.ToList();
            guna2DataGridView2.DataSource = ent.VeresiyeSatis.ToList();
        }
    }
}

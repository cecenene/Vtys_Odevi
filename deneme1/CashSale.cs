using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace deneme1
{
    public partial class CashSale : Form
    {
        public CashSale()
        {
            InitializeComponent();
        }

        Model1 ent = new Model1();

        private void CashSale_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = ent.Urun.ToList();
            guna2DataGridView2.DataSource = ent.PesinSatis.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CSback_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CSbarcode.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void CSbuy_Click(object sender, EventArgs e)
        {
            


        }
    }
}

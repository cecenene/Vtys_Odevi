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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        Model1 ent = new Model1();

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PaymID.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void Paymback_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void Paympay_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = ent.Odeme.ToList();
        }
    }
}

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
            bool ThereIsNoMissInfo = Missing_Information();
            if (ThereIsNoMissInfo)
            {
                Pay_Debt();
            }

        }

        private void Pay_Debt()
        {

            string paymId = PaymID.Text;
            Odeme odeme = ent.Odeme.Find(Convert.ToInt32(paymId));
            if(odeme == null)
            {
                MessageBox.Show("Bu idli kullanici bulunamadi!");
            }
            Satici satici = ent.Satici.Find(2);     // BU İD'YE DİKKAT ET HATA ATARSA
            if (satici == null)
            {
                MessageBox.Show("Bu idli kullanici bulunamadi!(Development Error-Payment.cs-53)");
            }
            satici.bakiye -= odeme.odememiktari;
            ent.Odeme.Remove(odeme);
            ent.SaveChanges();
            guna2DataGridView1.DataSource = ent.Odeme.ToList();

        }

        private bool Missing_Information()
        {
            if (PaymID.Text == "")
            {
                MessageBox.Show("Missing information");
                return false;
            }
            return true;
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

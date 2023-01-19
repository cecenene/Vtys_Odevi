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
    public partial class Payback : Form
    {
        public Payback()
        {
            InitializeComponent();
        }
        Model1 ent = new Model1();


        private void Paybgetp_Click(object sender, EventArgs e)
        {
            bool ThereIsNoMissInfo = Missing_Information();
            if (ThereIsNoMissInfo)
            {
                try {
                    Check_Password();
                    Pay_Back();

                } catch 
                {

                }
            }
        }

        private void Paybback_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void Pay_Back()
        {
            string paymId = PaybID.Text;
            Odeme odeme = ent.Odeme.Find(Convert.ToInt32(paymId));
            if (odeme == null)
            {
                MessageBox.Show("Bu idli kullanici bulunamadi!");
                return;
            }
            Satici satici = ent.Satici.Find(2);     // BU İD'YE DİKKAT ET HATA ATARSA
            if (satici == null)
            {
                MessageBox.Show("Bu idli kullanici bulunamadi!(Development Error-PayBack.cs-43)");
                return;
            }
            satici.bakiye += odeme.odememiktari;
            ent.Odeme.Remove(odeme);
            ent.SaveChanges();
            PaybID.Clear();
            paybPassword.Clear();
            guna2DataGridView1.DataSource = ent.Odeme.ToList();

        }

        private bool Missing_Information()
        {
            if (PaybID.Text == "" || paybPassword.Text == "")
            {
                MessageBox.Show("Missing information");
                return false;
            }
            return true;
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PaybID.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Payback_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = ent.Odeme.ToList();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Check_Password()
        {
            if(paybPassword.Text != "321")
            {
                MessageBox.Show("Sifre yanlis!");
                string productSizeError = "Sifre yanlis!";
                throw new InvalidCastException(productSizeError);
            }
            return;
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

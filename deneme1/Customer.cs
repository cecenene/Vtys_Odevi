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

namespace deneme1
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            
        }

        Model1 ent = new Model1();

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = ent.Musteri.ToList();
        }

        private void Cadd_Click(object sender, EventArgs e)
        {
            if (Cname.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else 
            { 
                try
                {
                    Musteri tblm = new Musteri();
                    tblm.musteriadi = Cname.Text;
                    tblm.bakiye = 0;
                    ent.Musteri.Add(tblm);
                    ent.SaveChanges();
                    Cname.Clear();
                    MessageBox.Show("Customer Successfully Added");
                    guna2DataGridView1.DataSource = ent.Musteri.ToList();

                }
                catch(Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }

        }

        private void Cdelete_Click(object sender, EventArgs e)
        {
            if (Cname.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    string musteriadi = Cname.Text;
                    Musteri tblm = ent.Musteri.First(f => f.musteriadi == musteriadi);
                    ent.Musteri.Remove(tblm);
                    ent.SaveChanges();
                    Cname.Clear();
                    MessageBox.Show("Customer Successfully Removed");
                    guna2DataGridView1.DataSource = ent.Musteri.ToList();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Cname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void Cback_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}

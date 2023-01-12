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
    public partial class Provider : Form
    {
        public Provider()
        {
            InitializeComponent();
        }

        Model1 ent = new Model1();

        private void PRadd_Click(object sender, EventArgs e)
        {
            if (PRname.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Tedarikci tblp = new Tedarikci();
                    tblp.tedarikciadi = PRname.Text;                 
                    ent.Tedarikci.Add(tblp);
                    ent.SaveChanges();
                    PRname.Clear();                  
                    MessageBox.Show("Provider Successfully Added");
                    guna2DataGridView1.DataSource = ent.Tedarikci.ToList();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }


        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PRdelete_Click(object sender, EventArgs e)
        {
            if (PRname.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    string tedarikciadi = PRname.Text;
                    Tedarikci tblp = ent.Tedarikci.First(f => f.tedarikciadi == tedarikciadi);
                    ent.Tedarikci.Remove(tblp);
                    ent.SaveChanges();
                    PRname.Clear();
                    MessageBox.Show("Provider Successfully Removed");
                    guna2DataGridView1.DataSource = ent.Tedarikci.ToList();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PRname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            
        }

        private void PRback_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void Provider_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = ent.Tedarikci.ToList();
        }

    }
}

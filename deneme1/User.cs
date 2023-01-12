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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        Model1 ent = new Model1();

        private void User_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = ent.Satici.ToList();
        }

        private void Uadd_Click(object sender, EventArgs e)
        {
            if (Uname.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Satici tbls = new Satici();
                    tbls.kullaniciad = Uname.Text;
                    tbls.sifre = Convert.ToInt16(Upassword.Text);
                    ent.Satici.Add(tbls);
                    ent.SaveChanges();
                    Uname.Clear();
                    Upassword.Clear();
                    MessageBox.Show("User Successfully Added");
                    guna2DataGridView1.DataSource = ent.Satici.ToList();

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


        private void Udelete_Click(object sender, EventArgs e)
        {
            if (Uname.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    string kullaniciad = Uname.Text;
                    Satici tbls = ent.Satici.First(f => f.kullaniciad == kullaniciad);
                    ent.Satici.Remove(tbls);
                    ent.SaveChanges();
                    Uname.Clear();
                    Upassword.Clear();
                    MessageBox.Show("User Successfully Removed");
                    guna2DataGridView1.DataSource = ent.Satici.ToList();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }


        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Uname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Upassword.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void Uedit_Click(object sender, EventArgs e)
        {
            if (Uedit.Text == "" || Upassword.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    string kullaniciad = Uname.Text;
                    Satici tbls = ent.Satici.First(f => f.kullaniciad == kullaniciad);
                    tbls.kullaniciad = Uname.Text;
                    tbls.sifre = Convert.ToInt16(Upassword.Text);
                    ent.SaveChanges();
                    Uname.Clear();
                    Upassword.Clear();
                    MessageBox.Show("User Successfully Edited");
                    guna2DataGridView1.DataSource = ent.Satici.ToList();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Uback_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }
    }
}

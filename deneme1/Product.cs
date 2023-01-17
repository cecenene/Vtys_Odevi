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
using System.Data.SqlClient;
//barkoda göre işlem ekle
namespace deneme1
{
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        Model1 ent = new Model1();

        private void Product_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = ent.Urun.ToList();
        }


        private void button9_Click(object sender, EventArgs e)
        {          
            Application.Exit();
        }
        //test
        private void Pedit_Click(object sender, EventArgs e)
        {
            if (Pid.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    int id = Convert.ToInt16(Pid.Text);
                    Urun tblu = ent.Urun.First(f => f.id == id);
                    tblu.satis_fiyat = Convert.ToDouble(Pprice.Text);
                    double karoran = ((tblu.satis_fiyat - tblu.alis_fiyat) / tblu.alis_fiyat) * 100;
                    double karmarj = ((tblu.satis_fiyat - tblu.alis_fiyat) / tblu.satis_fiyat) * 100;
                    tblu.karlilik = karoran;
                    tblu.kar_marji = karmarj; 
                    ent.SaveChanges();
                    Pid.Clear();
                    Pprice.Clear();
                    MessageBox.Show("Product Successfully Edited");
                    guna2DataGridView1.DataSource = ent.Urun.ToList();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Pdelete_Click(object sender, EventArgs e)
        {
            if (Pid.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    int id = Convert.ToInt16(Pid.Text);
                    Urun tblu = ent.Urun.First(f => f.id == id);
                    ent.Urun.Remove(tblu);
                    ent.SaveChanges();
                    Pid.Clear();
                    Pprice.Clear();
                    MessageBox.Show("Product Successfully Removed");
                    guna2DataGridView1.DataSource = ent.Urun.ToList();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void Pback_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Pid.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            Pprice.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        
    }
}

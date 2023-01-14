using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace deneme1
{
    public partial class Procurement : Form
    {
        public Procurement()
        {
            InitializeComponent();
        }

        Model1 ent = new Model1();

        

        private void PMadd_Click(object sender, EventArgs e)
        {
            if (PMtype.Text == "" || PMamount.Text == "" || PMname.Text == "" || PMprice.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {

                    Tedarik tblpm = new Tedarik();
                    tblpm.tedarikciadi = PMname.Text;
                    tblpm.tur = PMtype.Text;
                    tblpm.miktar = Convert.ToDouble(PMamount.Text);
                    tblpm.alisfiyat = Convert.ToDouble(PMprice.Text);
                    try
                    {
                        string queryString ="SELECT tedarikciadi FROM dbo.Tedarikci;";
                        ProviderCheck(PMname.Text.Trim(),queryString);
                        Random rand = new Random();
                        long randnum2 = (long)(rand.NextDouble() * 9999999999999) + 1000000000000;                   
                        tblpm.irsaliyenumarasi = randnum2;
                        ent.Tedarik.Add(tblpm);
                        ent.SaveChanges();
                        PMtype.Clear();
                        PMamount.Clear();
                        PMname.Clear();
                        PMprice.Clear();
                        guna2DataGridView1.DataSource = ent.Tedarik.ToList();
                    }
                    catch (Exception Myex)
                    {
                        MessageBox.Show(Myex.Message);
                    }

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void PMdelete_Click(object sender, EventArgs e)
        {
            if (PMname.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    string tedarikciadi = PMname.Text;
                    Tedarik tblpm = ent.Tedarik.First(f => f.tedarikciadi == tedarikciadi);
                    ent.Tedarik.Remove(tblpm);
                    ent.SaveChanges();
                    PMtype.Clear();
                    PMamount.Clear();
                    PMname.Clear();
                    PMprice.Clear();
                    MessageBox.Show("Product Successfully Removed");
                    guna2DataGridView1.DataSource = ent.Tedarik.ToList();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void PMback_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private static void ProviderCheck(string tedarikciAd,string queryString)

        {
            string machineName = Environment.MachineName;
            string connectionHost = string.Format(@"Data Source={0}\SQLEXPRESS;Initial Catalog=proje_deneme;Integrated Security=True", machineName);
            string connectionString = connectionHost;
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(
                    queryString, connection);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tedarikciAdiLabel = Convert.ToString(reader[0]).Trim();
                        if (tedarikciAdiLabel == tedarikciAd)
                        {
                            string succesMessage = "Basarili bir sekilde eklendi";
                            MessageBox.Show(succesMessage);
                            return;
                        }

                    }

                }
            }
            string dangerMessage = "Boyle bir tedarikci bulunmamaktadır!";
            throw new InvalidCastException(dangerMessage);
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PMname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            PMtype.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            PMamount.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            PMprice.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Procurement_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = ent.Tedarik.ToList();
        }
    }
}

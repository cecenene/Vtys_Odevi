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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace deneme1
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        Model1 ent = new Model1();

        private static void ProviderCheck()

        {
            string machineName = Environment.MachineName;
            string connectionHost = string.Format(@"Data Source={0}\SQLEXPRESS;Initial Catalog=proje_deneme;Integrated Security=True", machineName);
            string connectionString = connectionHost;
            string queryString =
                "SELECT id, saticiadi, urunid, miktar, musteriadi FROM dbo.PesinSatis;";
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
                        string id = Convert.ToString(reader[0]).Trim();
                        string text = Convert.ToString(reader[0]).Trim() + " " + Convert.ToString(reader[1]).Trim() + " " + Convert.ToString(reader[2]).Trim() + " " + Convert.ToString(reader[3]).Trim() + " " + Convert.ToString(reader[4]).Trim() + "\r\n";
                        File.AppendAllText("rapor.pdf", Convert.ToString(text), Encoding.UTF8);
                        File.AppendAllText("rapor.csv", Convert.ToString(text), Encoding.UTF8);


                    }
                    string succesMessage = "Basarili bir sekilde eklendi";
                    MessageBox.Show(succesMessage);
                    return;

                }
            }
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = ent.PesinSatis.ToList();
            guna2DataGridView1.DataSource = ent.VeresiyeSatis.ToList();
        }

        private void Rreport_Click(object sender, EventArgs e)
        {

        }

        private void Rback_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

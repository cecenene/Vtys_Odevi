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

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
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
    }
}

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

        private static void makePesinSatisExcel()

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
                        File.AppendAllText("PesinSatis.csv", Convert.ToString(text), Encoding.UTF8);


                    }
                    string succesMessage = "Basarili bir sekilde eklendi";
                    MessageBox.Show(succesMessage);
                    return;

                }
            }
        }

        private static void makeVeresiyeSatisExcel()

        {
            string machineName = Environment.MachineName;
            string connectionHost = string.Format(@"Data Source={0}\SQLEXPRESS;Initial Catalog=proje_deneme;Integrated Security=True", machineName);
            string connectionString = connectionHost;
            string queryString =
                "SELECT id, saticiadi, urunid, satistarihi, odemetarihi, miktar, musteriadi, tutar FROM dbo.VeresiyeSatis;";
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
                        string text = Convert.ToString(reader[0]).Trim() + " " + Convert.ToString(reader[1]).Trim() + " " + Convert.ToString(reader[2]).Trim() + " " + Convert.ToString(reader[3]).Trim() + " " + Convert.ToString(reader[4]).Trim() + Convert.ToString(reader[5]).Trim() + Convert.ToString(reader[6]).Trim() + Convert.ToString(reader[7]).Trim() + "\r\n";
                        File.AppendAllText("VeresiyeSatis.csv", Convert.ToString(text), Encoding.UTF8);


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
            guna2DataGridView2.DataSource = ent.VeresiyeSatis.ToList();
        }

        private void Rreport_Click(object sender, EventArgs e)
        {
            makePesinSatisPdf();
            makeVeresiyeSatisPdf();
            makePesinSatisExcel();
            makeVeresiyeSatisExcel();

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

        private void makePesinSatisPdf()
        {
            if (guna2DataGridView1.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "PesinSatis.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {
                           File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Unable to wride data in disk" + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(guna2DataGridView1.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in guna2DataGridView1.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }

                            foreach (DataGridViewRow viewRow in guna2DataGridView1.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    pTable.AddCell(dcell.Value.ToString());
                                }
                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }

                            MessageBox.Show("Data Export Successfully", "info");

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Found", "Info");
            }

        }

        private void makeVeresiyeSatisPdf()
        {
            if (guna2DataGridView2.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "VeresiyeSatis.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Unable to wride data in disk" + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(guna2DataGridView2.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in guna2DataGridView2.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }

                            foreach (DataGridViewRow viewRow in guna2DataGridView1.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    pTable.AddCell(dcell.Value.ToString());
                                }
                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }

                            MessageBox.Show("Data Export Successfully", "info");

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Found", "Info");
            }

        }
    }
}

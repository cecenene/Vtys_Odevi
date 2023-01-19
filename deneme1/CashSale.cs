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



namespace deneme1
{
    public partial class CashSale : Form
    {
        public CashSale()
        {
            InitializeComponent();
        }

        Model1 ent = new Model1();

        private void CashSale_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = ent.Urun.ToList();
            guna2DataGridView2.DataSource = ent.PesinSatis.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
            
        {
            Application.Exit();
        }

        private void Add_To_Cash_Sale()
        {
            long barcode = Convert.ToInt64(CSbarcode.Text);
            string customerName = CSname.Text;
            PesinSatis cashSale = new PesinSatis();
            Satici satici = ent.Satici.Find(2);     // BU İD'YE DİKKAT ET HATA ATARSA
            if(satici == null)
            {
                MessageBox.Show("Bu idli kullanici bulunamadi!(Development Error-CS.cs-42)");
            }
            try
            {
                string urunId = return_Id(barcode);
                Urun urun = ent.Urun.Find(Convert.ToInt32(urunId));
                if(urun == null) 
                {
                   MessageBox.Show("Bu barkod bulunamadi!");
                   return;
                }
                if (urun.miktar == 0)
                {
                    MessageBox.Show("Urun miktari 0 olanlar alinamaz!");
                    return;
                }

                cashSale.musteriadi = customerName;
                cashSale.miktar = urun.miktar;
                cashSale.saticiadi = "Cenkay";
                cashSale.urunid = urun.id;
                satici.bakiye += urun.miktar * urun.satis_fiyat;
                urun.miktar = 0;
                ent.PesinSatis.Add(cashSale);
                ent.SaveChanges();
                CSbarcode.Clear();
                CSname.Clear();
                guna2DataGridView1.DataSource = ent.Urun.ToList();
                guna2DataGridView2.DataSource = ent.PesinSatis.ToList();
                MessageBox.Show("Stok durumu kritik, tedarik yapınız!");


            }
            catch (Exception Myex)
            {
                MessageBox.Show(Myex.Message);
            }
            //Tedarik tedarik = ent.Tedarik.Find(product.Item1);

        }

        private void CSback_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CSbarcode.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private string return_Id(long barkod)
        {
            string machineName = Environment.MachineName;
            string connectionHost = string.Format(@"Data Source={0}\SQLEXPRESS;Initial Catalog=proje_deneme;Integrated Security=True", machineName);
            string connectionString = connectionHost;
            string queryString =
                "SELECT id, barkod, miktar FROM dbo.Urun;";
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

                        string idLabel = Convert.ToString(reader[0]).Trim();
                        string barkodLabel = Convert.ToString(reader[1]).Trim();
                        string miktarLabel = Convert.ToString(reader[2]).Trim();
                        if (barkodLabel == Convert.ToString(barkod).Trim())
                        {
                            return idLabel;
                        }

                    }

                }
            }
            string dangerMessage = "Bu barkod bulunamadi!";
            throw new InvalidCastException(dangerMessage);
        }

        private bool Missing_Information()
        {
            if (CSbarcode.Text == "" || CSname.Text == "")
            {
                MessageBox.Show("Missing information");
                return false;
            }
            return true;
        }

        private void CSsale_Click(object sender, EventArgs e)
        {
            bool ThereIsNoMissInfo = Missing_Information();
            if(ThereIsNoMissInfo)
            {
               Add_To_Cash_Sale();
            }
        }
    }
}

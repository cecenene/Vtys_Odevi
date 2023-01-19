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
    public partial class CreditSale : Form
    {
        public CreditSale()
        {
            InitializeComponent();
        }
        Model1 ent = new Model1();

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CreSbarcode.Text = guna2DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreSsale_Click(object sender, EventArgs e)
        {
            bool ThereIsNoMissInfo = Missing_Information();
            if (ThereIsNoMissInfo)
            {
                Add_To_Credit_Sale();
            }
        }

        private bool Missing_Information()
        {
            if (CreSname.Text == "" || CreSbarcode.Text == "")
            {
                MessageBox.Show("Missing information");
                return false;
            }
            return true;
        }

        private void Add_To_Credit_Sale()
        {
            long barcode = Convert.ToInt64(CreSbarcode.Text);
            string customerName = CreSname.Text;
            VeresiyeSatis creditSale = new VeresiyeSatis();
            Odeme odeme = new Odeme();
            Satici satici = ent.Satici.Find(2);     // BU İD'YE DİKKAT ET HATA ATARSA
            if (satici == null)
            {
                MessageBox.Show("Bu idli kullanici bulunamadi!(Development Error-CS.cs-42)");
            }
            try
            {
                string urunId = return_Id(barcode);
                Urun urun = ent.Urun.Find(Convert.ToInt32(urunId));
                if (urun == null)
                {
                    MessageBox.Show("Bu barkod bulunamadi!");
                    return;
                }
                if (urun.miktar == 0)
                {
                    MessageBox.Show("Urun miktari 0 olanlar alinamaz!");
                    return;
                }

                creditSale.musteriadi = customerName;
                creditSale.miktar = urun.miktar;
                creditSale.saticiadi = "Cenkay";
                creditSale.urunid = urun.id;
                DateTime time = DateTime.Now;
                creditSale.satistarihi = time;
                creditSale.tutar += urun.miktar * urun.satis_fiyat;
                DateTime odemetarihi = time.AddMonths(1);
                creditSale.odemetarihi = odemetarihi;
                urun.miktar = 0;
                odeme.musteriadi = customerName;
                odeme.odememiktari = urun.miktar * urun.satis_fiyat;
                odeme.odemetarihi = odemetarihi;
                odeme.saticiadi = "Cenkay";
                ent.VeresiyeSatis.Add(creditSale);
                ent.Odeme.Add(odeme);
                ent.SaveChanges();
                CreSname.Clear();
                CreSbarcode.Clear();
                guna2DataGridView1.DataSource = ent.Urun.ToList();
                guna2DataGridView2.DataSource = ent.VeresiyeSatis.ToList();
                MessageBox.Show("Stok durumu kritik, tedarik yapınız!");


            }
            catch (Exception Myex)
            {
                MessageBox.Show(Myex.Message);
            }
            //Tedarik tedarik = ent.Tedarik.Find(product.Item1);

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

        private void CreSback_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void CreditSale_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = ent.Urun.ToList();
            guna2DataGridView2.DataSource = ent.VeresiyeSatis.ToList();
        }
    }
}

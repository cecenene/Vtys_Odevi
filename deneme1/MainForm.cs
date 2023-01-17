using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Payment ın sayfasını ekle 
//CashSale ekle
//Creditsale ekle
//payback ekle
namespace deneme1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void MFlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void MFuser_Click(object sender, EventArgs e)
        {
            this.Hide();
            User user = new User();
            user.Show();
        }

        private void MFproduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            Product product = new Product();
            product.Show();
        }

        private void MFprovider_Click(object sender, EventArgs e)
        {
            this.Hide();
            Provider provider = new Provider();
            provider.Show();
        }

        private void MFprocurement_Click(object sender, EventArgs e)
        {
            this.Hide();
            Procurement procurement = new Procurement();
            procurement.Show();
        }

        private void MFpayment_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment payment = new Payment();
            payment.Show();
        }

        private void MFcustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customer = new Customer();
            customer.Show();
        }

        private void MFcashsale_Click(object sender, EventArgs e)
        {
            this.Hide();
            CashSale cashsale = new CashSale();
            cashsale.Show();
        }

        private void MFcreditsales_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Creditsale login = new Login();
            //login.Show();
        }

        private void MFpayback_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Payback login = new Login();
            //login.Show();
        }
    }
}

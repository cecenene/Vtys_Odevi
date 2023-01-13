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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Model1 ent = new Model1();

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {

                try
                {
                    LoginFunction(LuserId.Text.Trim(),Lpassword.Text.Trim());
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
        private static void LoginFunction(string kullaniciad,string password)

        {
            string machineName = Environment.MachineName;
            string connectionHost = string.Format(@"Data Source={0}\SQLEXPRESS;Initial Catalog=proje_deneme;Integrated Security=True", machineName);
            string connectionString = connectionHost;
            string queryString =
                "SELECT kullaniciad, sifre FROM dbo.Satici;";
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
                        string kullaniciAdiLabel = Convert.ToString(reader[0]).Trim();
                        string passwordLabel = Convert.ToString(reader[1]).Trim();
                        if (kullaniciAdiLabel == kullaniciad && passwordLabel == password )
                        {
                            string succesMessage = "Basarili bir sekilde giris yaptiniz.";
                            MessageBox.Show(succesMessage);
                            return;
                        } 
                        
                    }

                }
            }
            string dangerMessage = "Sifre dogru degil!";
            throw new InvalidCastException(dangerMessage);
        }
    }
}

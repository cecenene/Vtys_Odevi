using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace deneme1
{
    internal class Sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            string machineName = Environment.MachineName;
            string connectionHost = string.Format(@"Data Source={0}\SQLEXPRESS;Initial Catalog=proje_deneme;Integrated Security=True",machineName);
            SqlConnection baglan = new SqlConnection(connectionHost);
            baglan.Open();
            return baglan;
        }
    }
}

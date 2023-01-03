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
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-NUUA6VV\SQLEXPRESS;Initial Catalog=proje_deneme;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}

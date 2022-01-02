using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace QLNhaSach.XuLy
{
    public class DbConnection
    {
       public SqlConnection connsql;
        public DbConnection()
        {
            connsql = new SqlConnection("Data Source=MSI;Initial Catalog=QLBanHang; Integrated Security = True");
        }
    }
    //User ID = sa; Password=kmt1993"

}

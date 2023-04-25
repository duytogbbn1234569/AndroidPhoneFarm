using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Models
{
    public class Connection
    {
        public string sqlconnectstring = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\PhoneFarm.mdf;
                                    integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        public SqlConnection connection ;
        public Connection() {
            connection = new SqlConnection(sqlconnectstring);
            connection.Open();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DriveNow.DB
{
    public static class dbConnection
    {
        // Connection string pusat
        private static readonly string connectionString =
            "Data Source=YERE\\SQLEXPRESS;Initial Catalog=db_drivenow;Integrated Security=True;TrustServerCertificate=True";

        // Method untuk ambil SqlConnection baru
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
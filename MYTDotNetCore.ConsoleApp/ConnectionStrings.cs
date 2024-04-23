using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYTDotNetCore.ConsoleApp
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "AaronDGrant\\MSSQL",
            InitialCatalog = "MYTDotNetCore",
            UserID = "sa",
            Password = "sa@123",
        };
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYTDotNetCore.MvcApp;

internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder =
        new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "MYTDotNetCore",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };
}

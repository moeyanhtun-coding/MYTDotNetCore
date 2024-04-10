// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");


// => c# => db connection 
SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();

stringBuilder.DataSource = "AaronDGrant\\MSSQL"; // server name 
stringBuilder.InitialCatalog = "MYTDotNetCore"; // database name
stringBuilder.UserID = "sa"; // username
stringBuilder.Password = "sa@123"; // db password

SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

connection.Open();
Console.WriteLine("Connection Success");

string query = "select * from Tbl_Blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
sqlDataAdapter.Fill(dt);

connection.Close();
Console.WriteLine("Connection Close");

// Dataset => DataTable
// DataTable => DataRow
// DataRow => DataColumn

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id => " + dr["BlogId"]);
    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
    Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
    Console.WriteLine("Blog Content => " + dr["BlogContent"]);
    Console.WriteLine("---------------");
}

// Ado.Net Read

 Console.ReadKey(); 
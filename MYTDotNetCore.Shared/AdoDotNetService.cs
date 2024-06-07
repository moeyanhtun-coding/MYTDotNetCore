using System.Data;
using System.Data.SqlClient;
using System.Xml.XPath;
using Newtonsoft.Json;

namespace MYTDotNetCore.Shared;

public class AdoDotNetService
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

    public AdoDotNetService(String connection)
    {
        _sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connection);
    }

    public List<T> Query<T>(string query, List<SqlParameter>? parameters = null)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(query, connection);

        if (parameters != null)
        {
            cmd.Parameters.AddRange(parameters.ToArray());
        }

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        connection.Close();

        var json = JsonConvert.SerializeObject(dt);
        var lst = JsonConvert.DeserializeObject<List<T>>(json)!;
        return lst;
    }

    public T QueryFirstOrDefault<T>(string query, List<SqlParameter>? parameters = null)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(query, connection);
        if (parameters != null)
        {
            cmd.Parameters.AddRange(parameters.ToArray());
        }
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        connection.Close();

        var json = JsonConvert.SerializeObject(dt);
        var lst = JsonConvert.DeserializeObject<List<T>>(json)!;
        if (lst is null)
        {
            return default(T)!;
        }
        return lst[0];
    }

    public int Execute(string query, List<SqlParameter>? parameters = null)
    {
        SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        connection.Open();
        SqlCommand cmd = new SqlCommand(query, connection);
        if (parameters != null)
        {
            cmd.Parameters.AddRange(parameters.ToArray());
        }

        int result = cmd.ExecuteNonQuery();
        connection.Close();

        return result;
    }
}

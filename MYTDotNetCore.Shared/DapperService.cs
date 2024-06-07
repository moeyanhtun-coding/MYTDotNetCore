using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MYTDotNetCore.Shared;

public class DapperService
{
    private SqlConnectionStringBuilder _connectionStringBuilder;

    public DapperService(string connection)
    {
        _connectionStringBuilder = new SqlConnectionStringBuilder(connection);
    }

    public List<T> Query<T>(string query, object? parameters = null)
    {
        using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
        List<T> lst = db.Query<T>(query).ToList();
        return lst;
    }

    public T QueryFirstOrDefault<T>(string query, object? parameters = null)
    {
        using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
        T lst = db.QueryFirstOrDefault<T>(query, parameters)!;
        return lst;
    }

    public int Execute(string query, object? parameters = null)
    {
        using IDbConnection db = new SqlConnection(_connectionStringBuilder.ConnectionString);
        int result = db.Execute(query, parameters);
        return result;
    }
}

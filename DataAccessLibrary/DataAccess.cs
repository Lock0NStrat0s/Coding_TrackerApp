using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary;

public class DataAccess
{
    public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            List<T> rows = connection.Query<T>(sqlStatement, parameters).ToList();
            return rows;
        }
    }

    public void SaveData<T>(string sqlStatement, T parameters, string connectionString)
    {
        using (IDbConnection connection = new SqliteConnection(connectionString))
        {
            connection.Execute(sqlStatement, parameters);
        }
    }
}

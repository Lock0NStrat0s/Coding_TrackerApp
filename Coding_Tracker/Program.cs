using ConsoleTableExt;
using DataAccessLibrary;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace Coding_Tracker;

public class Program
{
    static void Main(string[] args)
    {
        //MainMenu();

        SqliteCRUD sql = new SqliteCRUD(GetConnectionString());

        ReadDateLog(sql);
    }

    private static void ReadDateLog(SqliteCRUD sql)
    {
        var rows = sql.GetDateLog();

        foreach (var row in rows)
        {
            Console.WriteLine($"{row.Id}: {row.Date}");
        }
    }

    private static string GetConnectionString(string connectionStringName = "Default")
    {
        string output = "";

        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");

        var config = builder.Build();

        output = config.GetConnectionString(connectionStringName);

        return output;
    }

    private static void MainMenu()
    {
        SqliteCRUD sql = new SqliteCRUD(GetConnectionString());

        using (SqliteConnection sqlConnection = CreateConnection())
        {
            int output;
            bool runApp = true;

            while (runApp)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Coding TRACKER\n\nMAIN MENU\n");
                    Console.WriteLine("0 - Close Application");
                    Console.WriteLine("1 - View All Records");
                    Console.WriteLine("2 - INSERT Record");
                    Console.WriteLine("3 - DELETE Record");
                    Console.WriteLine("4 - UPDATE Record");
                    Console.Write("Select from the following: ");

                    int.TryParse(Console.ReadLine(), out output);

                    switch (output)
                    {
                        case 0:
                            runApp = false;
                            break;
                        case 1:
                            ReadDB(sqlConnection);
                            break;
                        case 2:
                            InsertData(sqlConnection);
                            break;
                        case 3:
                            DeleteData(sqlConnection);
                            break;
                        case 4:
                            UpdateData(sqlConnection);
                            break;
                        default:
                            break;
                    }
                } while (output < 0 || output > 4);
            }
        }
    }

    private static SqliteConnection CreateConnection()
    {
        SqliteConnection sqlite_conn;

        // Create a new database connection
        sqlite_conn = GetConnectionString();

        // Open the connection
        sqlite_conn.Open();

        return sqlite_conn;
    }

    
}
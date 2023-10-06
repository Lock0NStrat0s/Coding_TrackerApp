using Coding_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary;

public class SqliteCRUD
{
    private readonly string _connectionString;
	private DataAccess db = new();

    public SqliteCRUD(string connectionString)
	{
		_connectionString = connectionString;
	}

	public List<DateLogModel> GetDateLog()
	{
		string sql = "select Id, Date from dbo.DateLog";

		return db.LoadData<DateLogModel, dynamic>(sql, new { }, _connectionString);
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary;

public class SqliteCRUD
{
    private readonly string _connectionString;

    public SqliteCRUD(string connectionString)
	{
		_connectionString = connectionString;
	}
}

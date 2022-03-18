using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Persistent.Dapper
{
	public class DapperContext 
	{
		private readonly string _connectionString;

		public DapperContext(string connectionString) => _connectionString = connectionString;

		public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

		public string Inventories => "[seller].Inventories";

		public string Users => "[user].Users";
		public string Orders => "[order].Orders";
	}
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using RasiMarket.Data.Models;

namespace RasiMarket.Data
{
    public partial class DataHelper
    {
        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["RasiContext"].ConnectionString
            };
            return conn;
        }

        public static void ExecuteQuery(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Execute(query);
            }
        }

        public static dynamic SelectQueryRun(string query)
        {
            using (var conn = GetConnection())
            {
                return conn.Query<dynamic>(query);
            }
        }
        public static int ExecQueryRun(string query)
        {
            using (var conn = GetConnection())
            {
                return conn.Execute(query);
            }
        }
    }
}

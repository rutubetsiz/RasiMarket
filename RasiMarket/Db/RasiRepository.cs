using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RasiMarket.Db
{
    public class RasiRepository : IRasiRepository
    {

        public RasiRepository()
        {
        }


        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["RasiContext"].ConnectionString);
            }
        }
    }
}
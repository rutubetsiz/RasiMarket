using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq; 
using DapperExtensions;

namespace RasiMarket.Db.Base
{
    public abstract class RasiRepository<T> : IRasiRepository<T> where T: ModelBase, new()
    {
        private readonly string _connectionString;

        public RasiRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["RasiContext"].ConnectionString;
        }

        public virtual void Delete(int id)
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            { 

                 dbConnection.Delete(new T { Id = id });
            }
        }

        public virtual List<T> GetAll()
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.GetList<T>().ToList();
            }
        }

        public virtual void Insert(T item)
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                dbConnection.Insert(item);
            }
        }

        public virtual void Update(T item)
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Update(item);
            }
        }
    }
}
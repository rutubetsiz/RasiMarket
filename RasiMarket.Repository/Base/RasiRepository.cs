using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using DapperExtensions;

namespace RasiMarket.Repository.Base
{
    public abstract class RasiRepository<T> : IRasiRepository<T> where T: ModelBase, new()
    {
        private readonly string _connectionString;

        public RasiRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["RasiContext"].ConnectionString;
        }

        public virtual int Count(object predicate)
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {

                var cnt = dbConnection.Count<T>(predicate);
               return cnt;
            }
        }

        public virtual void Delete(int id)
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            { 

                 dbConnection.Delete(new T { ID = id });
            }
        }
        public virtual T Get(int id)
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                dbConnection.Open();
                return dbConnection.Get<T>(id);
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

        public virtual List<T> GetPage(int page, int perPage, bool isAscending, string sortColumnName)
        {
            using (var dbConnection = new SqlConnection(_connectionString))
            {
                var sort = new List<ISort>() {new Sort() {Ascending = isAscending, PropertyName = sortColumnName} };
                dbConnection.Open();
                return dbConnection.GetPage<T>(null, sort, page, perPage, null, null).ToList();
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
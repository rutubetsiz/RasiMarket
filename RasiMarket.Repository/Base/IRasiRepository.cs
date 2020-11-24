using System.Collections.Generic;

namespace RasiMarket.Repository.Base
{
    public interface IRasiRepository<T> : IRepository where T : ModelBase, new()
    {
        T Get(int id);
        List<T> GetAll();
        List<T> GetPage(int page, int perPage, bool isAscending, string sortColumnName);
        void Insert(T item);
        void Update(T item);
        void Delete(int id); 
    }
}
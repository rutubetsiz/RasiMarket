using System.Collections.Generic;

namespace RasiMarket.Db.Base
{
    public interface IRasiRepository<T> where T : ModelBase, new()
    {
        List<T> GetAll();
        void Insert(T item);
        void Update(T item);
        void Delete(int id); 
    }
}
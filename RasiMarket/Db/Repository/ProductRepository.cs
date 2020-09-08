using RasiMarket.Db.Base;
using RasiMarket.Models;

namespace RasiMarket.Db.Repository
{
    public interface IProductsRepository : IRasiRepository<Products>
    {

    }
    public class ProductsRepository : RasiRepository<Products> , IProductsRepository
    {
        
    }
}
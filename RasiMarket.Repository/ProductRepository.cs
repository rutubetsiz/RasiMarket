using RasiMarket.Repository.Base;
using RasiMarket.Repository.Models;

namespace RasiMarket.Repository
{
    public interface IProductsRepository : IRasiRepository<Products>
    {

    }
    public class ProductsRepository : RasiRepository<Products> , IProductsRepository
    {
        
    }
}
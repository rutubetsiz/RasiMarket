using RasiMarket.Repository.Base;
using RasiMarket.Repository.Models;

namespace RasiMarket.Repository
{
    public interface ICategoryRepository : IRasiRepository<Category>
    {

    }
    public class CategoryRepository : RasiRepository<Category> , ICategoryRepository
    {
        
    }
}
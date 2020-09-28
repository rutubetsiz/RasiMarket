using DapperExtensions.Mapper;

namespace RasiMarket.Repository.Models.Map
{
    public class CategoryMap : ClassMapper<Category>
    {
        public CategoryMap()
        {
            Schema("rasiuser");
            Table("Categories");
            AutoMap();
        }
    }
}
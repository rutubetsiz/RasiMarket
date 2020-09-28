using DapperExtensions.Mapper;

namespace RasiMarket.Repository.Models.Map
{
    public class ProductsMap : ClassMapper<Products>
    {
        public ProductsMap()
        {
            Schema("rasiuser");
            Table("Products");
            AutoMap();
        }
    }
}
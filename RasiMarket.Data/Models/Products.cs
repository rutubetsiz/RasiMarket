
namespace RasiMarket.Data.Models
{
    public class Products
    {
        public int ID { get; set; }
        public string BarcodeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal? Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public int? Popularity { get; set; }
        public string CategoriName { get; set; }

        public bool IsActive { get; set; }
    }
}
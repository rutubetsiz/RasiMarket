using RasiMarket.Db.Base;

namespace RasiMarket.Models
{
    public class Products : ModelBase
    {
        public string BarcodeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal? Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        public string ThumbnailUrl { get; set; }
        public long ID { get; set; }
        public int? Popularity { get; set; }
    }
}
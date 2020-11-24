
namespace RasiMarket.Data.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PriorityOrder { get; set; }
        public int? ParentId { get; set; }
    }
}
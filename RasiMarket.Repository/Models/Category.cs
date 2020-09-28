using RasiMarket.Repository.Base;

namespace RasiMarket.Repository.Models
{
    public class Category : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? PriorityOrder { get; set; }
        public int? ParentId { get; set; }
    }
}
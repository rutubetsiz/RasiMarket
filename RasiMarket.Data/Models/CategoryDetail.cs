using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasiMarket.Data.Models
{
    public class CategoryDetail
    {
        public string MainCategoryName { get; set; }
        public List<Category> Subcategories { get; set; }
        public List<Products> Products { get; set; }
    }
}

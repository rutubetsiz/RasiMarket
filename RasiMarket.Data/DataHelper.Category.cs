using Dapper;
using RasiMarket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasiMarket.Data
{
    public partial class DataHelper
    {
        public static IEnumerable<Category> GetMainCategories()
        {
            using (var conn = GetConnection())
            {
                string sql = "SELECT * FROM Categories WHERE ParentId = 0 ORDER BY PriorityOrder";
                return conn.Query<Category>(sql);
            }
        }

        public static CategoryDetail GetCategoryDetail(int catId)
        {
            using (var conn = GetConnection())
            {
                var catDetail = new CategoryDetail();
                string sql = "SELECT Name FROM Categories WHERE ID = " + catId +
                    "; SELECT * FROM Categories WHERE ParentId = " + catId + " ORDER BY PriorityOrder ;"+
                    "SELECT * FROM Products AS P2    JOIN (    SELECT P.BarcodeId,    STUFF((SELECT ';' + C.Name             FROM CategoryRelations AS CR 			INNER JOIN Categories AS C ON C.ID = CR.CategoryId             WHERE CR.BarcodeId = P.BarcodeId             FOR XML PATH(''), TYPE).value('.', 'nvarchar(max)'), 1, 1, ''         ) AS CategoriName    FROM Products AS P    WHERE P.BarcodeId IN (SELECT BarcodeId FROM CategoryRelations WHERE CategoryId = "+ catId + ")    GROUP BY P.BarcodeId) AS P1    ON P1.BarcodeId = P2.BarcodeId WHERE IsActive = 1 ORDER BY P2.Popularity;";
                var model = conn.QueryMultiple(sql);
                catDetail.MainCategoryName = model.Read<string>().FirstOrDefault();
                catDetail.Subcategories = model.Read<Category>().ToList();
                catDetail.Products = model.Read<Products>().ToList();

                return catDetail;
            }
        }
    }
}

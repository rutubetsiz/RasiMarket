using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RasiMarket.Repository.Base;
using RasiMarket.Repository.Response;

namespace RasiMarket.Repository
{
    public class Paginator
    {
        public static pagination ExtractPagination<T>(IRepository rasiRepository,  NameValueCollection qs) where T: class
        {
            var pg = pagination.DefaultPagination();
            if (qs.Count == 0)
                return pg;

            var ttCount = rasiRepository.Count(null);
            var ttPage = string.IsNullOrEmpty(qs["pagination[page]"]) ? 1 : Convert.ToInt32(qs["pagination[page]"]);
            var ttPages = string.IsNullOrEmpty(qs["pagination[pages]"]) ? 1 : Convert.ToInt32(qs["pagination[pages]"]);
            var ttPerPage = string.IsNullOrEmpty(qs["pagination[perpage]"]) ? 20 : Convert.ToInt32(qs["pagination[perpage]"]);
            var ttTotal = string.IsNullOrEmpty(qs["pagination[total]"]) ? 1 : Convert.ToInt32(qs["pagination[page]"]);
          
           var ppgs = ttTotal / ttPerPage;
           if (ttTotal > ppgs * ttPerPage)
               ppgs = ppgs + 1;

            pg.pages = ppgs;
            pg.total = ttCount;

            return pg;

        }
    }
}

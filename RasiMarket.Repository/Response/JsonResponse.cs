using System.Collections.Generic;

namespace RasiMarket.Repository.Response
{
    public class pagination
    {
        public pagination()
        {

        }
        public int page { get; set; }
        public int pages { get; set; }
        public int perpage { get; set; }
        public int total { get; set; }
        public string sort { get; set; }
        public string field { get; set; }

        public static pagination DefaultPagination()
        {
            return new pagination()
            {
                pages = 35,
                page = 1,
                sort = "asc",
                total = 100,
                perpage = 10,
                field = "ID"
                
            };
        }
    }
    public class JsonResponse<T> where T : class
    { 
        public pagination meta { get; set; }
        public List<T> data { get; set; }

        public JsonResponse()
        {
            meta = new pagination();
            data = new List<T>();
        }
    }
}
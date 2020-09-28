using System;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RasiMarket.Repository;
using RasiMarket.Repository.Models;
using RasiMarket.Repository.Response; 

namespace RasiMarketAdmin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly ICategoryRepository _categoryRepository;

        private readonly DefaultContractResolver _contractResolver = new DefaultContractResolver
            {NamingStrategy = new CamelCaseNamingStrategy()};

        private readonly JsonSerializerSettings _jss = new JsonSerializerSettings
            {ReferenceLoopHandling = ReferenceLoopHandling.Ignore, StringEscapeHandling = StringEscapeHandling.EscapeHtml};

        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
            _jss.ContractResolver = _contractResolver;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCategories()
        {
            var pageInfo = Paginator.ExtractPagination<Category>(_categoryRepository, Request.QueryString);
            var categories = _categoryRepository.GetPage(pageInfo.page, pageInfo.perpage, pageInfo.sort == "asc", pageInfo.field);
            var jsonresponse = new JsonResponse<Category>
            {
                data = categories,
                meta = pageInfo
            };
            //Paginator.GeneratePagination(categories, ref jsonresponse);
            return Json(jsonresponse,JsonRequestBehavior.AllowGet );//(JsonConvert.SerializeObject(response, Formatting.None, _jss), JsonRequestBehavior.AllowGet);
        }
    }
}
using System;
using System.Linq;
using System.Net;
using System.Web;
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
            if (TempData.Any(x => x.Key == "ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"];
                TempData.Remove("ErrorMessage");
            }

            return View();
        }

        public ActionResult EditCategory(int id)
        {

            var categories = _categoryRepository.GetAll();
            if (id != 0)
            {
                var category = _categoryRepository.Get(id);
                if (category == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                categories.Remove(categories.FirstOrDefault(f => f.ID == category.ID));
                categories.Add(new Category(){ Description = "", ParentId = null, ID = 0, Name = "Hiçbiri", PriorityOrder = null});
                ViewBag.Categories = categories;
                return PartialView(category);
            }

            ViewBag.Categories = categories ;
            return PartialView(new Category());
        }


        public JsonResult DeleteCategory(int id)
        {

            try
            {
                var category = _categoryRepository.Get(id);
                if (category == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NoContent;
                    return Json("not_found", JsonRequestBehavior.AllowGet);
                }

                _categoryRepository.Delete(id);
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("fail", JsonRequestBehavior.AllowGet);
            }

            return Json("success", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult EditCategory(Category model)
        {
            try
            {
                //if(model.ParentId == 0)
                //    model.ParentId = null;

                if (model.ID == 0)
                    _categoryRepository.Insert(model);
                else
                    _categoryRepository.Update(model);

              
            }
            catch (Exception exception)
            {
                TempData["ErrorMessage"] = "Kaydederken hata oluştu." + exception.Message;
            }

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public JsonResult GetCategories()
        {
            //var pageInfo = Paginator.ExtractPagination<Category>(_categoryRepository, Request.QueryString);
            var categories = _categoryRepository.GetAll();

            //Paginator.GeneratePagination(categories, ref jsonresponse);
            return Json(JsonConvert.SerializeObject(categories, Formatting.None, _jss), JsonRequestBehavior.AllowGet);
        }
    }
}
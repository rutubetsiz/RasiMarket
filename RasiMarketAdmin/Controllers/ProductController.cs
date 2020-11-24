using System;
using System.Collections.Generic;
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
    public class ProductController : Controller
    {
        private readonly IProductsRepository _productsRepository;

        private readonly DefaultContractResolver _contractResolver = new DefaultContractResolver
        { NamingStrategy = new CamelCaseNamingStrategy() };

        private readonly JsonSerializerSettings _jss = new JsonSerializerSettings
        { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, StringEscapeHandling = StringEscapeHandling.EscapeHtml };

        public ProductController()
        {
            _productsRepository = new ProductsRepository();
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

        public ActionResult EditProduct(int id)
        {

           
                var product = _productsRepository.Get(id);
                if (product == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                
                return PartialView(product);
        }


        public JsonResult DeleteProduct(int id)
        {

            try
            {
                var products = _productsRepository.Get(id);
                if (products == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.NoContent;
                    return Json("not_found", JsonRequestBehavior.AllowGet);
                }

                _productsRepository.Delete(id);
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("fail", JsonRequestBehavior.AllowGet);
            }

            return Json("success", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult EditProduct(Products model)
        {
            try
            {
                //if(model.ParentId == 0)
                //    model.ParentId = null;

                if (model.ID == 0)
                    _productsRepository.Insert(model);
                else
                    _productsRepository.Update(model);


            }
            catch (Exception exception)
            {
                TempData["ErrorMessage"] = "Kaydederken hata oluştu." + exception.Message;
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public JsonResult GetProducts()
        {
            //var pageInfo = Paginator.ExtractPagination<Product>(_productsRepository, Request.QueryString);
            var products = _productsRepository.GetAll();

            //Paginator.GeneratePagination(categories, ref jsonresponse);
            return Json(JsonConvert.SerializeObject(products, Formatting.None, _jss), JsonRequestBehavior.AllowGet);
        }


    }
}
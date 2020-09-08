using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RasiMarket.Db.Repository;

namespace RasiMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository repo;

        public HomeController()
        {
            repo = new ProductsRepository();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProducts()
        {

            var products = repo.GetAll();
            return View(products);
        }
    }
}
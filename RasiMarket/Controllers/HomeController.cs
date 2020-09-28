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

        public ActionResult Category(int id)
        {

            var products = repo.GetAll();
            return View(products);
        }

        public ActionResult GetProductDetail(int id)
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
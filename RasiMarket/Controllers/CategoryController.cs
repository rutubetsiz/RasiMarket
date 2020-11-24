using RasiMarket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RasiMarket.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult Category(int id)
        {
            return View(DataHelper.GetCategoryDetail(id));
        }
    }
}
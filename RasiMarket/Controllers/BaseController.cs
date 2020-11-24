using RasiMarket.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RasiMarket.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.ViewData["LayoutViewModel"] = DataHelper.GetMainCategories();
        }
    }
}
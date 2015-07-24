using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VitalFew.Transdev.Australasia.Data.Api.Providers;
using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;

namespace VitalFew.Transdev.Australasia.Data.Api.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Values Controller
        /// </summary>
        /// <param name="dataProvider"></param>
        public HomeController()
        {
            
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}

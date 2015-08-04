using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VitalFew.Transdev.Australasia.Data.Api.Controllers
{
    public class ClientsController : Controller
    {
        // GET: Clients
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VitalFew.Transdev.Australasia.Data.Api.Console.Controllers
{
    public class BaseController : Controller
    {
        public Exception ExceptionDetails
        {
            set
            {
                TempData["Exception"] = value;
            }
        }

        public string ErrorMessage
        {
            set
            {
                TempData["ErrorMessage"] = value;
            }
        }

        public string SuccessMessage
        {
            set
            {
                TempData["SuccessMessage"] = value;
            }
        }
    }
}
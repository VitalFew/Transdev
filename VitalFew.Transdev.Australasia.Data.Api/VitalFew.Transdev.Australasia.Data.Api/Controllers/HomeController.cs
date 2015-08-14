using System.Web.Mvc;


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
            return View("");
        }
    }
}

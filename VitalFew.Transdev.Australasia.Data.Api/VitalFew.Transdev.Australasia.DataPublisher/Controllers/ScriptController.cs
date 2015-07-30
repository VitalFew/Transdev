using System.Text;
using System.Web.Mvc;
using VitalFew.Transdev.Australasia.DataPublisher.Navigation;
using VitalFew.Transdev.Australasia.DataPublisher.Navigation.Contract;

namespace VitalFew.Transdev.Australasia.DataPublisher.Controllers
{
    public class ScriptController : Controller
    {
        //TODO: Should be injected
        private readonly INavigationScriptManager _navigationScriptManage=new NavigationScriptManager(new NavigationManager());

        //public ScriptController(INavigationScriptManager navigationScriptManage)
        //{
        //    _navigationScriptManage = navigationScriptManage;
        //}

        public ScriptController() {
        }

        /// <summary>
        /// Gets the scripts.
        /// </summary>
        /// <returns></returns>
        public ActionResult GetScripts()
        {
            var sb = new StringBuilder();
            sb.AppendLine( _navigationScriptManage.GetScript());
            sb.AppendLine();

            return Content(sb.ToString(), "application/x-javascript", Encoding.UTF8);
        }
    }
}
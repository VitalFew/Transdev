using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;

namespace VitalFew.Transdev.Australasia.Data.Api.Controllers
{
    public class ClientObjectsController : Controller
    {
        private readonly IClientProvider _clientProvider;

        public ClientObjectsController(IClientProvider clientProvider)
        {
            _clientProvider = clientProvider;
        }

        // GET: ClientObjects
        public ActionResult Get(int clientId)
        {
            var objects = _clientProvider.GetAll().Where(x => x.TRANSDEV_ID == clientId).Include(x => x.VF_API_CLIENT_OBJECTS).First().VF_API_CLIENT_OBJECTS.ToList();
            return PartialView("~/Views/ClientObjects/_ClientObjectsView.cshtml", objects);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;
using VitalFew.Transdev.Australasia.Data.Core.Database;

namespace VitalFew.Transdev.Australasia.Data.Api.Controllers
{
    public class ClientObjectsController : Controller
    {
        private readonly IClientObjectProvider _clientObjectProvider;
        private readonly IClientDataProvider _dataProvider;

        public ClientObjectsController(IClientObjectProvider clientObjectProvider,IClientDataProvider dataProvider)
        {
            _clientObjectProvider = clientObjectProvider;
            _dataProvider = dataProvider;
        }

        // GET: ClientObjects
        public ActionResult Get(Guid guid,int clientId)
        {
            AddedKeyToTempData(clientId, guid);
            var objects = _clientObjectProvider.GetAll().Where(x => x.TRANSDEV_ID == clientId).ToList();
            return PartialView("~/Views/ClientObjects/_ClientObjectsView.cshtml", objects);
        }

        [HttpGet]
        public ActionResult Add(Guid guid,int clientId)
        {
            AddedKeyToTempData(clientId, guid);
            List<SelectListItem> items = GetProviders();

             ViewBag.Providviders=  new SelectList(items, "Value", "Text");
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Add(VF_API_CLIENT_OBJECTS objects)
        {
            var clientId = TempData["clientId"];
            var guid = TempData["guid"];
            objects.TRANSDEV_ID = (int)clientId;
            var addAndEditTime = DateTime.Now;
            objects.DB_OBJECT_MODIFIED_DATE = addAndEditTime;
            objects.DB_OBJECT_CREATED_DATE = addAndEditTime;
            await _clientObjectProvider.Save(objects);

            return RedirectToAction("Edit", "Clients", new { id = guid });
        }

        [HttpGet]
        public ActionResult Edit(int transDevId, string transDevParam)
        {
           var clientObject = _clientObjectProvider.GetAll().Where(x => x.TRANSDEV_ID == transDevId && x.TRANSDEV_PARAM.Equals(transDevParam)).First();
            List<SelectListItem> items = GetProviders();
            ViewBag.Providviders = new SelectList(items, "Value", "Text");

            return View(clientObject);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Edit(VF_API_CLIENT_OBJECTS clientObject)
        {
            clientObject.DB_OBJECT_MODIFIED_DATE = DateTime.Now;
            await _clientObjectProvider.Save(clientObject);

            return RedirectToAction("Edit", new { transDevId = clientObject.TRANSDEV_ID, transDevParam = clientObject.TRANSDEV_PARAM });
        }

        private List<SelectListItem> GetProviders()
        {
            List<SelectListItem> items = (from data in _dataProvider.GetAll()
                                          select new SelectListItem
                                          {
                                              Value = data.DATA_PROVIDER_ID.ToString(),
                                              Text = data.DATA_PROVIDER_Name,
                                          }).ToList();

            return items;
        }

        private void AddedKeyToTempData(int clientId,Guid guid)
        {
            TempData.Remove("clientId");
            TempData.Remove("guid");
            TempData.Add("clientId", clientId);
            TempData.Add("guid", guid);
        }
    }
}
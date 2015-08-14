using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VitalFew.Transdev.Australasia.Data.Api.Console.Models.Dto;

using VitalFew.Transdev.Australasia.Data.Core.Database;
using VitalFew.Transdev.Australasia.Data.Core.Framework;
using VitalFew.Transdev.Australasia.Data.Core.Providers.Contract;

namespace VitalFew.Transdev.Australasia.Data.Api.Console.Controllers
{
    public class ClientsController : BaseController
    {
        private readonly ICatalogClientProvider _catalogClientProvider;

        public ClientsController(ICatalogClientProvider catalogClientProvider)
        {
            _catalogClientProvider = catalogClientProvider;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var client = _catalogClientProvider.GetAll().Where(x => x.CLIENT_ID.Equals(id)).FirstOrDefault();

            return View(client);
        }

        public async Task<ActionResult> Edit(VF_API_CATALOG_CLIENTS client)
        {
            try
            {
                await _catalogClientProvider.Save(client);

                SuccessMessage = "Client is Updated";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ExceptionDetails = ex;
                ErrorMessage = "Unexpected error occured while updating the client";
            }

            return View(client);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new VF_API_CATALOG_CLIENTS { CLIENT_TOKEN = ClientToken.NewToken() });
        }

        [HttpPost]
        public async Task<ActionResult> Add(VF_API_CATALOG_CLIENTS client)
        {
            try
            {
                client.CLIENT_ID = Guid.NewGuid();
                await _catalogClientProvider.Save(client);

                SuccessMessage = "New Client is Added";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ExceptionDetails = ex;
                ErrorMessage = "Unexpected error occured while creating a client";
            }

            return View(client);
        }

        public JsonResult GetToken()
        {
            return Json(ClientToken.NewToken(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AjaxDataProvider(JQueryDataTableParamModel param)
        {
            IEnumerable<VF_API_CATALOG_CLIENTS> filteredClients;
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
                var nameFilter = Convert.ToString(Request["sSearch_1"]);
                var status = Convert.ToString(Request["sSearch_2"]);

                //Optionally check whether the columns are searchable at all 
                var isNameSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isStatusSearchable = Convert.ToBoolean(Request["bSearchable_2"]);

                filteredClients = _catalogClientProvider.GetAll().Where(c => isNameSearchable && c.CLIENT_NAME.ToLower().Contains(param.sSearch.ToLower())
                                 ||
                                 isStatusSearchable && c.CLIENT_STATUS == (status == "Active" ? true : false));
            }
            else
            {
                filteredClients = _catalogClientProvider.GetAll();
            }
            var isNameSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<VF_API_CATALOG_CLIENTS, string> orderingFunction = (c => sortColumnIndex == 1 && isNameSortable ? c.CLIENT_NAME : "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredClients = filteredClients.OrderBy(orderingFunction);
            else
                filteredClients = filteredClients.OrderByDescending(orderingFunction);

            var displayedClients = filteredClients.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedClients select new[] { Convert.ToString(c.CLIENT_ID), c.CLIENT_NAME, ((c.CLIENT_STATUS && c.CLIENT_STATUS) ? "Active" : "In-Active") };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = filteredClients.Count(),
                iTotalDisplayRecords = displayedClients.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

    }
}
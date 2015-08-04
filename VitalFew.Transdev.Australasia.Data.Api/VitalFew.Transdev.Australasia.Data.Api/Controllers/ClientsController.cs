using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VitalFew.Transdev.Australasia.Data.Api.Models;
using VitalFew.Transdev.Australasia.Data.Api.Models.Dto;
using VitalFew.Transdev.Australasia.Data.Api.Provider;

namespace VitalFew.Transdev.Australasia.Data.Api.Controllers
{
    public class ClientsController : Controller
    {
        // GET: Clients
        public ActionResult Index()
        {
            return View();
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

                //TODO:should inject provider
                filteredClients = new ClientProvider().GetAll().Where(c => isNameSearchable && c.CLIENT_NAME.ToLower().Contains(param.sSearch.ToLower())
                                 ||
                                 isStatusSearchable && c.CLIENT_STATUS == (status == "Active" ? true : false));

            }
            else
            {
                filteredClients = new ClientProvider().GetAll();
            }
            var isNameSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<VF_API_CATALOG_CLIENTS, string> orderingFunction = (c => sortColumnIndex == 1 && isNameSortable ? c.CLIENT_NAME : "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                filteredClients = filteredClients.OrderBy(orderingFunction);
            else
                filteredClients = filteredClients.OrderByDescending(orderingFunction);

            var displayedCompanieClients = filteredClients.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var displayedClients = filteredClients.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedClients select new[] { Convert.ToString(c.CLIENT_ID), c.CLIENT_NAME, ((c.CLIENT_STATUS.HasValue && c.CLIENT_STATUS.Value) ? "Active" : "In-Active") };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = 100,
                iTotalDisplayRecords = 2,
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
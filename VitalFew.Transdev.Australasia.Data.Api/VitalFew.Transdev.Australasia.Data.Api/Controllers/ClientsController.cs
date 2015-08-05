using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

            var displayedClients = filteredClients.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedClients select new[] { Convert.ToString(c.CLIENT_ID), c.CLIENT_NAME, ((c.CLIENT_STATUS.HasValue && c.CLIENT_STATUS.Value) ? "Active" : "In-Active") };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = filteredClients.Count(),
                iTotalDisplayRecords = displayedClients.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(Guid guid)
        {
            var client = new ClientProvider().GetAll().Where(x => x.CLIENT_ID.HasValue && x.CLIENT_ID.Value.Equals(guid)).FirstOrDefault();

            return View(client);
        }

        public async System.Threading.Tasks.Task<ActionResult> Edit(VF_API_CATALOG_CLIENTS client)
        {
            await new ClientProvider().Save(client);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View(new VF_API_CATALOG_CLIENTS { CLIENT_TOKEN= GenerateId()});
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Add(VF_API_CATALOG_CLIENTS client)
        {
            //TODO: Should Generate from SQL
            client.CLIENT_ID = Guid.NewGuid();
            await new ClientProvider().Save(client);

            return RedirectToAction("Index");
        }

        public JsonResult GetToken()
        {
            return Json(GenerateId(), JsonRequestBehavior.AllowGet);
        }

        private string GenerateId()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            var key= string.Format("{0:x}", i - DateTime.Now.Ticks);
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 20-key.Length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return key + result;
        }
    }
}
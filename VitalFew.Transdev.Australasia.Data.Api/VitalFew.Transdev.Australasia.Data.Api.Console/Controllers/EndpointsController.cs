﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

using VitalFew.Transdev.Australasia.Data.Core.Database;
using VitalFew.Transdev.Australasia.Data.Core.Providers.Contract;

namespace VitalFew.Transdev.Australasia.Data.Api.Console.Controllers
{
    public class EndpointsController : BaseController
    {
        private readonly ICatalogClientProvider _catalogClientProvider;
        private readonly IClientObjectProvider _clientObjectProvider;
        private readonly ILookupProvider _lookupProvider;

        public EndpointsController(ICatalogClientProvider catalogClientProvider, 
            IClientObjectProvider clientObjectProvider, ILookupProvider lookupProvider)
        {
            _catalogClientProvider = catalogClientProvider;
            _clientObjectProvider = clientObjectProvider;
            _lookupProvider = lookupProvider;
        }

        public ActionResult Index(Guid id)
        {
            var client = _catalogClientProvider.GetAll().Where(x => x.CLIENT_ID.Equals(id)).FirstOrDefault();

            return View(client);
        }

        public ActionResult Get(Guid id)
        {
            var objects = _clientObjectProvider.GetAll()
                .Where(x => x.VF_API_CATALOG_CLIENTS.CLIENT_ID == id).ToList();

            return PartialView("~/Views/Endpoints/_EndpointsView.cshtml", objects);
        }

        [HttpGet]
        public ActionResult Add(Guid id)
        {
            List<SelectListItem> items = GetProviders();
            ViewBag.Providviders=  new SelectList(items, "Value", "Text");

            var model = new VF_API_CLIENT_OBJECTS();
            model.TRANSDEV_ID = _catalogClientProvider.GetAll().Where(e => e.CLIENT_ID == id).FirstOrDefault().TRANSDEV_ID;

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(VF_API_CLIENT_OBJECTS model)
        {
            try
            {
                model.DB_OBJECT_MODIFIED_DATE = DateTime.Now;
                model.DB_OBJECT_CREATED_DATE = DateTime.Now;

                await _clientObjectProvider.Save(model);
                var client = _catalogClientProvider.GetAll().Where(x => x.TRANSDEV_ID == model.TRANSDEV_ID).First();

                SuccessMessage = "New Endpoint is Added";

                return RedirectToAction("Edit", "Clients", new { id = client.CLIENT_ID });
            }
            catch(Exception ex)
            {
                ExceptionDetails = ex;
                ErrorMessage = "Unexpected error occured while creating an endpoint";
            }

            List<SelectListItem> items = GetProviders();
            ViewBag.Providviders = new SelectList(items, "Value", "Text");

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
           var clientObject = _clientObjectProvider.GetAll().Where(x => x.CLIENT_OBJECT_ID == id).First();
            List<SelectListItem> items = GetProviders();
            ViewBag.Providviders = new SelectList(items, "Value", "Text");

            return View(clientObject);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(VF_API_CLIENT_OBJECTS model)
        {
            try
            {
                model.DB_OBJECT_MODIFIED_DATE = DateTime.Now;
                await _clientObjectProvider.Save(model);

                var client = _catalogClientProvider.GetAll().Where(x => x.TRANSDEV_ID == model.TRANSDEV_ID).First();

                SuccessMessage = "Endpoint is Updated";

                return RedirectToAction("Edit", "Clients", new { id = client.CLIENT_ID });
            }
            catch (Exception ex)
            {
                ExceptionDetails = ex;
                ErrorMessage = "Unexpected error occured while updating the endpoint";
            }

            List<SelectListItem> items = GetProviders();
            ViewBag.Providviders = new SelectList(items, "Value", "Text");

            return View(model);
        }

        private List<SelectListItem> GetProviders()
        {
            List<SelectListItem> items = (from data in _lookupProvider.GetProviders()
                                          select new SelectListItem
                                          {
                                              Value = data.DATA_PROVIDER_ID.ToString(),
                                              Text = data.DATA_PROVIDER_Name,
                                          }).ToList();

            return items;
        }

    }
}
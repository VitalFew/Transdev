﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VitalFew.Transdev.Australasia.Data.Api.Adaptors;
using VitalFew.Transdev.Australasia.Data.Api.Models;
using VitalFew.Transdev.Australasia.Data.Api.Parameters;
using VitalFew.Transdev.Australasia.Data.Api.Parameters.Interfaces;
using VitalFew.Transdev.Australasia.Data.Api.Providers;
using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;

namespace VitalFew.Transdev.Australasia.Data.Api.Controllers
{

    //[Authorize]
    public class ValuesController : ApiBaseController
    {
        IDataProvider _dataProvider;

        /// <summary>
        /// Values Controller
        /// </summary>
        public ValuesController(IAuthorizationProvider authorizationProvider, IDataProvider dataProvider) : 
            base(authorizationProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// GET api/values
        /// </summary>
        /// <param name="query">string</param>
        /// <returns></returns>
        public JsonDataTable Get(string query)
        {
            try
            {
                var s = ClientId;

                ConfigurationProvider configurationProvider = new ConfigurationProvider();
                var configuration = configurationProvider.Get(HttpContext.Current.User.Identity.Name, query);

                var dataTable = _dataProvider.Execute(configuration);

                var jsonDataTable = new JsonDataTable(dataTable);
                return jsonDataTable;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

    }
}

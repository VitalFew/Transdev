﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using VitalFew.Transdev.Australasia.Data.Core.Exceptions;
using VitalFew.Transdev.Australasia.DataPublisher.Models;
using VitalFew.Transdev.Australasia.DataPublisher.Providers;
using VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract;

namespace VitalFew.Transdev.Australasia.DataPublisher.Controllers
{
    /// <summary>
    /// ValuesController Class
    /// </summary>
    public class ValuesController : ApiBaseController
    {
        /// <summary>
        ///  Instance of DataProvider
        /// </summary>
        IDataProvider _dataProvider;

        /// <summary>
        ///  Instance of ConfigurationProvider
        /// </summary>
        IConfigurationProvider _configurationProvider;

        /// <summary>
        /// Values Controller
        /// </summary>
        public ValuesController(
            IAuthorizationProvider authorizationProvider, 
            IDataProvider dataProvider,
            IConfigurationProvider configurationProvider) : 
            base(authorizationProvider)
        {
            _dataProvider = dataProvider;
            _configurationProvider = configurationProvider;
        }

        /// <summary>
        /// GET api/values
        /// </summary>
        /// <param name="query">string</param>
        /// <returns></returns>
        public async Task<JsonDataTable> Get(string query)
        {
            try
            {
                var configuration = await _configurationProvider.Get(ClientId, query);

                if (configuration != null)
                {
                    var dataTable = await _dataProvider.Execute(configuration);

                    var jsonDataTable = new JsonDataTable(dataTable);
                    return jsonDataTable;
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
            }
            catch(Exception ex)
            {
                if (ex.GetType() == typeof(AdaptorExecuteException))
                {
                    throw new HttpResponseException(HttpStatusCode.NoContent);
                }

                if ((ex.GetType() == typeof(HttpResponseException)) &&
                    (((HttpResponseException)ex).Response.StatusCode == HttpStatusCode.BadRequest))
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
                
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

    }
}

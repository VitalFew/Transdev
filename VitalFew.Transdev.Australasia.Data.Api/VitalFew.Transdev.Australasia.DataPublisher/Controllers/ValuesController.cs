using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VitalFew.Transdev.Australasia.DataPublisher.Models;
using VitalFew.Transdev.Australasia.DataPublisher.Providers;
using VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract;

namespace VitalFew.Transdev.Australasia.DataPublisher.Controllers
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
                ConfigurationProvider configurationProvider = new ConfigurationProvider();
                var configuration = configurationProvider.Get(ClientId, query);

                var dataTable = _dataProvider.Execute(configuration);

                var jsonDataTable = new JsonDataTable(dataTable);
                return jsonDataTable;
            }
            catch(Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

    }
}

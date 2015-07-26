using Newtonsoft.Json;
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
using VitalFew.Transdev.Australasia.DataPublisher.Models;
using VitalFew.Transdev.Australasia.DataPublisher.Providers;
using VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract;

namespace VitalFew.Transdev.Australasia.DataPublisher.Controllers
{

    //[Authorize]
    public class ValuesController : ApiBaseController
    {
        IDataProvider _dataProvider;
        IConfigurationProvider _configurationProvider;

        /// <summary>
        /// Values Controller
        /// </summary>
        public ValuesController(IAuthorizationProvider authorizationProvider, IDataProvider dataProvider,
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
        public JsonDataTable Get(string query)
        {
            try
            {
                var configuration = _configurationProvider.Get(ClientId, query);

                if (configuration != null)
                {
                    var dataTable = _dataProvider.Execute(configuration);

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
                if (((HttpResponseException)ex).Response.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }

                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

    }
}

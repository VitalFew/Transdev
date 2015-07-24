using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VitalFew.Transdev.Australasia.Data.Api.Models;
using VitalFew.Transdev.Australasia.Data.Api.Providers;
using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;

namespace VitalFew.Transdev.Australasia.Data.Api.Controllers
{

    //[Authorize]
    public class ValuesController : ApiController
    {
        IDataProvider _dataProvider;

        /// <summary>
        /// Values Controller
        /// </summary>
        public ValuesController(IDataProvider dataProvider)
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
                var dataTable = _dataProvider.Execute(1, query);
                dataTable.TableName = query;

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

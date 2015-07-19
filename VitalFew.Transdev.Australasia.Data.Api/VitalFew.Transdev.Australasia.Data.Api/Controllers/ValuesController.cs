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
        /// <summary>
        /// Values Controller
        /// </summary>
        public ValuesController()
        {
            
        }

        // GET api/values
        public JsonDataTable Get(string query)
        {
            IDataProvider dataProvider = new DataProvider();
            var dataTable = dataProvider.Execute(1, query);
            dataTable.TableName = query;

            var jsonDataTable = new JsonDataTable(dataTable);
            return jsonDataTable;
        }

    }
}

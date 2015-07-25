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
    public class ApiBaseController : ApiController
    {

        IAuthorizationProvider _authorizationProvider;

        /// <summary>
        /// Values Controller
        /// </summary>
        public ApiBaseController(IAuthorizationProvider authorizationProvider)
        {
            _authorizationProvider = authorizationProvider;
        }

        public string ClientId
        {
            get
            {
                var s = _authorizationProvider.Claim;
                return s.Value;
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract;

namespace VitalFew.Transdev.Australasia.DataPublisher.Controllers
{
    /// <summary>
    /// ApiBaseController Class
    /// </summary>
    public class ApiBaseController : ApiController
    {

        /// <summary>
        /// Instance of AuthorizationProvider
        /// </summary>
        IAuthorizationProvider _authorizationProvider;

        /// <summary>
        /// Api Base Controller Controller
        /// </summary>
        public ApiBaseController(IAuthorizationProvider authorizationProvider)
        {
            _authorizationProvider = authorizationProvider;
        }

        /// <summary>
        /// Client Id
        /// </summary>
        public Guid ClientId
        {
            get
            {
                var s = _authorizationProvider.Claim;
                return Guid.Parse(s.Value);
            }
        }
    }
}

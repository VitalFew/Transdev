using System;
using System.Web.Http;

using VitalFew.Transdev.Australasia.Data.Core.Providers.Contract;

namespace VitalFew.Transdev.Australasia.Data.Api.Controllers
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

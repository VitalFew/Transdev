using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using VitalFew.Transdev.Australasia.Data.Api.Providers;

namespace VitalFew.Transdev.Australasia.Data.Api.Infrastructure.Headers
{

    /// <summary>
    /// Authorization Message Handler
    /// </summary>
    public class AuthMessageHandler : DelegatingHandler
    {

        private const string clientIdHeader = "clientid";
        private const string clientTokenHeader = "clienttoken";

        /// <summary>
        /// SendAsync
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            IEnumerable<string> clientIdValues;
            IEnumerable<string> clientTokenValues;
            HttpStatusCode responseCode = HttpStatusCode.OK;

            var hasClientId = request.Headers.TryGetValues(clientIdHeader, out clientIdValues);
            var hasClientToken = request.Headers.TryGetValues(clientTokenHeader, out clientTokenValues);

            ClaimsIdentity identity = null;

            if (hasClientId && hasClientToken)
            {
                identity = new AuthorizationProvider().ValidateAuthentication(clientIdValues.FirstOrDefault(), clientTokenValues.FirstOrDefault());

                if (identity != null) //Valid User
                {
                    System.Threading.Thread.CurrentPrincipal = new ClaimsPrincipal(identity);
                }
                else //User failed to authenticate
                    responseCode = HttpStatusCode.Unauthorized;
            }
            else //User didn't supply Key/Token
                responseCode = HttpStatusCode.Forbidden;


            return base.SendAsync(request, cancellationToken)
                .ContinueWith(task =>
                {
                    var response = task.Result;
                    if (responseCode == HttpStatusCode.OK)
                        return response;
                    else
                        return request.CreateResponse(responseCode);
                });
        }
    }
}
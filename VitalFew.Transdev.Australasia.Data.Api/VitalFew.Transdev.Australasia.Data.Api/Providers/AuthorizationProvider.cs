﻿using System;
using System.Data;
using System.Linq;
using System.Security.Claims;
using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;

using VitalFew.Transdev.Australasia.Data.Core.Database;

namespace VitalFew.Transdev.Australasia.Data.Api.Providers
{
    public class AuthorizationProvider : IAuthorizationProvider
    {
        
        /// <summary>
        /// Instance of System.Security.Claims
        /// </summary>
        public Claim Claim
        {
            get
            {
                var claimsPrincipal = System.Threading.Thread.CurrentPrincipal as System.Security.Claims.ClaimsPrincipal;
                return claimsPrincipal.Claims.Where(e => e.Type == "Client-Name").FirstOrDefault();
            }
        }

        /// <summary>
        /// Get API Claims Identity
        /// </summary>
        /// <param name="clientId">string</param>
        /// <param name="clientToken">string</param>
        /// <returns>ClaimsIdentity</returns>
        public ClaimsIdentity ValidateAuthentication(string clientName, string clientToken)
        {
            //Check your api key and secret here
            var clientId = Authorize(clientName, clientToken);

            if (clientId != null)
            {
                var identity = new ClaimsIdentity("Client-Token");
                identity.AddClaim(new Claim("Client-Name", clientId.ToString(), null));
                return identity;
            }

            return null;
        }

        /// <summary>
        /// Authorize
        /// </summary>
        /// <param name="clientName">string</param>
        /// <param name="clientToken">string</param>
        /// <returns></returns>
        private Guid? Authorize(string clientName, string clientToken)
        {
            using (var context = new Entities())
            {
                var client = context.VF_API_CATALOG_CLIENTS.Where(e => e.CLIENT_NAME == clientName
                    && e.CLIENT_TOKEN == clientToken
                    && e.CLIENT_STATUS == true).FirstOrDefault();

                if (client != null)
                {
                    return client.CLIENT_ID;
                }

                return null;
            }
        }
    }
}
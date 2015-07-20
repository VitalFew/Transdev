using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;

namespace VitalFew.Transdev.Australasia.Data.Api.Providers
{
    public class AuthorizationProvider : IAuthorizationProvider
    {
        public bool Authorize(string clientName, string clientToken)
        {
            using (var context = new Models.Database.Entities())
            {
                var client = context.VF_API_CATALOG_CLIENTS.Where(e => e.CLIENT_NAME == clientName
                    && e.CLIENT_TOKEN == clientToken
                    && e.CLIENT_STATUS == true).FirstOrDefault();

                if (client != null)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
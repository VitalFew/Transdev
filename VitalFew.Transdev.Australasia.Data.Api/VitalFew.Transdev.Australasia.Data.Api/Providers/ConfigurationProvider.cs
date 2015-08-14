using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;
using VitalFew.Transdev.Australasia.Data.Core.Database;

namespace VitalFew.Transdev.Australasia.Data.Api.Providers
{
    public class ConfigurationProvider : IConfigurationProvider
    {

        /// <summary>
        /// Get Configuration
        /// </summary>
        /// <param name="clientId">Guid</param>
        /// <param name="param">string</param>
        /// <returns>VF_API_CLIENT_OBJECTS</returns>
        public async Task<VF_API_CLIENT_OBJECTS> Get(Guid clientId, string parama)
        {
            using (var context = new Entities())
            {
                return context.VF_API_CLIENT_OBJECTS.Where(e => 
                        e.VF_API_CATALOG_CLIENTS.CLIENT_ID == clientId &&
                        e.TRANSDEV_PARAM == parama).FirstOrDefault();
            }
        }
    }

}
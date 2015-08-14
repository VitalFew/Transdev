using System;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Core.Database;

namespace VitalFew.Transdev.Australasia.Data.Api.Providers.Contract
{
    public interface IConfigurationProvider
    {

        /// <summary>
        /// Get Configuration
        /// </summary>
        /// <param name="clientId">Guid</param>
        /// <param name="param">string</param>
        /// <returns>VF_API_CLIENT_OBJECTS</returns>
        Task<VF_API_CLIENT_OBJECTS> Get(Guid clientId, string param);
    }
}

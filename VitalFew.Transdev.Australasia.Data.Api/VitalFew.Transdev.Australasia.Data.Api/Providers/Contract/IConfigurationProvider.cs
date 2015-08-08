using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Api.Models;

namespace VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract
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

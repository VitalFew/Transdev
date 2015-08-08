using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace VitalFew.Transdev.Australasia.Data.Api.Providers.Contract
{
    public interface IAuthorizationProvider
    {
        /// <summary>
        /// Instance of System.Security.Claims
        /// </summary>
        Claim Claim { get; }

        /// <summary>
        /// Get API Claims Identity
        /// </summary>
        /// <param name="clientId">string</param>
        /// <param name="clientToken">string</param>
        /// <returns>ClaimsIdentity</returns>
        ClaimsIdentity ValidateAuthentication(string clientId, string clientToken);
    }
}

using System.Security.Claims;

namespace VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract
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

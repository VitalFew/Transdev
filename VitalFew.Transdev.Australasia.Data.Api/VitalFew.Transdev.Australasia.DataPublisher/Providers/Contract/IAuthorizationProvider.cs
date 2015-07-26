using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract
{
    public interface IAuthorizationProvider
    {
        Claim Claim { get; }

        ClaimsIdentity ValidateAuthentication(string clientId, string clientToken);
    }
}

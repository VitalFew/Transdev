using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalFew.Transdev.Australasia.Data.Api.Providers.Contract
{
    public interface IAuthorizationProvider
    {
        bool Authorize(string clientId, string clientToken);
    }
}

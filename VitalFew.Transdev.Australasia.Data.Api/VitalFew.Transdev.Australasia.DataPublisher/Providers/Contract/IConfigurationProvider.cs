using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.DataPublisher.Models.Database;

namespace VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract
{
    public interface IConfigurationProvider
    {
        VF_API_CLIENT_OBJECTS Get(string transdevId, string transdevParam);
    }
}

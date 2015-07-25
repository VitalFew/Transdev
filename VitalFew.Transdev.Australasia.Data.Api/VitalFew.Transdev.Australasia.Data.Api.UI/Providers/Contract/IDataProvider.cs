using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Api.Models.Database;

namespace VitalFew.Transdev.Australasia.Data.Api.Providers.Contract
{
    public interface IDataProvider
    {
        DataTable Execute(VF_API_CLIENT_OBJECTS clients);
    }
}

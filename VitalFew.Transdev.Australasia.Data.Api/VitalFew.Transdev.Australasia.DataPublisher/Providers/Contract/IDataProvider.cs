using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.DataPublisher.Models.Database;

namespace VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract
{
    public interface IDataProvider
    {
        DataTable Execute(VF_API_CLIENT_OBJECTS clients);
    }
}

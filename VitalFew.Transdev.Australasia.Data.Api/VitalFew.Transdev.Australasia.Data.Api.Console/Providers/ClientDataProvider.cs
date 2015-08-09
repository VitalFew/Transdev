using System.Linq;
using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;
using VitalFew.Transdev.Australasia.Data.Core.Database;

namespace VitalFew.Transdev.Australasia.Data.Api.Providers
{
    public class ClientDataProvider : IClientDataProvider
    {
        public IQueryable<VF_DATA_PROVIDER> GetAll()
        {
            var context = new Entities();
            return context.VF_DATA_PROVIDER.AsQueryable();
        }
    }
}
using System.Linq;
using VitalFew.Transdev.Australasia.Data.Api.Console.Providers.Contract;
using VitalFew.Transdev.Australasia.Data.Core.Database;

namespace VitalFew.Transdev.Australasia.Data.Api.Console.Providers
{
    public class DataProvider : IDataProvider
    {
        public IQueryable<VF_DATA_PROVIDER> GetAll()
        {
            var context = new Entities();
            return context.VF_DATA_PROVIDER.AsQueryable();
        }
    }
}
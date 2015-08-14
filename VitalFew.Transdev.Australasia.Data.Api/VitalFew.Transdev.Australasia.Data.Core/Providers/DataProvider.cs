using System.Linq;
using VitalFew.Transdev.Australasia.Data.Core.Database;
using VitalFew.Transdev.Australasia.Data.Core.Providers.Contract;

namespace VitalFew.Transdev.Australasia.Data.Core.Providers
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
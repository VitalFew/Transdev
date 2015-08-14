using System.Linq;

using VitalFew.Transdev.Australasia.Data.Core.Database;
using VitalFew.Transdev.Australasia.Data.Core.Providers.Contract;

namespace VitalFew.Transdev.Australasia.Data.Core.Providers
{
    public class LookupProvider : ILookupProvider
    {

        /// <summary>
        /// Get Providers
        /// </summary>
        /// <returns></returns>
        public IQueryable<VF_DATA_PROVIDER> GetProviders()
        {
            var context = new Entities();
            return context.VF_DATA_PROVIDER.AsQueryable();
        }
    }
}

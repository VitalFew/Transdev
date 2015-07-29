using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.DataPublisher.Models.Database;
using VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract;

namespace VitalFew.Transdev.Australasia.DataPublisher.Providers
{
    public class CatalogClientProvider : ICatalogClientProvider
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<List<VF_API_CATALOG_CLIENTS>> GetAll()
        {
            using (var context = new Entities())
            {
                return await context.VF_API_CATALOG_CLIENTS.AsQueryable().ToListAsync();
            }
        }
    }
}
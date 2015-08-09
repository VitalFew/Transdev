using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Api.Console.Providers.Contract;
using VitalFew.Transdev.Australasia.Data.Core.Database;

namespace VitalFew.Transdev.Australasia.Data.Api.Console.Providers
{
    public class CatalogClientProvider : ICatalogClientProvider
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IQueryable<VF_API_CATALOG_CLIENTS> GetAll()
        {
            var context = new Core.Database.Entities();
            
            return context.VF_API_CATALOG_CLIENTS.AsQueryable();
        }

        public async Task<int> Save(VF_API_CATALOG_CLIENTS client)
        {
            using (var context = new Core.Database.Entities())
            {
                if (client.TRANSDEV_ID == 0)
                {
                    context.Entry(client).State = EntityState.Added;
                }
                else
                {
                    context.Entry(client).State = EntityState.Modified;
                }

                return await context.SaveChangesAsync();
            }
        }
    }
}
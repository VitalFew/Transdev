using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Api.Models;
using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;

namespace VitalFew.Transdev.Australasia.Data.Api.Providers
{
    public class ClientProvider : IClientProvider
    {  /// <summary>
       /// Gets all.
       /// </summary>
       /// <returns></returns>
        public IQueryable<VF_API_CATALOG_CLIENTS> GetAll()
        {
            var context = new Entities();
            return context.VF_API_CATALOG_CLIENTS.AsQueryable();
        }

        public async Task<int> Save(VF_API_CATALOG_CLIENTS client)
        {
            using (var context = new Entities())
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
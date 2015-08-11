using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Api.Console.Providers.Contract;
using VitalFew.Transdev.Australasia.Data.Core.Database;

namespace VitalFew.Transdev.Australasia.Data.Api.Console.Providers
{
    public class ClientObjectProvider : IClientObjectProvider
    {
        public IQueryable<VF_API_CLIENT_OBJECTS> GetAll()
        {
            var context = new Entities();
            return context.VF_API_CLIENT_OBJECTS.Include(e => e.VF_API_CATALOG_CLIENTS).AsQueryable();
        }

        public async Task<int> Save(VF_API_CLIENT_OBJECTS clientObject)
        {
            using (var context = new Entities())
            {
                if (clientObject.CLIENT_OBJECT_ID == System.Guid.Empty)
                {
                    clientObject.CLIENT_OBJECT_ID = System.Guid.NewGuid();
                    context.Entry(clientObject).State = EntityState.Added;
                }
                else
                {
                    context.Entry(clientObject).State = EntityState.Modified;
                }

                return await context.SaveChangesAsync();
            }
        }
    }
}
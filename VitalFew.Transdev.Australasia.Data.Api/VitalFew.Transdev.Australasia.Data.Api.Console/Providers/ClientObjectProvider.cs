using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;
using VitalFew.Transdev.Australasia.Data.Core.Database;

namespace VitalFew.Transdev.Australasia.Data.Api.Providers
{
    public class ClientObjectProvider : IClientObjectProvider
    {
        public IQueryable<VF_API_CLIENT_OBJECTS> GetAll()
        {
            var context = new Entities();
            return context.VF_API_CLIENT_OBJECTS.AsQueryable();
        }

        public async Task<int> Save(VF_API_CLIENT_OBJECTS clientObject)
        {
            using (var context = new Entities())
            {
                if (clientObject.DB_OBJECT_CREATED_DATE.Equals(clientObject.DB_OBJECT_MODIFIED_DATE))
                {
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
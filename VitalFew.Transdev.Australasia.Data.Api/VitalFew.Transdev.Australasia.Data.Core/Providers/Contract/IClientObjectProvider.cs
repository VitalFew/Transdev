using System.Linq;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Core.Database;

namespace VitalFew.Transdev.Australasia.Data.Core.Providers.Contract
{
    public interface IClientObjectProvider
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<VF_API_CLIENT_OBJECTS> GetAll();

        /// <summary>
        /// Saves the specified client object.
        /// </summary>
        /// <param name="clientObject">The client object.</param>
        /// <returns></returns>
        Task<int> Save(VF_API_CLIENT_OBJECTS clientObject);
    }
}

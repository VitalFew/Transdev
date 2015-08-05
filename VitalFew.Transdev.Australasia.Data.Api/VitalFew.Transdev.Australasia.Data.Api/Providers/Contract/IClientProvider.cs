using System.Linq;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Api.Models;

namespace VitalFew.Transdev.Australasia.Data.Api.Providers.Contract
{
    public interface IClientProvider
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<VF_API_CATALOG_CLIENTS> GetAll();

        /// <summary>
        /// Saves the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        Task<int> Save(VF_API_CATALOG_CLIENTS client);
    }
}

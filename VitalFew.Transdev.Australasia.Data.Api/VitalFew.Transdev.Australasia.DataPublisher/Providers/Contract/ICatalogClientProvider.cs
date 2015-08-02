using System.Linq;
using VitalFew.Transdev.Australasia.DataPublisher.Models.Database;

namespace VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract
{
    public interface ICatalogClientProvider
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<VF_API_CATALOG_CLIENTS> GetAll();
    }
}

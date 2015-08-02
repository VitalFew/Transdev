using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.DataPublisher.Models;
using VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract;
using VitalFew.Transdev.Australasia.DataPublisher.Common;
using System.Collections.Generic;
using System.Web.Http;
using System.Data.Entity;

namespace VitalFew.Transdev.Australasia.DataPublisher.Controllers
{
    public class CatalogController : ApiController
    {
        private readonly ICatalogClientProvider _catalogProvider;

        public CatalogController(ICatalogClientProvider catalogProvider)
        {
            _catalogProvider = catalogProvider;
        }

        /// <summary>
        /// Gets the specified catalog identifier.
        /// </summary>
        /// <param name="catalogId">The catalog identifier.</param>
        /// <returns></returns>
        public async Task<CatagoryClient> Get(int id)
        {
            var categories = await _catalogProvider.GetAll().FirstOrDefaultAsync(x => x.TRANSDEV_ID == id);

            return categories.GetClientDto();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CatagoryClient>> Get()
        {
            var categories = await _catalogProvider.GetAll().ToListAsync();

            return categories.GetClientDto();
        }
    }
}

using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.DataPublisher.Models;
using VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract;
using VitalFew.Transdev.Australasia.DataPublisher.Common;
using System.Collections.Generic;
using System.Web.Http;

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
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<List<CatagoryClient>> Get()
        {
            var categories = await _catalogProvider.GetAll();

            return categories.GetClientDto();
        }
    }
}

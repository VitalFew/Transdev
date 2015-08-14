using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.Http;
using System.Data.Entity;
using System;

using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;
using VitalFew.Transdev.Australasia.Data.Api.Models;
using VitalFew.Transdev.Australasia.Data.Api.Common;

namespace VitalFew.Transdev.Australasia.Data.Api.Controllers
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
        public async Task<CatagoryClient> Get(Guid id)
        {
            var categories = await _catalogProvider.GetAll().FirstOrDefaultAsync(x => x.CLIENT_ID.Equals(id));

            return categories.GetClientDto();
        }

        /// <summary>
        /// Puts the specified client.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> Put(CatagoryClient client)
        {
            return await _catalogProvider.Save(client.GetCatalogClient());
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

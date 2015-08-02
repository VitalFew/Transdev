using System.Collections.Generic;
using VitalFew.Transdev.Australasia.DataPublisher.Models;
using VitalFew.Transdev.Australasia.DataPublisher.Models.Database;

namespace VitalFew.Transdev.Australasia.DataPublisher.Common
{
    public static class CatalogExtensions
    {
        public static List<CatagoryClient> GetClientDto(this List<VF_API_CATALOG_CLIENTS> catalogs)
        {
            List<CatagoryClient> dtoCatalog = new List<CatagoryClient>();
            foreach (var catalog in catalogs)
            {
                dtoCatalog.Add(GetClientDto(catalog));
            }

            return dtoCatalog;
        }

        /// <summary>
        /// Gets the client dto.
        /// </summary>
        /// <param name="catalog">The catalog.</param>
        /// <returns></returns>
        public static CatagoryClient GetClientDto(this VF_API_CATALOG_CLIENTS catalog)
        {
            CatagoryClient dtoCatalog = new CatagoryClient
            {
                Id = catalog.TRANSDEV_ID,
                ClientId = catalog.CLIENT_ID,
                ClientName = catalog.CLIENT_NAME,
                ClientStatus = (catalog.CLIENT_STATUS.HasValue ? (catalog.CLIENT_STATUS.Value ? "Active" : "In-active") : "In-active"),
                ClientToken = catalog.CLIENT_TOKEN
            };

            return dtoCatalog;
        }
        public static VF_API_CATALOG_CLIENTS GetCatalogClient(this CatagoryClient catalogdto)
        {
            return new VF_API_CATALOG_CLIENTS
            {
                CLIENT_NAME= catalogdto.ClientName,
                CLIENT_ID= catalogdto.ClientId,
                CLIENT_STATUS= catalogdto.ClientStatus.ToLower().Equals("active")? true :false,
                CLIENT_TOKEN= catalogdto.ClientToken,
                TRANSDEV_ID= catalogdto.Id
            };
        }
    }
}
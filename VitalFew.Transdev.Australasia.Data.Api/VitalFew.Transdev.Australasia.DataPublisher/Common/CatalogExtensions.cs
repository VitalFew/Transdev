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
                dtoCatalog.Add(new CatagoryClient
                {
                    ClientId = catalog.CLIENT_ID,
                    ClientName = catalog.CLIENT_NAME,
                    ClientStatus = catalog.CLIENT_STATUS,
                    ClientToken = catalog.CLIENT_TOKEN
                });
            }

            return dtoCatalog;
        }
    }
}
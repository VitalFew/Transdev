using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using VitalFew.Transdev.Australasia.Data.Core.Adaptors;
using VitalFew.Transdev.Australasia.Data.Core.Parameters;
using VitalFew.Transdev.Australasia.DataPublisher.Models.Database;
using VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract;

namespace VitalFew.Transdev.Australasia.DataPublisher.Providers
{
    public class DataProvider : IDataProvider
    {
        public DataTable Execute(VF_API_CLIENT_OBJECTS client)
        {
            using (var context = new Models.Database.Entities())
            {
                Adaptor adaptor = new BaseAdaptor();

                var parameters = new SqlServerTableParameters();
                parameters.UserID = client.DB_USER;
                parameters.Password = client.DB_USER_PASSWORD;
                parameters.DataSource = client.DB_SERVER_NAME;
                parameters.InitialCatalog = client.DB_NAME;
                parameters.IntegratedSecurity = client.DB_INTEGRATED_SECURITY;
 
                adaptor.Processor = new SqlServerTableAdaptor();
                return adaptor.Execute(parameters);
            }
        }
    }
}
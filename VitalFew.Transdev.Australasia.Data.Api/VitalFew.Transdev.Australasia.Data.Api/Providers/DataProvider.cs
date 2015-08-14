using System.Data;
using System.Threading.Tasks;

using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;
using VitalFew.Transdev.Australasia.Data.Core.Adaptors;
using VitalFew.Transdev.Australasia.Data.Core.Database;
using VitalFew.Transdev.Australasia.Data.Core.Parameters;
using VitalFew.Transdev.Australasia.Data.Core.Result;


namespace VitalFew.Transdev.Australasia.Data.Api.Providers
{
    public class DataProvider : IDataProvider
    {

        /// <summary>
        /// Execute DataProvide
        /// </summary>
        /// <param name="clients">VF_API_CLIENT_OBJECTS</param>
        /// <returns>QueryResult of DataTable</returns>
        public async Task<QueryResult<DataTable>> Execute(VF_API_CLIENT_OBJECTS client)
        {
            using (var context = new Entities())
            {
                var adaptor = new SqlServerTableAdaptor();

                var parameters = new SqlServerTableParameters();
                parameters.UserID = client.DB_USER;
                parameters.Password = client.DB_USER_PASSWORD;
                parameters.DataSource = client.DB_SERVER_NAME;
                parameters.InitialCatalog = client.DB_NAME;
                parameters.IntegratedSecurity = client.DB_INTEGRATED_SECURITY;
                parameters.ObjectName = client.DB_OBJECT_NAME;
                parameters.SchemaName = client.DB_SCHEMA;

                return adaptor.Execute(parameters);
            }
        }
    }
}
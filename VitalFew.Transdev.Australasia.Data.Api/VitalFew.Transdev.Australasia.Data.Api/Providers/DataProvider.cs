using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using VitalFew.Transdev.Australasia.Data.Api.Providers.Contract;

namespace VitalFew.Transdev.Australasia.Data.Api.Providers
{
    public class DataProvider : IDataProvider
    {
        string _queryTemplate = "SELECT * FROM {0}.{1}";

        public DataTable Execute(int transdevId, string transdevParam)
        {
            using (var context = new Models.Database.Entities())
            {
                var clientObject = context.VF_API_CLIENT_OBJECTS.Where(e => e.TRANSDEV_ID == transdevId
                && e.TRANSDEV_PARAM == transdevParam).FirstOrDefault();

               if (clientObject != null)
               {
                    var sqlConnection = new SqlConnection();

                    var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
                    sqlConnectionStringBuilder.UserID = clientObject.DB_USER;
                    sqlConnectionStringBuilder.Password = clientObject.DB_USER_PASSWORD;
                    sqlConnectionStringBuilder.InitialCatalog = clientObject.DB_NAME;
                    sqlConnectionStringBuilder.DataSource = clientObject.DB_SERVER_NAME;

                    if (clientObject.DB_INTEGRATED_SECURITY.HasValue)
                    {
                        sqlConnectionStringBuilder.IntegratedSecurity = clientObject.DB_INTEGRATED_SECURITY.Value;
                    }

                    sqlConnection.ConnectionString = sqlConnectionStringBuilder.ConnectionString;

                    string query = string.Format(_queryTemplate, clientObject.DB_SCHEMA, clientObject.DB_OBJECT_NAME);

                    using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                    {
                        sqlConnection.Open();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(cmd.ExecuteReader());
                        return dataTable;
                    }
                }
            }

            return null;       
        }
        
    }

}
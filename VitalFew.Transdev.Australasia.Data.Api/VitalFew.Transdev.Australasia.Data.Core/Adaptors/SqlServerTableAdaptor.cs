using System.Data;
using System.Data.SqlClient;
using VitalFew.Transdev.Australasia.Data.Core.Exceptions;
using VitalFew.Transdev.Australasia.Data.Core.Parameters;
using VitalFew.Transdev.Australasia.Data.Core.Parameters.Interfaces;
using VitalFew.Transdev.Australasia.Data.Core.Result;

namespace VitalFew.Transdev.Australasia.Data.Core.Adaptors
{
    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class SqlServerTableAdaptor : Adaptor<ISqlServerTableParameters> 
    {

        string _queryTemplate = "SELECT * FROM {0}.{1};";

        public override QueryResult<DataTable> Execute(ISqlServerTableParameters parameters)
        {
            try
            {
                var sqlConnection = new SqlConnection();

                var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
                sqlConnectionStringBuilder.UserID = parameters.UserID;
                sqlConnectionStringBuilder.Password = parameters.Password;
                sqlConnectionStringBuilder.InitialCatalog = parameters.InitialCatalog;
                sqlConnectionStringBuilder.DataSource = parameters.DataSource;

                if (((SqlServerTableParameters)parameters).IntegratedSecurity.HasValue)
                {
                    sqlConnectionStringBuilder.IntegratedSecurity = parameters.IntegratedSecurity.Value;
                }

                sqlConnection.ConnectionString = sqlConnectionStringBuilder.ConnectionString;

                string query = string.Format(_queryTemplate, parameters.SchemaName,
                    parameters.ObjectName);

                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(cmd.ExecuteReader());

                    dataTable.TableName = ((SqlServerTableParameters)parameters).ObjectName;

                    var queryResult = new QueryResult<DataTable>();

                    queryResult.Result = dataTable;
                    queryResult.RecordCount = dataTable.Rows.Count;

                    return queryResult;
                }
            }
            catch
            {
                throw new AdaptorExecuteException();
            }

            return null;
        }
    }
}

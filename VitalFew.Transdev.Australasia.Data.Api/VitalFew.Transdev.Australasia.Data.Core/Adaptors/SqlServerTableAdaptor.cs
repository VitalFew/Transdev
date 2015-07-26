using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Core.Parameters;
using VitalFew.Transdev.Australasia.Data.Core.Parameters.Interfaces;
using VitalFew.Transdev.Australasia.Data.Core.Processor;
using VitalFew.Transdev.Australasia.Data.Core.Result;

namespace VitalFew.Transdev.Australasia.Data.Core.Adaptors
{
    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class SqlServerTableAdaptor : IProcessor
    {

        string _queryTemplate = "SELECT * FROM {0}.{1};";

        public override QueryResult<DataTable> Execute(IParameters parameters)
        {
            var sqlConnection = new SqlConnection();
            
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.UserID = ((SqlServerTableParameters)parameters).UserID;
            sqlConnectionStringBuilder.Password = ((SqlServerTableParameters)parameters).Password;
            sqlConnectionStringBuilder.InitialCatalog = ((SqlServerTableParameters)parameters).InitialCatalog;
            sqlConnectionStringBuilder.DataSource = ((SqlServerTableParameters)parameters).DataSource;

            if (((SqlServerTableParameters)parameters).IntegratedSecurity.HasValue)
            {
                sqlConnectionStringBuilder.IntegratedSecurity = ((SqlServerTableParameters)parameters).IntegratedSecurity.Value;
            }

            sqlConnection.ConnectionString = sqlConnectionStringBuilder.ConnectionString;

            string query = string.Format(_queryTemplate, ((SqlServerTableParameters)parameters).SchemaName, 
                ((SqlServerTableParameters)parameters).ObjectName);

            using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                DataTable dataTable = new DataTable();
                dataTable.Load(cmd.ExecuteReader());

                dataTable.TableName = ((SqlServerTableParameters)parameters).ObjectName;

                var obj = new QueryResult<DataTable>();

                obj.Result = dataTable;
                obj.RecordCount = dataTable.Rows.Count;

                return obj;
            }
        }
    }
}

using System.Data;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Core.Database;
using VitalFew.Transdev.Australasia.Data.Core.Result;

namespace VitalFew.Transdev.Australasia.DataPublisher.Providers.Contract
{
    public interface IDataProvider
    {

        /// <summary>
        /// Execute DataProvide
        /// </summary>
        /// <param name="clients">VF_API_CLIENT_OBJECTS</param>
        /// <returns>QueryResult of DataTable</returns>
        Task<QueryResult<DataTable>> Execute(VF_API_CLIENT_OBJECTS clients);
    }
}

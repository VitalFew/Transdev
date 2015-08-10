using System.Linq;
using VitalFew.Transdev.Australasia.Data.Core.Database;

namespace VitalFew.Transdev.Australasia.Data.Api.Console.Providers.Contract
{
    public interface IDataProvider
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<VF_DATA_PROVIDER> GetAll();
    }
}

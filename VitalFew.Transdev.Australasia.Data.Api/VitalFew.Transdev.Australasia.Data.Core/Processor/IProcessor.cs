using System.Data;
using VitalFew.Transdev.Australasia.Data.Core.Parameters.Interfaces;
using VitalFew.Transdev.Australasia.Data.Core.Result;

namespace VitalFew.Transdev.Australasia.Data.Core.Processor
{
    /// <summary>
    /// The 'Implementor' abstract class
    /// </summary>
    public abstract class IProcessor<T> where T : IParameters
    {
        public abstract QueryResult<DataTable> Execute(T parameters);
    }
}

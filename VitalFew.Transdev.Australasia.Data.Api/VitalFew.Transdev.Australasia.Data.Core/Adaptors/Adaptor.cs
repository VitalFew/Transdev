using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Core.Parameters.Interfaces;
using VitalFew.Transdev.Australasia.Data.Core.Processor;
using VitalFew.Transdev.Australasia.Data.Core.Result;

namespace VitalFew.Transdev.Australasia.Data.Core.Adaptors
{
    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    public class Adaptor<T> where T : IParameters
    {
        protected IProcessor<T> processor;

        public IProcessor<T> Processor
        {
            set { processor = value; }
        }

        public virtual QueryResult<DataTable> Execute(T parameters)
        {
            return processor.Execute(parameters);
        }
    }
}

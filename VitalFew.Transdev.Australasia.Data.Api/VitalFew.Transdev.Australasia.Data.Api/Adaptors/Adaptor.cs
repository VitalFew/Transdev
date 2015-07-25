using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Api.Parameters;
using VitalFew.Transdev.Australasia.Data.Api.Parameters.Interfaces;
using VitalFew.Transdev.Australasia.Data.Api.Processor;

namespace VitalFew.Transdev.Australasia.Data.Api.Adaptors
{
    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    public class Adaptor
    {
        protected IProcessor processor;

        public IProcessor Processor
        {
            set { processor = value; }
        }

        public virtual DataTable Execute(IParameters parameters)
        {
            return processor.Execute(parameters);
        }
    }
}

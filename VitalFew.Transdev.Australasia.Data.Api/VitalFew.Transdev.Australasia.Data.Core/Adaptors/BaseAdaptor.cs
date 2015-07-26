using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Core.Parameters.Interfaces;
using VitalFew.Transdev.Australasia.Data.Core.Result;

namespace VitalFew.Transdev.Australasia.Data.Core.Adaptors
{
    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class BaseAdaptor : Adaptor
    {
        public override QueryResult<DataTable> Execute(IParameters parameters)
        {
            return processor.Execute(parameters);
        }
    }
}

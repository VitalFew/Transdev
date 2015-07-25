using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Api.Adaptors;
using VitalFew.Transdev.Australasia.Data.Api.Parameters;
using VitalFew.Transdev.Australasia.Data.Api.Parameters.Interfaces;

namespace VitalFew.Transdev.Australasia.Data.Api
{
    /// <summary>
    /// The 'RefinedAbstraction' class
    /// </summary>
    public class BaseAdaptor : Adaptor
    {
        public override DataTable Execute(IParameters parameters)
        {
            return processor.Execute(parameters);
        }
    }
}

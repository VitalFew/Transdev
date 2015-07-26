using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VitalFew.Transdev.Australasia.Data.Core.Parameters.Interfaces;

namespace VitalFew.Transdev.Australasia.Data.Core.Processor
{
    /// <summary>
    /// The 'Implementor' abstract class
    /// </summary>
    public abstract class IProcessor
    {
        public abstract DataTable Execute(IParameters parameters);
    }
}

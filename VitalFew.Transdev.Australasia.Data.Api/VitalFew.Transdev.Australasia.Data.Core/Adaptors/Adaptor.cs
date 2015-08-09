using VitalFew.Transdev.Australasia.Data.Core.Parameters.Interfaces;
using VitalFew.Transdev.Australasia.Data.Core.Processor;

namespace VitalFew.Transdev.Australasia.Data.Core.Adaptors
{
    /// <summary>
    /// The 'Abstraction' class
    /// </summary>
    public abstract class Adaptor<T> : IProcessor<T> where T : IParameters
    {
        
    }
}

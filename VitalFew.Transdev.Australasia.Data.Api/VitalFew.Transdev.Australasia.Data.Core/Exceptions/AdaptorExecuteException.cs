using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VitalFew.Transdev.Australasia.Data.Core.Exceptions
{

    /// <summary>
    /// AdaptorExecuteException Class
    /// </summary>
    public class AdaptorExecuteException : Exception, ISerializable
    {
        public AdaptorExecuteException()
        {
        }

        public AdaptorExecuteException(string message)
        : base(message)
        {
        }

        public AdaptorExecuteException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
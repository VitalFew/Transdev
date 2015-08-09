using System;
using System.Runtime.Serialization;

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
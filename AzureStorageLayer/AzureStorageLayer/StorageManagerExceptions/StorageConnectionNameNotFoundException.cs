using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.StorageManagerExceptions
{
    class StorageConnectionNameNotFoundException : Exception
    {
        /// <summary>
        /// default constructor.
        /// </summary>
        public StorageConnectionNameNotFoundException()
            : base("Storage Connection Name Not Found. Please Check Web.config or App.config")
        { }
        /// <summary>
        /// sets the message and innerException to base class Exception.
        /// </summary>
        /// <param name="message">error message that you want to set.</param>
        /// <param name="innerException">innerException object.</param>
        public StorageConnectionNameNotFoundException(string message, Exception innerException)
                    : base(message, innerException)
        { }
        /// <summary>
        /// sets the default message with innerexception.
        /// </summary>
        /// <param name="innerException">innerException object</param>
        public StorageConnectionNameNotFoundException(Exception innerException)
                  : base("Storage Connection Name Not Found. Please Check Web.config or App.config", innerException)
        { }
        /// <summary>
        /// sets the message to base class exception.
        /// </summary>
        /// <param name="message">exception message</param>
        public StorageConnectionNameNotFoundException(string message)
            : base(message)
        { }
    }
}

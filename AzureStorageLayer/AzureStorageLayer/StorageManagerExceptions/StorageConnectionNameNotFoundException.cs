using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.StorageManagerExceptions
{
    class StorageConnectionNameNotFoundException : Exception
    {
        public StorageConnectionNameNotFoundException()
            : base("Storage Connection Name Not Found. Please Check Web.config or App.config")
        { }
        public StorageConnectionNameNotFoundException(string message, Exception internalException)
                    : base(message, internalException)
        { }

        public StorageConnectionNameNotFoundException(Exception internalException)
                  : base("Storage Connection Name Not Found. Please Check Web.config or App.config", internalException)
        { }

        public StorageConnectionNameNotFoundException(string message)
            : base(message)
        { }
    }
}

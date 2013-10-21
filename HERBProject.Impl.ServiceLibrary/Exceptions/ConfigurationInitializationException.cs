using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HERBProject.Impl.ServiceLibrary.Exceptions
{
    [Serializable]
    public class ConfigurationInitializationException : ApplicationException
    {

        public ConfigurationInitializationException()
        {

        }
        public ConfigurationInitializationException(string message)
            : base(message)
        {

        }
        public ConfigurationInitializationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HERBProject.WebUI.Exceptions
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
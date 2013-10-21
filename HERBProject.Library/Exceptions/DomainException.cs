using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HERBProject.Library.Exceptions
{
    [Serializable]
    public class DomainException : ApplicationException
    {

        public DomainException()
        {

        }
        public DomainException(string message)
            : base(message)
        {

        }
        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HERBProject.DB.Infrastructure.Exceptions
{
    [Serializable]
    public class InputEntityDBModelAlreadyExistingOnDatabaseException : ApplicationException
    {

        public InputEntityDBModelAlreadyExistingOnDatabaseException()
        {

        }
        public InputEntityDBModelAlreadyExistingOnDatabaseException(string message)
            : base(message)
        {

        }
        public InputEntityDBModelAlreadyExistingOnDatabaseException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

    }
}

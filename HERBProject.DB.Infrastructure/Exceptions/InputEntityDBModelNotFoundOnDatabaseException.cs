using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HERBProject.DB.Infrastructure.Exceptions
{
    [Serializable]
    public class InputEntityDBModelNotFoundOnDatabaseException : ApplicationException
    {

        public InputEntityDBModelNotFoundOnDatabaseException()
        {

        }
        public InputEntityDBModelNotFoundOnDatabaseException(string message)
            : base(message)
        {

        }
        public InputEntityDBModelNotFoundOnDatabaseException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

    }
}

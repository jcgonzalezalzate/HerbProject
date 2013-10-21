using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace HERBProject.DB.Infrastructure.Repositories
{
    public class ContextBase
    {

        protected ObjectContext _context;

        public ObjectContext Context
        {
            get
            {
                return _context;
            }
        }

    }
}

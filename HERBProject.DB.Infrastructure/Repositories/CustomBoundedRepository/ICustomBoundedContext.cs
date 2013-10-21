using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace HERBProject.DB.Infrastructure.Repositories.CustomBoundedRepository
{
    public interface ICustomBoundedContext
    {
        ObjectContext Context { get; }
    }
}

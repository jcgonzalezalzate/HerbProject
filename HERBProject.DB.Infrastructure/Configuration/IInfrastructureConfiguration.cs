using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HERBProject.DB.Infrastructure.Configuration
{
    public interface IInfrastructureConfiguration
    {

        int DatabaseTimeout { get; set; }
        string ConnectionString { get; set; }

    }
}

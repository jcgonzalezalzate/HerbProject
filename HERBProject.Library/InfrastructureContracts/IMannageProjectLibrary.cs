using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HERBProject.Library.Entities;

namespace HERBProject.Library.InfrastructureContracts
{
    public interface IMannageProjectLibrary
    {
        int Create(ProjectEntity project);
    }
}

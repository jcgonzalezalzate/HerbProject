using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HERBProject.Contracts.ServiceLibrary.DTO;

namespace HERBProject.Contracts.ServiceLibrary.Contracts
{
    public interface IMannageUser
    {
        int Create(UserEntityDTO user);
    }
}

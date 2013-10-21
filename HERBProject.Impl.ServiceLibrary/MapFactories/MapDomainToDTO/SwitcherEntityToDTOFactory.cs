using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Vueling.XXX.ServiceLibrary.UnitTest")]
namespace HERBProject.Impl.ServiceLibrary.MapFactories.MapDomainToDTO
{
    internal class SwitcherEntityToDTOFactory
    {
        internal static MapDomainToDTOFactoryBase GetFactoryFor(EnumDTO model)
        {
            switch (model)
            {
                case EnumDTO.User:
                    return new UserEntityToUserDTOFactory();              
                default:
                    throw new NotImplementedException(string.Format("The factory for type {0} is not implemented.", model));
            }
        }
    }
}

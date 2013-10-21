using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Vueling.XXX.ServiceLibrary.UnitTest")]
namespace HERBProject.Impl.ServiceLibrary.MapFactories.MapDTOToDomain
{
    internal class SwitcherDTOToEntityFactory
    {
        internal static MapDTOToDomainFactoryBase GetFactoryFor(EnumDomain model)
        {
            switch (model)
            {
                case EnumDomain.UserDTO:
                    return new UserDTOToUserEntityFactory();
                default:
                    throw new NotImplementedException(string.Format("The factory for type {0} is not implemented.", model));
            }
        }
    }
}

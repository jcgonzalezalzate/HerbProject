using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

[assembly: InternalsVisibleTo("HERBProject.WebUI.UnitTest")]
[assembly: InternalsVisibleTo("HERBProject.WebUI.IntegrationTest")]
namespace HERBProject.WebUI.MapFactories.DataModelToApplicationDTO
{
    internal class SwictherDataModelToApplicationDTO
    {

        internal static MapDataModelToApplicationDTOFactoryBase GetFactoryFor(EnumApplicationDTO model)
        {
            switch (model)
            {
                case EnumApplicationDTO.InputEntityDTO:
                    return new InputDataModelToInputEntityDTO();
                default:
                    throw new NotImplementedException(string.Format("The factory for type {0} is not implemented.", model));
            }
        }

    }
}
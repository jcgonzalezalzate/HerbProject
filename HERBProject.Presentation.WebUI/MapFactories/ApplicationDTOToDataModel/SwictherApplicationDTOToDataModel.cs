using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

[assembly: InternalsVisibleTo("HERBProject.WebUI.UnitTest")]
[assembly: InternalsVisibleTo("HERBProject.WebUI.IntegrationTest")]
namespace HERBProject.Presentation.WebUI.MapFactories.ApplicationDTOToDataModel
{
    internal class SwictherApplicationDTOToDataModel
    {

        internal static MapApplicationDTOToDataModelFactoryBase GetFactoryFor(EnumDataModel model)
        {
            switch (model)
            {
                case EnumDataModel.UserEntityDTO:
                    return new UserEntityDTOToUserDataModel();
                default:
                    throw new NotImplementedException(string.Format("The factory for type {0} is not implemented.", model));
            }
        }

    }
}
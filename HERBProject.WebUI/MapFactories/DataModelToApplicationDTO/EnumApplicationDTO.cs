using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

[assembly: InternalsVisibleTo("HERBProject.WebUI.UnitTest")]
[assembly: InternalsVisibleTo("HERBProject.WebUI.IntegrationTest")]
namespace HERBProject.WebUI.MapFactories.DataModelToApplicationDTO
{
    internal enum EnumApplicationDTO
    {
        InputEntityDTO = 0,
        OutputEntityDTO = 1
    }
}
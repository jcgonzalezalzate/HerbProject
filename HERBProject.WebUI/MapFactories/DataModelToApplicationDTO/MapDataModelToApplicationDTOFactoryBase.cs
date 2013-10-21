using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

[assembly: InternalsVisibleTo("HERBProject.WebUI.UnitTest")]
[assembly: InternalsVisibleTo("HERBProject.WebUI.IntegrationTest")]
namespace HERBProject.WebUI.MapFactories.DataModelToApplicationDTO
{
    internal abstract class MapDataModelToApplicationDTOFactoryBase
    {

        internal virtual IEnumerable<TOutput> GetApplicationDTOsFromDataModelDTOs<TInput, TOutput>(IEnumerable<TInput> dtos)
            where TInput : class
            where TOutput : class
        {
            if (dtos == null)
            {
                yield break;
            }

            foreach (var item in dtos)
            {
                yield return GetApplicationDTOFromDataModelDTO<TInput, TOutput>(item);
            }
        }

        internal abstract TOutput GetApplicationDTOFromDataModelDTO<TInput, TOutput>(TInput dto)
            where TInput : class
            where TOutput : class;

    }

}
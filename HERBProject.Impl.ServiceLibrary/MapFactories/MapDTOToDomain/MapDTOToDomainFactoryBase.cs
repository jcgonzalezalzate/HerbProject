using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Vueling.XXX.ServiceLibrary.UnitTest")]
namespace HERBProject.Impl.ServiceLibrary.MapFactories.MapDTOToDomain
{
    internal abstract class MapDTOToDomainFactoryBase
    {

        internal virtual IEnumerable<TOutput> GetEntitiesFromDTOs<TInput, TOutput>(IEnumerable<TInput> dtos)
            where TInput : class
            where TOutput : class
        {
            if (dtos == null)
            {
                yield break;
            }

            foreach (var item in dtos)
            {
                yield return GetEntityFromDTO<TInput, TOutput>(item);
            }
        }

        internal abstract TOutput GetEntityFromDTO<TInput, TOutput>(TInput dto)
            where TInput : class
            where TOutput : class;
    }
}

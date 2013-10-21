using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Vueling.XXX.ServiceLibrary.UnitTest")]
namespace HERBProject.Impl.ServiceLibrary.MapFactories.MapDomainToDTO
{
    internal abstract class MapDomainToDTOFactoryBase
    {
        internal virtual IEnumerable<TOutput> GetDTOFromEntities<TInput, TOutput>(IEnumerable<TInput> dtos)
            where TInput : class
            where TOutput : class
        {
            if (dtos == null)
            {
                yield break;
            }

            foreach (var item in dtos)
            {
                yield return GetDTOFromEntity<TInput, TOutput>(item);
            }
        }

        internal abstract TOutput GetDTOFromEntity<TInput, TOutput>(TInput dto)
            where TInput : class
            where TOutput : class;
    }
}

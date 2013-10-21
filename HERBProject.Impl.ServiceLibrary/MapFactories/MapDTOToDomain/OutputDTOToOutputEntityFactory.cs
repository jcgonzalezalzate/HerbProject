using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using HERBProject.Library.Entities;
using HERBProject.Contracts.ServiceLibrary.DTO;

[assembly: InternalsVisibleTo("HERBProject.Impl.ServiceLibrary.UnitTest")]
namespace HERBProject.Impl.ServiceLibrary.MapFactories.MapDTOToDomain
{
    class OutputDTOToOutputEntityFactory : MapDTOToDomainFactoryBase
    {

        internal override TOutput GetEntityFromDTO<TInput, TOutput>(TInput dto)
        {

            var outputEntityDTO = dto as OutputEntityDTO;
            if (outputEntityDTO == null) { throw new InvalidCastException("Cast to type Vueling.XXX.Contracts.ServiceLibrary has fail."); }

            var outputEntity = new OutputEntity(outputEntityDTO.OutputEntityDTOProperty);

            return (outputEntity) as TOutput;

        }

    }
}

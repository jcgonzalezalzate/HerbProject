using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using HERBProject.Library.Entities;
using HERBProject.Contracts.ServiceLibrary.DTO;

[assembly: InternalsVisibleTo("HERBProject.Impl.ServiceLibrary.UnitTest")]
namespace HERBProject.Impl.ServiceLibrary.MapFactories.MapDomainToDTO
{
    class OutputEntityToOutputDTOFactory : MapDomainToDTOFactoryBase
    {

        internal override TOutput GetDTOFromEntity<TInput, TOutput>(TInput entity)
        {

            var outputEntity = entity as OutputEntity;
            if (outputEntity == null) { throw new InvalidCastException("Cast to type Vueling.XXX.Contracts.ServiceLibrary has fail."); }

            var outputEntityDTO = new UserEntityDTO(outputEntity.OutEntityProperty);

            return (outputEntityDTO) as TOutput;

        }

    }
}

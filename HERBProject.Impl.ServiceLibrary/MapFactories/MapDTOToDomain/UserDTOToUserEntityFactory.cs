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
    class UserDTOToUserEntityFactory : MapDTOToDomainFactoryBase
    {

        internal override TOutput GetEntityFromDTO<TInput, TOutput>(TInput dto)
        {

            UserEntityDTO userEntityDTO = dto as UserEntityDTO;
            if (userEntityDTO == null) { throw new InvalidCastException("Cast to type Vueling.XXX.Contracts.ServiceLibrary has fail."); }

            UserEntity userEntity = new UserEntity();

            userEntity.Id = userEntityDTO.Id;
            userEntity.Name = userEntityDTO.Name;
            userEntity.LastName = userEntityDTO.LastName;
            userEntity.NickName = userEntityDTO.NickName;
            userEntity.Password = userEntityDTO.Password ;
            userEntity.Email = userEntityDTO.Email;

            return (userEntity) as TOutput;

        }

    }
}

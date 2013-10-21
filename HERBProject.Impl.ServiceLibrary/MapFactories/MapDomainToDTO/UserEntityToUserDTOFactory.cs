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
    class UserEntityToUserDTOFactory : MapDomainToDTOFactoryBase
    {

        internal override TOutput GetDTOFromEntity<TInput, TOutput>(TInput entity)
        {

            UserEntity userEntity = entity as UserEntity;
            if (userEntity == null) { throw new InvalidCastException("Cast to type Vueling.XXX.Contracts.ServiceLibrary has fail."); }

            UserEntityDTO userEntityDTO = new UserEntityDTO();

            userEntityDTO.Id = userEntity.Id;
            userEntityDTO.Name = userEntity.Name;
            userEntityDTO.LastName = userEntity.LastName;
            userEntityDTO.NickName = userEntity.NickName;
            userEntityDTO.Password = userEntity.Password;
            userEntityDTO.Email = userEntity.Email;

            return (userEntityDTO) as TOutput;

        }

    }
}

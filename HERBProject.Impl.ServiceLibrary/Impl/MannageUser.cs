using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HERBProject.Contracts.ServiceLibrary.Contracts;
using HERBProject.Contracts.ServiceLibrary.DTO;
using HERBProject.Library.InfrastructureContracts;
using HERBProject.Impl.ServiceLibrary.MapFactories.MapDTOToDomain;
using HERBProject.Library.Entities;

namespace HERBProject.Impl.ServiceLibrary.Impl
{
    public class MannageUser: IMannageUser
    {
        protected IMannageUserLibrary _mannageUserLibrary;

        public MannageUser(IMannageUserLibrary mannageUserLibrary)
        {
            _mannageUserLibrary = mannageUserLibrary;
        }

        public int Create(UserEntityDTO user)
        {
            if (user != null)
            {
                MapDTOToDomainFactoryBase mapFactory = SwitcherDTOToEntityFactory.GetFactoryFor(EnumDomain.UserDTO);
                UserEntity userEntity = mapFactory.GetEntityFromDTO<UserEntityDTO, UserEntity>(user);
                return _mannageUserLibrary.Create(userEntity);
                
            }
            else
            {
                return 0;
            }
           
        }
    }
}

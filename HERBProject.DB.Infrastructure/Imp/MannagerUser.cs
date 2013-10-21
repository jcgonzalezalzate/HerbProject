using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HERBProject.Library.InfrastructureContracts;
using HERBProject.DB.Infrastructure.Repositories.CustomBoundedRepository;
using HERBProject.DB.Infrastructure.Configuration;
using HERBProject.Library.Entities;
using HERBProject.DB.Infrastructure.MapFactories.MapDomainToConceptualModel;

namespace HERBProject.DB.Infrastructure.Imp
{
    public class MannagerUser: IMannageUserLibrary
    {
        private HERBProject_DataBaseEntities _repositoryEntities;
        private IInfrastructureConfiguration _configuration;

        public MannagerUser(IInfrastructureConfiguration configuration)
        {
            _configuration = configuration;
            CustomBoundedContext customBoundedContext = new CustomBoundedContext(_configuration);
            _repositoryEntities = customBoundedContext.GetEntitiesContext();
           
        }

        public int Create(UserEntity user)
        {
            MapDomainToConceptualModelFactoryBase factory = SwitcherEntityToRepositoryFactory.GetFactoryFor(typeof(UserEntity), typeof(User));
            User userDB = factory.GetDbObjectFromEntity<UserEntity, User>(user);
            using (_repositoryEntities)
            {
                _repositoryEntities.AddToUser(userDB);
                return _repositoryEntities.SaveChanges();
            }
          
        }
    }
}

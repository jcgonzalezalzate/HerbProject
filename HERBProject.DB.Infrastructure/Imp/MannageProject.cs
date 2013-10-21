using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HERBProject.Library.InfrastructureContracts;
using HERBProject.Library.Entities;
using HERBProject.DB.Infrastructure.Repositories.CustomBoundedRepository;
using HERBProject.DB.Infrastructure.Configuration;

namespace HERBProject.DB.Infrastructure.Imp
{
    public class MannageProject: IMannageProjectLibrary
    {
         private HERBProject_DataBaseEntities _repositoryEntities;
        private IInfrastructureConfiguration _configuration;

        public MannageProject(IInfrastructureConfiguration configuration)
        {
            _configuration = configuration;
            CustomBoundedContext customBoundedContext = new CustomBoundedContext(_configuration);
            _repositoryEntities = customBoundedContext.GetEntitiesContext();
           
        }


        public int Create(ProjectEntity project)
        {
            throw new NotImplementedException();
        }
    }
}

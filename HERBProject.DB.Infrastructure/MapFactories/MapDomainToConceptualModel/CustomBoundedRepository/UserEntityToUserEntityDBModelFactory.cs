using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HERBProject.Library.Entities;
using System.Runtime.CompilerServices;
using HERBProject.DB.Infrastructure.Repositories;
using HERBProject.DB.Infrastructure.Repositories.CustomBoundedRepository;

[assembly: InternalsVisibleTo("HERBProject.DB.Infrastructure.UnitTest")]
namespace HERBProject.DB.Infrastructure.MapFactories.MapDomainToConceptualModel.CustomBoundedRepository
{
    class UserEntityToUserEntityDBModelFactory : MapDomainToConceptualModelFactoryBase
    {

        internal override TOutput GetDbObjectFromEntity<TInput, TOutput>(TInput entity)
        {
            if (entity == null) { return default(TOutput); }

            UserEntity userEntity = entity as UserEntity;//if casting fail, return null, so we have to verify the result
            if (userEntity == null) { throw new InvalidCastException("Cast to type List<Seat> has fail."); }

            User userEntityDBModel = new User();
            userEntityDBModel.id_User = Guid.NewGuid();
            userEntityDBModel.name_user = userEntity.Name;
            userEntityDBModel.lastName_user = userEntity.LastName;
            userEntityDBModel.nickname_user = userEntity.NickName;
            userEntityDBModel.password_user = userEntity.Password;
            userEntityDBModel.email_user = userEntity.Email;
            //foreach (ProjectEntity project in userEntity.ProjectEntity)
            //{


            //}
            userEntityDBModel.Project.Add(new Project { id_Project = Guid.NewGuid() });
            userEntityDBModel.Project.Add(new Project { id_Project = Guid.NewGuid()});

            return userEntityDBModel as TOutput;

        }

  
    }

}

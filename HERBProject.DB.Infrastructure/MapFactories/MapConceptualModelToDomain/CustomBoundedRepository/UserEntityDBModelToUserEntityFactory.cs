using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HERBProject.Library.Entities;
using System.Runtime.CompilerServices;
using HERBProject.DB.Infrastructure.Repositories;
using HERBProject.DB.Infrastructure.Repositories.CustomBoundedRepository;

namespace HERBProject.DB.Infrastructure.MapFactories.MapConceptualModelToDomain.CustomBoundedRepository
{
    class UserEntityDBModelToUserEntityFactory : MapConceptualModelToDomainFactoryBase
    {

        internal override TOutput GetEntityFromDbObject<TInput, TOutput>(TInput dbObject)
        {
            if (dbObject == null) { return default(TOutput); }

            User userEntityModelDB = dbObject as User;//if casting fail, return null, so we have to verify the result
            if (userEntityModelDB == null) { throw new InvalidCastException("Cast to type List<Seat> has fail."); }

            UserEntity userEntity = new UserEntity();
            userEntity.Id = userEntityModelDB.id_User;
            userEntity.Name = userEntityModelDB.name_user;
            userEntity.LastName = userEntityModelDB.lastName_user;
            userEntity.NickName = userEntityModelDB.nickname_user;
            userEntity.Password = userEntityModelDB.password_user;
            userEntity.Email = userEntityModelDB.email_user;

            //foreach (Project project in userEntityModelDB.Project)
            //{
               

            //}
           

            return userEntity as TOutput;
        }
        
    }
}

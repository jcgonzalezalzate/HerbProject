using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HERBProject.DB.Infrastructure.Repositories.CustomBoundedRepository;
using HERBProject.Library.Entities;

namespace HERBProject.DB.Infrastructure.MapFactories.MapConceptualModelToDomain.CustomBoundedRepository
{
    public class ProjectEntityDBModelToProjectEntityFactory
    {
        public class UserEntityDBModelToUserEntityFactory : MapConceptualModelToDomainFactoryBase
        {

            internal override TOutput GetEntityFromDbObject<TInput, TOutput>(TInput dbObject)
            {
                if (dbObject == null) { return default(TOutput); }

                Project projectEntityModelDB = dbObject as Project;//if casting fail, return null, so we have to verify the result
                if (projectEntityModelDB == null) { throw new InvalidCastException("Cast to type List<Seat> has fail."); }

                ProjectEntity projecEntity = new ProjectEntity();
                projecEntity.Id = projectEntityModelDB.id_Project;
                projecEntity.Name = projectEntityModelDB.name_Project;
                projecEntity.Comments = projectEntityModelDB.comment_Project;
                projecEntity.File_Project = projectEntityModelDB.file_Project;

                //foreach (Project project in userEntityModelDB.Project)
                //{


                //}


                return projecEntity as TOutput;
            }

        }
    }
}

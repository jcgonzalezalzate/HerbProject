using System;
using HERBProject.Library.Entities;

namespace HERBProject.Library.InfrastructureContracts
{
    public interface IDomainRepository
    {

        UserEntity Get(UserEntity inputEntity);

        int Create(UserEntity inputEntity);

        void CreateWithNoPersist(UserEntity inputEntity);

        int Delete(UserEntity inputEntity);

        void DeleteWithNoPersist(UserEntity inputEntity);

        int Update(UserEntity inputEntity);

        void UpdateWithNoPersist(UserEntity inputEntity);

        void Rollback(UserEntity inputEntity);

    }
}

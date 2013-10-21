using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Vueling.Extensions.Library.DI;
using HERBProject.DB.Infrastructure.Configuration;
using HERBProject.DB.Infrastructure.MapFactories.MapConceptualModelToDomain;
using HERBProject.Library.Entities;

namespace HERBProject.DB.Infrastructure.Repositories.CustomBoundedRepository
{

    public class CustomBoundedRepository : RepositoryBase<InputEntity, Input>, HERBProject.Library.InfrastructureContracts.IDomainRepository
    {

        #region .: variables :.

        #endregion


        #region .: constructors :.

        public CustomBoundedRepository(ICustomBoundedContext dbContext)
        {
            //_context = dbContext.Context;
        }

        #endregion


        #region .: properties :.

        #endregion


        #region .: methods :.

        //public InputEntity Get(InputEntity inputEntity)
        //{
        //    var input = Find(inputEntity);

        //    MapConceptualModelToDomainFactoryBase factory = SwitcherRepositoryToEntityFactory.GetFactoryFor(typeof(Input));
        //    var inputEntityReturned = factory.GetEntityFromDbObject<Input, InputEntity>(input);

        //    return inputEntityReturned;
        //}

        //public new int Create(InputEntity inputEntity)
        //{
        //    var input = base.Create(inputEntity);

        //    return Persist(input);
        //}

        //public void CreateWithNoPersist(InputEntity inputEntity)
        //{
        //    base.Create(inputEntity);
        //}

        //public new int Delete(InputEntity inputEntity)
        //{
        //    var input = base.Delete(inputEntity);

        //    return Persist(input);
        //}

        //public void DeleteWithNoPersist(InputEntity inputEntity)
        //{
        //    base.Delete(inputEntity);
        //}

        //public new int Update(InputEntity inputEntity)
        //{
        //    var input = base.Update(inputEntity);

        //    return Persist(input);
        //}

        //public void UpdateWithNoPersist(InputEntity inputEntity)
        //{
        //    base.Update(inputEntity);
        //}

        //public void Rollback(InputEntity inputEntity)
        //{
        //    base.Rollback(inputEntity);
        //}

        #endregion


        public InputEntity Get(InputEntity inputEntity)
        {
            throw new NotImplementedException();
        }

        public new int Create(InputEntity inputEntity)
        {
            throw new NotImplementedException();
        }

        public void CreateWithNoPersist(InputEntity inputEntity)
        {
            throw new NotImplementedException();
        }

        public new int Delete(InputEntity inputEntity)
        {
            throw new NotImplementedException();
        }

        public void DeleteWithNoPersist(InputEntity inputEntity)
        {
            throw new NotImplementedException();
        }

        public new int Update(InputEntity inputEntity)
        {
            throw new NotImplementedException();
        }

        public void UpdateWithNoPersist(InputEntity inputEntity)
        {
            throw new NotImplementedException();
        }

        public void Rollback(InputEntity inputEntity)
        {
            throw new NotImplementedException();
        }
    }
}

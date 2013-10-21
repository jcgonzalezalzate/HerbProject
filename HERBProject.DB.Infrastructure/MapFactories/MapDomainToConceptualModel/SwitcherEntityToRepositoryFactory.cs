using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HERBProject.DB.Infrastructure.MapFactories.MapDomainToConceptualModel.CustomBoundedRepository;

namespace HERBProject.DB.Infrastructure.MapFactories.MapDomainToConceptualModel
{
    internal class SwitcherEntityToRepositoryFactory
    {
        internal static MapDomainToConceptualModelFactoryBase GetFactoryFor(Type typeOfInputEntity, Type typeOfOutputEntity)
        {
            if (typeOfOutputEntity.FullName.Contains("CustomBoundedRepository"))
            {
                switch (typeOfInputEntity.Name)
                {
                    case "UserEntity":
                        return new UserEntityToUserEntityDBModelFactory();
                    default:
                        throw new NotImplementedException(string.Format("The factory for type {0} is not implemented.", typeOfInputEntity.Name));
                }
            }
            else throw new NotImplementedException(string.Format("The factory for type {0} is not implemented.", typeOfInputEntity.Name));
        }

    }
}

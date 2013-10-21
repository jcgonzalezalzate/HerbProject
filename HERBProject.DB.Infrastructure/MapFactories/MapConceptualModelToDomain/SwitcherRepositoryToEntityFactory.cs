using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HERBProject.DB.Infrastructure.MapFactories.MapConceptualModelToDomain.CustomBoundedRepository;

namespace HERBProject.DB.Infrastructure.MapFactories.MapConceptualModelToDomain
{
    internal class SwitcherRepositoryToEntityFactory
    {
        internal static MapConceptualModelToDomainFactoryBase GetFactoryFor(Type typeOfdbObject)
        {
            if (typeOfdbObject.FullName.Contains("CustomBoundedRepository"))
            {
                switch (typeOfdbObject.Name)
                {
                    case "User":
                        return new UserEntityDBModelToUserEntityFactory();
                    default:
                        throw new NotImplementedException(string.Format("The factory for type {0} is not implemented.", typeOfdbObject.Name));
                }
            }
            else throw new NotImplementedException(string.Format("The factory for type {0} is not implemented.", typeOfdbObject.Name));
        }
    }
}

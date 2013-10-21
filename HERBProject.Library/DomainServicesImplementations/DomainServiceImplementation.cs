using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HERBProject.Library.Configuration;
using HERBProject.Library.Entities;
using HERBProject.Library.Exceptions;
using HERBProject.Library.InfrastructureContracts;

namespace HERBProject.Library.DomainServicesImplementations
{

    public class DomainServiceImplementation : HERBProject.Library.DomainServicesContracts.IDomainServiceContract
    {

        #region .: variables :.

        protected readonly ILibraryConfiguration _xXXLibraryConfiguration;
        protected readonly IDomainRepository _domainRepository;

        #endregion


        #region .: constructors :.

        public DomainServiceImplementation(ILibraryConfiguration xXXLibraryConfiguration, IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        #endregion


        #region .: properties :.

        #endregion


        #region .: methods :.

        //public OutputEntity DomainServiceMethod(UserEntity inputEntity)
        //{
        //    var outputEntity = new OutputEntity();

        //    return outputEntity;
        //}

        #endregion

    }
}

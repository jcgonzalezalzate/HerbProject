using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Vueling.Extensions.Library.DI;
//using Vueling.XXX.Contracts.ServiceLibrary;
//using Vueling.XXX.Contracts.ServiceLibrary.DTO;
using HERBProject.Impl.ServiceLibrary.Configuration;
using HERBProject.Impl.ServiceLibrary.MapFactories.MapDomainToDTO;
using HERBProject.Impl.ServiceLibrary.MapFactories.MapDTOToDomain;
using HERBProject.Contracts.ServiceLibrary;
using HERBProject.Library.DomainServicesContracts;
//using Vueling.XXX.Library.DomainServicesContracts;
//using Vueling.XXX.Library.Entities;

namespace HERBProject.Impl.ServiceLibrary
{
    //[RegisterServiceAttribute]
    public class ApplicationService : IApplicationServiceContract
    {

        #region .: variables :.

        private IDomainServiceContract _domainServiceContract;
        private IXXXServiceLibraryConfiguration _xxxxx;

        #endregion

        #region .: constructors :.

        public ApplicationService(IXXXServiceLibraryConfiguration serviceLibraryConfiguration, IDomainServiceContract domainServiceContract)
        {
            _domainServiceContract = domainServiceContract;
            _xxxxx = serviceLibraryConfiguration;
        }

        #endregion

        #region .: properties :.

        #endregion

        #region .: methods :.
        //public Contracts.ServiceLibrary.DTO.OutputEntityDTO ApplicationServiceMethod(Contracts.ServiceLibrary.DTO.UserEntityDTO inputEntity)
        //{

        //    MapDTOToDomainFactoryBase factoryToDomain = SwitcherDTOToEntityFactory.GetFactoryFor(EnumDomain.InputEntity);
        //    InputEntity inputEntity = factoryToDomain.GetEntityFromDTO<InputEntityDTO, InputEntity>(inputEntityDTO);

        //    var outputEntity = _domainServiceContract.DomainServiceMethod(inputEntity);

        //    MapDomainToDTOFactoryBase factoryToDTO = SwitcherEntityToDTOFactory.GetFactoryFor(EnumDTO.OutputEntityDTO);
        //    OutputEntityDTO outputEntityDTO = factoryToDTO.GetDTOFromEntity<OutputEntity, OutputEntityDTO>(outputEntity);

        //    return outputEntityDTO;
        // throw new NotImplementedException();

        //}

        private void PrivateApplicationServiceMethod()
        {



        }

        #endregion



        
    }
}

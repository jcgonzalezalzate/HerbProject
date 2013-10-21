using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using HERBProject.Contracts.ServiceLibrary.DTO;
using HERBProject.WebUI.Models;

[assembly: InternalsVisibleTo("HERBProject.WebUI.UnitTest")]
[assembly: InternalsVisibleTo("HERBProject.WebUI.IntegrationTest")]
namespace HERBProject.WebUI.MapFactories.DataModelToApplicationDTO
{
    class InputDataModelToInputEntityDTO : MapDataModelToApplicationDTOFactoryBase
    {

        internal override TOutput GetApplicationDTOFromDataModelDTO<TInput, TOutput>(TInput input)
        {

            var inputDataModel = input as InputDataModel;
            if (inputDataModel == null) { throw new InvalidCastException("Cast to type HERBProject.WebUI.DTO.ReservationSeatDataModel has fail."); }

            var inputEntityDTOseatDTO = new UserEntityDTO(inputDataModel.InputDataModelProperty);

            return (inputEntityDTOseatDTO) as TOutput;

        }

    }
}
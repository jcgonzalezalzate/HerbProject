using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using HERBProject.Contracts.ServiceLibrary.DTO;
using HERBProject.WebUI.Models;

[assembly: InternalsVisibleTo("HERBProject.WebUI.UnitTest")]
[assembly: InternalsVisibleTo("HERBProject.WebUI.IntegrationTest")]
namespace HERBProject.WebUI.MapFactories.ApplicationDTOToDataModel
{
    class OutputEntityDTOToOutputDataModel : MapApplicationDTOToDataModelFactoryBase
    {

        internal override TOutput GetDataModelDTOApplicationDTO<TInput, TOutput>(TInput input)
        {

            var outputEntityDTO = input as OutputEntityDTO;
            if (outputEntityDTO == null) { throw new InvalidCastException("Cast to type HERBProject.WebUI.DTO.ReservationSeatDataModel has fail."); }

            var outputDataModel = new OutputDataModel(outputEntityDTO.OutputEntityDTOProperty);

            return (outputDataModel) as TOutput;

        }

    }
}
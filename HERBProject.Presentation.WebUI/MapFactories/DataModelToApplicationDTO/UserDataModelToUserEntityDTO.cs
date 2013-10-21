using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using HERBProject.Contracts.ServiceLibrary.DTO;
using HERBProject.Presentation.WebUI.Models.User;

[assembly: InternalsVisibleTo("HERBProject.WebUI.UnitTest")]
[assembly: InternalsVisibleTo("HERBProject.WebUI.IntegrationTest")]
namespace HERBProject.Presentation.WebUI.MapFactories.DataModelToApplicationDTO
{
    class UserDataModelToUserEntityDTO : MapDataModelToApplicationDTOFactoryBase
    {

        internal override TOutput GetApplicationDTOFromDataModelDTO<TInput, TOutput>(TInput input)
        {

            UserDataModel userDataModel = input as UserDataModel;
            if (userDataModel == null) { throw new InvalidCastException("Cast to type HERBProject.WebUI.DTO.ReservationSeatDataModel has fail."); }

            UserEntityDTO userEntityDTO = new UserEntityDTO();
            userEntityDTO.Id = userDataModel.Id;
            userEntityDTO.Name = userDataModel.Name;
            userEntityDTO.LastName = userDataModel.LastName;
            userEntityDTO.NickName = userDataModel.NickName;
            userEntityDTO.Password = userDataModel.Password;
            userEntityDTO.Email = userDataModel.Email;

            return (userEntityDTO) as TOutput;

        }

    }
}
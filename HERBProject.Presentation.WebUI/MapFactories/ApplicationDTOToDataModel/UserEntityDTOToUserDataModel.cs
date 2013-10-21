using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using HERBProject.Contracts.ServiceLibrary.DTO;
using HERBProject.Presentation.WebUI.Models;
using HERBProject.Presentation.WebUI.Models.User;

[assembly: InternalsVisibleTo("HERBProject.WebUI.UnitTest")]
[assembly: InternalsVisibleTo("HERBProject.WebUI.IntegrationTest")]
namespace HERBProject.Presentation.WebUI.MapFactories.ApplicationDTOToDataModel
{
    class UserEntityDTOToUserDataModel : MapApplicationDTOToDataModelFactoryBase
    {

        internal override TOutput GetDataModelDTOApplicationDTO<TInput, TOutput>(TInput input)
        {

            UserEntityDTO userEntityDTO = input as UserEntityDTO;
            if (userEntityDTO == null) { throw new InvalidCastException("Cast to type HERBProject.WebUI.DTO.ReservationSeatDataModel has fail."); }

            UserDataModel userDataModel = new UserDataModel();
            userDataModel.Id = userEntityDTO.Id;
            userDataModel.Name = userEntityDTO.Name;
            userDataModel.LastName = userEntityDTO.LastName;
            userDataModel.NickName = userEntityDTO.NickName;
            userDataModel.Password = userEntityDTO.Password;
            userDataModel.Email = userEntityDTO.Email;
            return (userDataModel) as TOutput;

        }

    }
}
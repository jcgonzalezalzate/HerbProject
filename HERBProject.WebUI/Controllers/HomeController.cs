using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HERBProject.Contracts.ServiceLibrary.DTO;
using HERBProject.WebUI.Configuration;
using HERBProject.WebUI.MapFactories.DataModelToApplicationDTO;
using HERBProject.WebUI.Models;
using HERBProject.WebUI.MapFactories.ApplicationDTOToDataModel;
using HERBProject.Contracts.ServiceLibrary;

namespace HERBProject.WebUI.Controllers
{

    public class HomeController : Controller
    {

        #region .: variables :.

        readonly IApplicationServiceContract _applicationService;
        readonly IWebUIConfiguration _xXXWebUIConfiguration;

        #endregion


        #region .: contructors :.

        public HomeController(IApplicationServiceContract applicationService, IWebUIConfiguration configuration)
        {

            _applicationService = applicationService;
            _xXXWebUIConfiguration = configuration;
            _httpcontext = new HttpContextWrapper(System.Web.HttpContext.Current);

        }

        public HomeController(IApplicationServiceContract applicationService, IWebUIConfiguration configuration, HttpContextBase httpcontext)
        {

            _applicationService = applicationService;
            _xXXWebUIConfiguration = configuration;
            _httpcontext = httpcontext;

        }

        #endregion


        #region .: properties :.

        public IApplicationServiceContract applicationService
        {
            get { return _applicationService; }
        }
        public IWebUIConfiguration _configuration
        {
            get { return _xXXWebUIConfiguration; }
        }
        private HttpContextBase _httpcontext { get; set; }

        #endregion


        #region .: methods :.

        public ActionResult Index()
        {

            IndexViewModel viewmodel;
            string returnedMessage = string.Empty;

            if (_httpcontext.Request.HttpMethod == "POST")
            {

                ValidateParameters(_httpcontext.Request.Form["formVariable"]);

                InputDataModel inputDataModel = new InputDataModel(_httpcontext.Request.Form["formVariable"]);

                MapDataModelToApplicationDTOFactoryBase factoryDataModelToApplicationDTO = SwictherDataModelToApplicationDTO.GetFactoryFor(EnumApplicationDTO.InputEntityDTO);
                UserEntityDTO inputEntityDTO = factoryDataModelToApplicationDTO.GetApplicationDTOFromDataModelDTO<InputDataModel, UserEntityDTO>(inputDataModel);

                OutputEntityDTO outputEntityDTO = applicationService.ApplicationServiceMethod(inputEntityDTO);

                MapApplicationDTOToDataModelFactoryBase factoryApplicationDTOToDataModel = SwictherApplicationDTOToDataModel.GetFactoryFor(EnumDataModel.OutputDataModel);
                OutputDataModel outputDataModel = factoryApplicationDTOToDataModel.GetDataModelDTOApplicationDTO<OutputEntityDTO, OutputDataModel>(outputEntityDTO);

                returnedMessage = outputDataModel.OutputDataModelProperty;

            }
            else returnedMessage = "Submit any integer values";

            viewmodel = new IndexViewModel { IndexViewModelProperty = returnedMessage };

            return View(viewmodel);
        }

        private void ValidateParameters(string formVariable)
        {
            if (formVariable == string.Empty) throw new ArgumentException("FlightNumber is empty.");
        }

        #endregion

    }
}

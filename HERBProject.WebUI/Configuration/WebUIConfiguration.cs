using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using HERBProject.WebUI.Exceptions;

namespace HERBProject.WebUI.Configuration
{

    class WebUIConfiguration : IWebUIConfiguration
    {
        #region .: variables :.

        protected const char CONFIGLISTSEPARATOR = ';';


        #endregion


        #region .: constructors :.

        public WebUIConfiguration()
        {

            try
            {
                
                LoadCustomSettings();
            }

            catch (Exception anyException)
            {
                Trace.TraceError("Error initializing configuration in HERBProject.WebUI.Configuration.XXXWebUIConfiguration: " + anyException.Message);
                throw new ConfigurationInitializationException("Error initializing configuration in HERBProject.WebUI.Configuration.XXXWebUIConfiguration: " + anyException.Message, anyException);
            }

        }

        #endregion


        #region .: properties :.

        #endregion


        #region .: methods :.


        private void LoadCustomSettings()
        {

        }

      

     

        #endregion
    }
}

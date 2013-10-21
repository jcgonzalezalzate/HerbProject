using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Vueling.Configuration.Library;
using Vueling.Extensions.Library;
using Vueling.Extensions.Library.DI;
using HERBProject.Impl.ServiceLibrary.Exceptions;
using HERBProject.Library.Entities;

namespace HERBProject.Impl.ServiceLibrary.Configuration
{
    [RegisterConfigurationAttribute]
    public class XXXServiceLibraryConfiguration : IXXXServiceLibraryConfiguration
    {

        #region .: variables :.

        protected const char CONFIGLISTSEPARATOR = ';';
        private readonly VuelingEnvironment _currentConfig;
        private string _xXXServiceLibraryConfiguration;

        #endregion


        #region .: constructors :.

        public XXXServiceLibraryConfiguration()
        {
            try
            {
                _currentConfig = LoadCurrentConfig();
                LoadCustomSettings();
            }

            catch (Exception anyException)
            {
                Trace.TraceError("Error initializing configuration in HERBProject.Impl.ServiceLibrary.Configuration.XXXServiceLibraryConfiguration: " + anyException.Message);
                throw new ConfigurationInitializationException("Error initializing configuration in HERBProject.Impl.ServiceLibrary.Configuration.XXXServiceLibraryConfiguration: " + anyException.Message, anyException);
            }

        }

        #endregion


        #region .: properties :.

        public string xXXServiceLibraryLibraryConfigurationProperty
        {
            get { return _xXXServiceLibraryConfiguration; }
        }

        #endregion


        #region .: methods :.

        private VuelingEnvironment LoadCurrentConfig()
        {
            if (!VuelingEnvironment.IsInitialized)
            {
                Trace.TraceError("VuelingException not initialized in HERBProject.Impl.ServiceLibrary.Configuration.ServiceLibraryConfiguration.");
                throw new ConfigurationInitializationException("VuelingException not initialized in HERBProject.Impl.ServiceLibrary.Configuration.ServiceLibraryConfiguration.");
            }

            VuelingEnvironment.InitializeLibrary("HERBProject.Impl.ServiceLibrary");
            var result = VuelingEnvironment.Current;
            return result;
        }

        private void LoadCustomSettings()
        {
            _xXXServiceLibraryConfiguration = FindKey("HERBProject.Impl.ServiceLibrary._xXXServiceLibraryConfigurationProperty");
        }


        private string FindKey(string keyVar)
        {
            return _currentConfig.GetCustomSetting(keyVar);
        }

        private List<string> FindKeyList(string keyVar)
        {
            var result = new List<string>();
            var findKey = this.FindKey(keyVar);
            if (!String.IsNullOrEmpty(findKey))
            {
                result = new List<string>(findKey.Split(CONFIGLISTSEPARATOR).Select(s => s.Trim()));
            }
            return result;
        }

        #endregion

    }
}

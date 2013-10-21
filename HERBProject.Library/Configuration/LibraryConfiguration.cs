using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using HERBProject.Library.Exceptions;

namespace HERBProject.Library.Configuration
{
    
    public class LibraryConfiguration : ILibraryConfiguration
    {

        #region .: variables :.

        protected const char CONFIGLISTSEPARATOR = ';';
        private int _xXXLibraryConfigurationVariable;

        #endregion


        #region .: constructors :.

        public LibraryConfiguration()
        {
            try
            {
               
            }

            catch (Exception anyException)
            {
                Trace.TraceError("Error initializing configuration in HERBProject.Library.Configuration.XXXLibraryConfiguration: " + anyException.Message);
                throw new ConfigurationInitializationException("Error initializing configuration in HERBProject.Library.Configuration.XXXLibraryConfiguration: " + anyException.Message, anyException);
            }

        }

        #endregion


        #region .: properties :.

        public int LibraryConfigurationProperty
        {
            get { return _xXXLibraryConfigurationVariable; }
            protected set { _xXXLibraryConfigurationVariable = value; }
        }

        #endregion


        #region .: methods :.

     

        #endregion

    }
}

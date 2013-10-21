using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HERBProject.DB.Infrastructure.Exceptions;
using System.Diagnostics;

namespace HERBProject.DB.Infrastructure.Configuration
{
    public class InfrastructureConfiguration : IInfrastructureConfiguration
    {

        #region .: variables :.

        protected const char CONFIGLISTSEPARATOR = ';';
        private int _databaseTimeout;
        private string _connectionString;

        #endregion


        #region .: constructors :.

        public InfrastructureConfiguration()
        {
            try
            {
                DatabaseTimeout = 60000;
                ConnectionString = @"data source=NEWSHORE-PC\VUELING3;initial catalog=HERBProject_DataBase;persist security info=True;user id=sa;password=admin";
            }

            catch (Exception anyException)
            {
                Trace.TraceError("Error initializing configuration in HERBProject.DB.Infrastructure.Configuration.XXXInfrastructureConfiguration: " + anyException.Message);
                throw new ConfigurationInitializationException("Error initializing configuration in HERBProject.DB.Infrastructure.Configuration.XXXInfrastructureConfiguration: " + anyException.Message, anyException);
            }

        }

        #endregion


        #region .: properties :.

        #endregion


        #region .: methods :.

        public int DatabaseTimeout
        {
            get { return _databaseTimeout; }
            set { _databaseTimeout = value; }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        private void LoadCustomSettings()
        {

        }

        #endregion


    }
}
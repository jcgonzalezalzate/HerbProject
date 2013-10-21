using System;
using System.Collections.Generic;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using HERBProject.DB.Infrastructure.Configuration;

namespace HERBProject.DB.Infrastructure.Repositories.CustomBoundedRepository
{
    public class CustomBoundedContext : ContextBase, ICustomBoundedContext
    {
        private string _connectionString;
        private int _commandTimeOut;

        public CustomBoundedContext(IInfrastructureConfiguration infraestructureConfiguration)
        {
            _connectionString = infraestructureConfiguration.ConnectionString;
            _commandTimeOut = infraestructureConfiguration.DatabaseTimeout;
        }

        public HERBProject_DataBaseEntities GetEntitiesContext()
        {
            // Initialize Entity Connection String Builder
            EntityConnectionStringBuilder entityConnectionStringBuilder = new EntityConnectionStringBuilder();

            // Set the provider name
            entityConnectionStringBuilder.Provider = "System.Data.SqlClient";

            // Set the provider-specific connection string
            entityConnectionStringBuilder.ProviderConnectionString = _connectionString;
            entityConnectionStringBuilder.ProviderConnectionString += ";MultipleActiveResultSets=True";

            // Set the Metadata location
            entityConnectionStringBuilder.Metadata = string.Format("{0}|{1}|{2}",
                                            "res://*/Repositories.CustomBoundedRepository.HERBProject_DataBase.csdl",
                                            "res://*/Repositories.CustomBoundedRepository.HERBProject_DataBase.ssdl",
                                            "res://*/Repositories.CustomBoundedRepository.HERBProject_DataBase.msl");

            // Build Entity Connection
            EntityConnection entityConnection = new EntityConnection(entityConnectionStringBuilder.ToString());

            // Initialize Entity Object
            return new HERBProject_DataBaseEntities(entityConnection)
            {
                CommandTimeout = _commandTimeOut
            };

        }

    }
}

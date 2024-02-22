using System;
using System.Data.SqlClient;
using System.Reflection;

namespace DopplerIntegrationsData
{
    public class DopplerDataBaseSettings
    {
        public const string DopplerDataBase = "DopplerDataBase";

        public string ConnectionString { get; set; }

        public string GetSqlConnectionString()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                throw new ArgumentException("The string argument 'connectionString' cannot be empty.");
            }
            var builder = new SqlConnectionStringBuilder(ConnectionString)
            {
                ApplicationName = Assembly.GetEntryAssembly().GetName().Name,
            };
            return builder.ConnectionString;
        }
    }
}

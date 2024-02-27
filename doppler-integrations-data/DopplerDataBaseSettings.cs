using System;
using System.Data.SqlClient;
using System.Reflection;

namespace DopplerIntegrationsData
{
    public class DopplerDataBaseSettings
    {
        public const string DopplerDataBase = "DopplerDataBaseSettings";

        public string ConnectionString { get; set; }

        public string Password { get; set; }

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
            if (!string.IsNullOrWhiteSpace(Password))
            {
                builder.Password = Password;
            }
            return builder.ConnectionString;
        }
    }
}

using System.Data;
using System.Data.SqlClient;
using DopplerIntegrationsData.Helpers;
using DopplerIntegrationsDomain;

namespace DopplerIntegrationsData
{
    public class UserRepository : IUserRepository
    {
        public User GetUserById(int idUser)
        {
            User user = null;

            var query = @"
                SELECT TOP 1
                    [IdUser],
                    [IdUserTimeZone],
                    [IdLanguage]
                FROM [Doppler2011].[dbo].[User]
                WHERE IdUser = @idUser";

            using var reader = SQLHelper.ExecuteReader(
                SQLHelper.CONN_STRING,
                CommandType.Text,
                query,
                new SqlParameter("@idUser", idUser));
            if (reader.Read())
            {
                user = new User
                {
                    IdUser = NullTreatment.GetInt(reader.GetSqlValue(0)),
                    IdUserTimeZone = NullTreatment.GetInt(reader.GetSqlValue(1)),
                    IdLanguage = NullTreatment.GetInt(reader.GetSqlValue(2))
                };
            }

            reader.Close();

            return user;
        }
    }
}

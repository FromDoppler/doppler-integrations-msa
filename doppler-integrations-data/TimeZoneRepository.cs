using System.Data;
using System.Data.SqlClient;
using DopplerIntegrationsData.Helpers;
using DopplerIntegrationsDomain;

namespace DopplerIntegrationsData
{
    public class TimeZoneRepository : ITimeZoneRepository
    {
        public UserTimeZone GetByIdUserTimeZone(int idUserTimeZone)
        {
            UserTimeZone userTimeZone = null;

            var query = @"
                SELECT TOP 1
                    [IdUserTimeZone],
                    [Name],
                    [Offset],
                    [ZoneName],
                FROM [Doppler2011].[dbo].[UserTimeZone]
                WHERE IdUserTimeZone = @idUserTimeZone";

            using var reader = SQLHelper.ExecuteReader(
                SQLHelper.CONN_STRING,
                CommandType.Text,
                query,
                new SqlParameter("@idUserTimeZone", idUserTimeZone));
            if (reader.Read())
            {
                userTimeZone = new UserTimeZone
                {
                    IdUserTimeZone = NullTreatment.GetInt(reader.GetSqlValue(0)),
                    Name = NullTreatment.GetString(reader.GetSqlValue(1)),
                    Offset = NullTreatment.GetInt(reader.GetSqlValue(2)),
                    ZoneName = NullTreatment.GetString(reader.GetSqlValue(3)),
                };
            }

            reader.Close();

            return userTimeZone;
        }
    }
}

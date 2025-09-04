using System.Data;
using System.Data.SqlClient;
using DopplerIntegrationsData.Helpers;
using DopplerIntegrationsDomain;
using Microsoft.Extensions.Options;

namespace DopplerIntegrationsData
{
    public class ThirdPartyAppXUserRepository : IThirdPartyAppXUserRepository
    {
        private const string SP_GET_THIRD_PARTY_APP_X_USER = "GetIntegrationsByUser";

        public ThirdPartyAppXUserRepository(
            IOptions<DopplerDataBaseSettings> dopplerDataBaseSettings)
        {
            SQLHelper.CONN_STRING = dopplerDataBaseSettings.Value.GetSqlConnectionString();
        }

        public Task<IList<ThirdPartyAppXUser>> GetListThirdPartyAppByUser(int idUser)
        {
            IList<ThirdPartyAppXUser> list = new List<ThirdPartyAppXUser>();

            using (var reader = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, SP_GET_THIRD_PARTY_APP_X_USER, idUser))
            {
                while (reader.Read())
                {
                    list.Add(new ThirdPartyAppXUser
                    {
                        IdUser = NullTreatment.GetInt(reader.GetSqlValue(0)),
                        IdThirdPartyApp = NullTreatment.GetInt(reader.GetSqlValue(1)),
                        AccessToken = NullTreatment.GetString(reader.GetSqlValue(2)),
                        RefreshToken = NullTreatment.GetString(reader.GetSqlValue(3)),
                        IdAccount = NullTreatment.GetLong(reader.GetSqlValue(4)),
                        AccountName = NullTreatment.GetString(reader.GetSqlValue(5)),
                        UTCLastUpdate = NullTreatment.GetDateTime(reader.GetSqlValue(6)),
                        SendNotificationEmail = NullTreatment.GetBoolean(reader.GetSqlValue(7)),
                        UTCLastCompletedSync = NullTreatment.GetDateTime(reader.GetSqlValue(8)),
                        SourceType = NullTreatment.GetInt(reader.GetSqlValue(9)),
                        ConnectionErrors = NullTreatment.GetInt(reader.GetSqlValue(10)),
                        UTCLastValidation = NullTreatment.GetDateTime(reader.GetSqlValue(11)),
                        UTCCreationDate = NullTreatment.GetDateTime(reader.GetSqlValue(12)),
                        RFMActive = NullTreatment.GetBoolean(reader.GetSqlValue(13)),
                        RFMPeriod = NullTreatment.GetInt(reader.GetSqlValue(14)),
                        UTCLastRFMCalc = NullTreatment.GetDateTime(reader.GetSqlValue(15)),
                        BQUpdateDate = NullTreatment.GetDateTime(reader.GetSqlValue(16)),
                        UTCTokenExpiration = NullTreatment.GetDateTime(reader.GetSqlValue(17)),
                        UTCLastAssistedShoppingSync = NullTreatment.GetDateTime(reader.GetSqlValue(18)),
                        ThirdPartyApp = new ThirdPartyApp
                        {
                            IdThirdPartyApp = NullTreatment.GetInt(reader.GetSqlValue(1)),
                            Name = NullTreatment.GetString(reader.GetSqlValue(19)),
                            Active = NullTreatment.GetBoolean(reader.GetSqlValue(20)),
                            ProductsEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(21)),
                            AbandonedCartEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(22)),
                            VisitedProductsEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(23)),
                            CrossSellingEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(24)),
                            BestSellingEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(25)),
                            NewProductsEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(26)),
                            PendingOrderEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(27)),
                            ConfirmationOrderEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(28)),
                            RFMEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(29)),
                            PromotionCodeEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(30)),
                            AssistedShoppingEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(31)),
                            PopularProductsEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(32)),
                            ProductHistoryEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(33)),
                            DynamicProductEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(34)),
                            ExitPopUpEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(35))
                        }
                    });
                }
                reader.Close();
            }

            return Task.FromResult(list);
        }

        public Task<ThirdPartyAppXUser?> GetThirdPartyAppXUser(int idUser, int idThirdPartyApp)
        {
            ThirdPartyAppXUser? result = null;

            var query = @"
                SELECT TOP 1
                    [IdUser],
                    [IdThirdPartyApp],
                    [AccessToken],
                    [RefreshToken],
                    [IdAccount],
                    [AccountName],
                    [UTCLastUpdate],
                    [SendNotificationEmail],
                    [UTCLastCompletedSync],
                    [SourceType],
                    [ConnectionErrors],
                    [UTCLastValidation],
                    [UTCCreationDate],
                    [RFMActive],
                    [RFMPeriod],
                    [UTCLastRFMCalc],
                    [BQUpdateDate],
                    [UTCTokenExpiration],
                    [UTCLastAssistedShoppingSync]
                FROM [Doppler2011].[dbo].[ThirdPartyAppXUser]
                WHERE IdUser = @idUser AND IdThirdPartyApp = @idThirdPartyApp";

            using (var reader = SQLHelper.ExecuteReader(
                SQLHelper.CONN_STRING,
                CommandType.Text,
                query,
                new SqlParameter("@idUser", idUser),
                new SqlParameter("@idThirdPartyApp", idThirdPartyApp)))
            {
                if (reader.Read())
                {
                    result = new ThirdPartyAppXUser
                    {
                        IdUser = NullTreatment.GetInt(reader.GetSqlValue(0)),
                        IdThirdPartyApp = NullTreatment.GetInt(reader.GetSqlValue(1)),
                        AccessToken = NullTreatment.GetString(reader.GetSqlValue(2)),
                        RefreshToken = NullTreatment.GetString(reader.GetSqlValue(3)),
                        IdAccount = NullTreatment.GetLong(reader.GetSqlValue(4)),
                        AccountName = NullTreatment.GetString(reader.GetSqlValue(5)),
                        UTCLastUpdate = NullTreatment.GetNullableDateTime(reader.GetSqlValue(6)),
                        SendNotificationEmail = NullTreatment.GetBoolean(reader.GetSqlValue(7)),
                        UTCLastCompletedSync = NullTreatment.GetNullableDateTime(reader.GetSqlValue(8)),
                        SourceType = NullTreatment.GetInt(reader.GetSqlValue(9)),
                        ConnectionErrors = NullTreatment.GetInt(reader.GetSqlValue(10)),
                        UTCLastValidation = NullTreatment.GetNullableDateTime(reader.GetSqlValue(11)),
                        UTCCreationDate = NullTreatment.GetNullableDateTime(reader.GetSqlValue(12)),
                        RFMActive = NullTreatment.GetBoolean(reader.GetSqlValue(13)),
                        RFMPeriod = NullTreatment.GetInt(reader.GetSqlValue(14)),
                        UTCLastRFMCalc = NullTreatment.GetNullableDateTime(reader.GetSqlValue(15)),
                        BQUpdateDate = NullTreatment.GetNullableDateTime(reader.GetSqlValue(16)),
                        UTCTokenExpiration = NullTreatment.GetNullableDateTime(reader.GetSqlValue(17)),
                        UTCLastAssistedShoppingSync = NullTreatment.GetNullableDateTime(reader.GetSqlValue(18))
                    };
                }

                reader.Close();
            }

            return Task.FromResult(result);
        }

        public Task<ThirdPartyApp?> GetThirdPartyAppById(int idThirdPartyApp)
        {
            ThirdPartyApp? app = null;

            var query = @"
                SELECT TOP 1
                    [IdThirdPartyApp],
                    [Name],
                    [Active],
                    [ProductsEnabled],
                    [AbandonedCartEnabled],
                    [VisitedProductsEnabled],
                    [CrossSellingEnabled],
                    [BestSellingEnabled],
                    [NewProductsEnabled],
                    [PendingOrderEnabled],
                    [ConfirmationOrderEnabled],
                    [RFMEnabled],
                    [PromotionCodeEnabled],
                    [AssistedShoppingEnabled],
                    [PopularProductsEnabled],
                    [ProductHistoryEnabled],
                    [DynamicProductEnabled],
                    [ExitPopUpEnabled]
                FROM [Doppler2011].[dbo].[ThirdPartyApp]
                WHERE IdThirdPartyApp = @idThirdPartyApp";

            using (var reader = SQLHelper.ExecuteReader(
                SQLHelper.CONN_STRING,
                CommandType.Text,
                query,
                new SqlParameter("@idThirdPartyApp", idThirdPartyApp)))
            {
                if (reader.Read())
                {
                    app = new ThirdPartyApp
                    {
                        IdThirdPartyApp = NullTreatment.GetInt(reader.GetSqlValue(0)),
                        Name = NullTreatment.GetString(reader.GetSqlValue(1)),
                        Active = NullTreatment.GetBoolean(reader.GetSqlValue(2)),
                        ProductsEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(3)),
                        AbandonedCartEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(4)),
                        VisitedProductsEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(5)),
                        CrossSellingEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(6)),
                        BestSellingEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(7)),
                        NewProductsEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(8)),
                        PendingOrderEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(9)),
                        ConfirmationOrderEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(10)),
                        RFMEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(11)),
                        PromotionCodeEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(12)),
                        AssistedShoppingEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(13))
                    };
                }

                reader.Close();
            }

            return Task.FromResult(app);
        }
    }
}

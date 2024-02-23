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
                            AssistedShoppingEnabled = NullTreatment.GetBoolean(reader.GetSqlValue(31))
                        }
                    });
                }
                reader.Close();
            }

            return Task.FromResult(list);
        }
    }
}

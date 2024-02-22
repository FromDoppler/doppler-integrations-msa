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
            
            var nullTreatment = new NullTreatment();

            using (var reader = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, SP_GET_THIRD_PARTY_APP_X_USER, idUser))
            {
                while (reader.Read())
                {
                    list.Add(new ThirdPartyAppXUser
                    {
                        IdUser = nullTreatment.GetInt(reader.GetSqlValue(0)),
                        IdThirdPartyApp = nullTreatment.GetInt(reader.GetSqlValue(1)),
                        AccessToken = nullTreatment.GetString(reader.GetSqlValue(2)),
                        RefreshToken = nullTreatment.GetString(reader.GetSqlValue(3)),
                        IdAccount = nullTreatment.GetLong(reader.GetSqlValue(4)),
                        AccountName = nullTreatment.GetString(reader.GetSqlValue(5)),
                        UTCLastUpdate = nullTreatment.GetDateTime(reader.GetSqlValue(6)),
                        SendNotificationEmail = nullTreatment.GetBoolean(reader.GetSqlValue(7)),
                        UTCLastCompletedSync = nullTreatment.GetDateTime(reader.GetSqlValue(8)),
                        SourceType = nullTreatment.GetInt(reader.GetSqlValue(9)),
                        ConnectionErrors = nullTreatment.GetInt(reader.GetSqlValue(10)),
                        UTCLastValidation = nullTreatment.GetDateTime(reader.GetSqlValue(11)),
                        UTCCreationDate = nullTreatment.GetDateTime(reader.GetSqlValue(12)),
                        RFMActive = nullTreatment.GetBoolean(reader.GetSqlValue(13)),
                        RFMPeriod = nullTreatment.GetInt(reader.GetSqlValue(14)),
                        UTCLastRFMCalc = nullTreatment.GetDateTime(reader.GetSqlValue(15)),
                        BQUpdateDate = nullTreatment.GetDateTime(reader.GetSqlValue(16)),
                        UTCTokenExpiration = nullTreatment.GetDateTime(reader.GetSqlValue(17)),
                        UTCLastAssistedShoppingSync = nullTreatment.GetDateTime(reader.GetSqlValue(18)),
                        ThirdPartyApp = new ThirdPartyApp
                        {
                            IdThirdPartyApp = nullTreatment.GetInt(reader.GetSqlValue(1)),
                            Name = nullTreatment.GetString(reader.GetSqlValue(19)),
                            Active = nullTreatment.GetBoolean(reader.GetSqlValue(20)),
                            ProductsEnabled = nullTreatment.GetBoolean(reader.GetSqlValue(21)),
                            AbandonedCartEnabled = nullTreatment.GetBoolean(reader.GetSqlValue(22)),
                            VisitedProductsEnabled = nullTreatment.GetBoolean(reader.GetSqlValue(23)),
                            CrossSellingEnabled = nullTreatment.GetBoolean(reader.GetSqlValue(24)),
                            BestSellingEnabled = nullTreatment.GetBoolean(reader.GetSqlValue(25)),
                            NewProductsEnabled = nullTreatment.GetBoolean(reader.GetSqlValue(26)),
                            PendingOrderEnabled = nullTreatment.GetBoolean(reader.GetSqlValue(27)),
                            ConfirmationOrderEnabled = nullTreatment.GetBoolean(reader.GetSqlValue(28)),
                            RFMEnabled = nullTreatment.GetBoolean(reader.GetSqlValue(29)),
                            PromotionCodeEnabled = nullTreatment.GetBoolean(reader.GetSqlValue(30)),
                            AssistedShoppingEnabled = nullTreatment.GetBoolean(reader.GetSqlValue(31))
                        }
                    });
                }
                reader.Close();
            }

            return Task.FromResult(list); 
        }
    }
}

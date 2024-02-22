
using DopplerIntegrationsData.Helpers;
using DopplerIntegrationsDomain;
using Microsoft.Extensions.Options;

namespace DopplerIntegrationsData
{
    public class AssistedShoppingRepository : IAssistedShoppingRepository
    {
        private const string SP_GET_ASSISTED_SHOPPING = "datastudio.GetAssistedShopping";

        public AssistedShoppingRepository(
           IOptions<DopplerDataBaseSettings> dopplerDataBaseSettings)
        {
            SQLHelper.CONN_STRING = dopplerDataBaseSettings.Value.GetSqlConnectionString();
        }

        public Task<IList<AssistedShopping>> GetListAssistedShoppingByUser(int idUser, int idThirdPartyApp, DateTime dateFrom, DateTime dateTo)
        {
            IList<AssistedShopping> list = new List<AssistedShopping>();

            _ = new NullTreatment();

            using (var reader = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, SP_GET_ASSISTED_SHOPPING, idUser, idThirdPartyApp, dateFrom, dateTo))
            {
                while (reader.Read())
                {
                    list.Add(new AssistedShopping
                    {
                        IdUser = NullTreatment.GetInt(reader.GetSqlValue(0)),
                        IdCampaign = NullTreatment.GetInt(reader.GetSqlValue(1)),
                        IdSubscriber = NullTreatment.GetInt(reader.GetSqlValue(2)),
                        IdThirdPartyApp = NullTreatment.GetInt(reader.GetSqlValue(3)),
                        IdOrder = NullTreatment.GetString(reader.GetSqlValue(4)),
                        OrderTotal = NullTreatment.GetDouble(reader.GetSqlValue(5)),
                        Currency = NullTreatment.GetString(reader.GetSqlValue(6)),
                        OrderDate = NullTreatment.GetDateTime(reader.GetSqlValue(7)),
                        OpenDate = NullTreatment.GetDateTime(reader.GetSqlValue(8)),
                        UTCAddedDate = NullTreatment.GetDateTime(reader.GetSqlValue(9)),
                        Campaign = new Campaign
                        {
                            IdCampaign = NullTreatment.GetInt(reader.GetSqlValue(1)),
                            Name = NullTreatment.GetString(reader.GetSqlValue(10)),
                            CampaignType = NullTreatment.GetString(reader.GetSqlValue(11)),
                            AutomationEventType = NullTreatment.GetString(reader.GetSqlValue(12)),
                            AmountSentSubscribers = NullTreatment.GetInt(reader.GetSqlValue(13)),
                            DistinctOpenedMailCount = NullTreatment.GetInt(reader.GetSqlValue(14)),
                            UTCSentDate = NullTreatment.GetDateTime(reader.GetSqlValue(15)),
                        }
                    });
                }
                reader.Close();
            }

            return Task.FromResult(list);
        }
    }
}

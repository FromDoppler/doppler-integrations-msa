
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

            var nullTreatment = new NullTreatment();

            using (var reader = SQLHelper.ExecuteReader(SQLHelper.CONN_STRING, SP_GET_ASSISTED_SHOPPING, idUser, idThirdPartyApp, dateFrom, dateTo))
            {
                while (reader.Read())
                {
                    list.Add(new AssistedShopping
                    {
                        IdUser = nullTreatment.GetInt(reader.GetSqlValue(0)),
                        IdCampaign = nullTreatment.GetInt(reader.GetSqlValue(1)),
                        IdSubscriber = nullTreatment.GetInt(reader.GetSqlValue(2)),
                        IdThirdPartyApp = nullTreatment.GetInt(reader.GetSqlValue(3)),
                        IdOrder = nullTreatment.GetString(reader.GetSqlValue(4)),
                        OrderTotal = nullTreatment.GetDouble(reader.GetSqlValue(5)),
                        Currency = nullTreatment.GetString(reader.GetSqlValue(6)),
                        OrderDate = nullTreatment.GetDateTime(reader.GetSqlValue(7)),
                        OpenDate = nullTreatment.GetDateTime(reader.GetSqlValue(8)),
                        UTCAddedDate = nullTreatment.GetDateTime(reader.GetSqlValue(9)),
                        Campaign = new Campaign
                        {
                            IdCampaign = nullTreatment.GetInt(reader.GetSqlValue(1)),
                            Name = nullTreatment.GetString(reader.GetSqlValue(10)),
                            CampaignType = nullTreatment.GetString(reader.GetSqlValue(11)),
                            AutomationEventType = nullTreatment.GetString(reader.GetSqlValue(12)),
                            AmountSentSubscribers = nullTreatment.GetInt(reader.GetSqlValue(13)),
                            DistinctOpenedMailCount = nullTreatment.GetInt(reader.GetSqlValue(14)),
                            UTCSentDate = nullTreatment.GetDateTime(reader.GetSqlValue(15)),
                        }
                    });
                }
                reader.Close();
            }

            return Task.FromResult(list);
        }
    }
}

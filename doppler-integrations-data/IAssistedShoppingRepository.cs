using DopplerIntegrationsDomain;

namespace DopplerIntegrationsData
{
    public interface IAssistedShoppingRepository
    {
        Task<IList<AssistedShopping>> GetListAssistedShoppingByUser(int idUser, int idThirdPartyApp, DateTime dateFrom, DateTime dateTo);
    }
}

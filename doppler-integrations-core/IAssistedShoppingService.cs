using DopplerIntegrationsDomain;

namespace DopplerIntegrationsCore
{
    public interface IAssistedShoppingService
    {
        Task<IList<AssistedShopping>> GetListAssistedShoppingByUser(int idUser, int idThirdPartyApp, DateTime dateFrom, DateTime dateTo);
    }
}

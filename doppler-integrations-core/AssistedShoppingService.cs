using DopplerIntegrationsData;
using DopplerIntegrationsDomain;

namespace DopplerIntegrationsCore
{
    public class AssistedShoppingService : IAssistedShoppingService
    {
        private readonly IAssistedShoppingRepository _repository;

        public AssistedShoppingService(
            IAssistedShoppingRepository repository
        )
        {
            _repository = repository;
        }

        public async Task<IList<AssistedShopping>> GetListAssistedShoppingByUser(int idUser, int idThirdPartyApp, DateTime dateFrom, DateTime dateTo)
        {
            return await _repository.GetListAssistedShoppingByUser(idUser, idThirdPartyApp, dateFrom, dateTo);
        }
    }
}

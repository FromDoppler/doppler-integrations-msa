using DopplerIntegrationsData;
using DopplerIntegrationsDomain;
using System.Runtime;

namespace DopplerIntegrationsCore
{
    public class ThirdPartyAppService : IThirdPartyAppService
    {
        private readonly IThirdPartyAppXUserRepository _repository;

        public ThirdPartyAppService(
            IThirdPartyAppXUserRepository repository
        )
        {
            _repository = repository;
        }

        public async Task<IList<ThirdPartyAppXUser>> GetListThirdPartyAppByUser(int idUser)
        {
            return await _repository.GetListThirdPartyAppByUser(idUser);
        }
    }
}

using DopplerIntegrationsDomain;

namespace DopplerIntegrationsCore
{
    public interface IThirdPartyAppService
    {
        Task<IList<ThirdPartyAppXUser>> GetListThirdPartyAppByUser(int idUser);
    }
}

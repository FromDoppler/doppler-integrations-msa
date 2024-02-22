using DopplerIntegrationsDomain;

namespace DopplerIntegrationsData
{
    public interface IThirdPartyAppXUserRepository
    {
        Task<IList<ThirdPartyAppXUser>> GetListThirdPartyAppByUser(int idUser);
    }
}

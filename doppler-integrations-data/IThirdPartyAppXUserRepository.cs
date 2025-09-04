using DopplerIntegrationsDomain;

namespace DopplerIntegrationsData
{
    public interface IThirdPartyAppXUserRepository
    {
        Task<IList<ThirdPartyAppXUser>> GetListThirdPartyAppByUser(int idUser);
        Task<ThirdPartyAppXUser?> GetThirdPartyAppXUser(int idUser, int idThirdPartyApp);
        Task<ThirdPartyApp?> GetThirdPartyAppById(int idThirdPartyApp);
    }
}

using DopplerIntegrationsDomain;

namespace DopplerIntegrationsCore
{
    public interface IThirdPartyAppService
    {
        Task<IList<ThirdPartyAppXUser>> GetListThirdPartyAppByUser(int idUser);

        Task<ThirdPartyAppXUser?> GetThirdPartyAppXUser(User user, int idThirdPartyApp);

        Task<RfmModel?> GetRfmModel(User user, ThirdPartyAppXUser thirdPartyAppXUser);
    }
}

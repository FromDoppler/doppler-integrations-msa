using DopplerIntegrationsDomain;

namespace DopplerIntegrationsCore
{
    public interface IThirdPartyAppService
    {
        Task<IList<ThirdPartyAppXUser>> GetListThirdPartyAppByUser(int idUser);

        Task<ThirdPartyAppXUser?> GetThirdPartyAppXUser(int idUser, int idThirdPartyApp);

        Task<RfmModel?> GetRfmModel(ThirdPartyAppXUser thirdPartyAppXUser);
    }
}

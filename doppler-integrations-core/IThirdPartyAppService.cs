using DopplerIntegrationsDomain;

namespace DopplerIntegrationsCore
{
    public interface IThirdPartyAppService
    {
        Task<IList<ThirdPartyAppXUser>> GetListThirdPartyAppByUser(int idUser);

        Task<ThirdPartyAppXUser> GetThirdPartyAppXUser(int idThirdPartyApp, int idUser);

        Task<RfmModel> GetRfmModel(ThirdPartyAppXUser dto);
    }
}

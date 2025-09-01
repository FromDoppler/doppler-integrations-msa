using System.Globalization;
using DopplerIntegrationsData;
using DopplerIntegrationsDomain;

namespace DopplerIntegrationsCore
{
    public class ThirdPartyAppService : IThirdPartyAppService
    {
        private readonly IThirdPartyAppXUserRepository _repository;
        private readonly ITimeZoneRepository _timeZoneRepository;

        public ThirdPartyAppService(
            IThirdPartyAppXUserRepository repository,
            ITimeZoneRepository timeZoneRepository
        )
        {
            _repository = repository;
            _timeZoneRepository = timeZoneRepository;
        }

        public async Task<IList<ThirdPartyAppXUser>> GetListThirdPartyAppByUser(int idUser)
        {
            return await _repository.GetListThirdPartyAppByUser(idUser);
        }

        public async Task<ThirdPartyAppXUser?> GetThirdPartyAppXUser(User user, int idThirdPartyApp)
        {
            var appXUser = await _repository.GetThirdPartyAppXUser(user.IdUser, idThirdPartyApp);
            if (appXUser != null && user.IdUserTimeZone.HasValue)
            {
                var offset = 0;
                var userTimeZone = _timeZoneRepository.GetByIdUserTimeZone(user.IdUserTimeZone.Value);
                if (userTimeZone != null)
                {
                    offset = userTimeZone.Offset;
                }

                appXUser.UTCLastUpdate = appXUser.UTCLastUpdate.AddMinutes(offset);
            }

            return appXUser;
        }

        public async Task<RfmModel?> GetRfmModel(User user, ThirdPartyAppXUser thirdPartyAppXUser)
        {
            if (thirdPartyAppXUser != null)
            {
                var thirdPartyApp = await _repository.GetThirdPartyAppById(thirdPartyAppXUser.IdThirdPartyApp);
                var currentLanguage = string.Empty;

                if (user.IdLanguage.HasValue)
                {
                    currentLanguage = Utils.GetCurrentLanguage(user.IdLanguage.Value);
                }

                if (thirdPartyApp is not null)
                {
                    return new RfmModel()
                    {
                        Visible = thirdPartyApp.RFMEnabled,
                        Active = thirdPartyAppXUser.RFMActive,
                        Period = $"{thirdPartyAppXUser.RFMPeriod ?? Constants.RFM_DEFAULT_PERIOD}",
                        Date = thirdPartyAppXUser.UTCLastRFMCalc.HasValue ? Utils.FormatDateTimeAsString(thirdPartyAppXUser.UTCLastRFMCalc, currentLanguage) : string.Empty
                    };
                }
            }

            return null;
        }
    }
}

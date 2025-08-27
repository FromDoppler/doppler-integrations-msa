using System.Globalization;
using DopplerIntegrationsData;
using DopplerIntegrationsDomain;

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

        public async Task<ThirdPartyAppXUser?> GetThirdPartyAppXUser(int idUser, int idThirdPartyApp)
        {
            var appXUser = await _repository.GetThirdPartyAppXUser(idUser, idThirdPartyApp);
            if (appXUser != null)
            {
                //int offset = 0;
                //UserTimeZone timeZone = _timeZoneRepository.GetByUserId(idUser);
                //if (timeZone != null)
                //{
                //    offset = timeZone.Offset;
                //}

                //appXUser.UTCLastUpdate = appXUser.UTCLastUpdate.AddMinutes(offset);
            }

            return appXUser;
        }

        public async Task<RfmModel?> GetRfmModel(ThirdPartyAppXUser thirdPartyAppXUser)
        {
            if (thirdPartyAppXUser != null)
            {
                var thirdPartyApp = await _repository.GetThirdPartyAppById(thirdPartyAppXUser.IdThirdPartyApp);

                if (thirdPartyApp is not null)
                {
                    return new RfmModel()
                    {
                        Visible = thirdPartyApp.RFMEnabled,
                        Active = thirdPartyAppXUser.RFMActive,
                        Period = thirdPartyAppXUser.RFMPeriod.ToString(CultureInfo.InvariantCulture),
                        Date = thirdPartyAppXUser.UTCLastRFMCalc.HasValue ? Utils.FormatDateTimeAsString(thirdPartyAppXUser.UTCLastRFMCalc) : string.Empty
                    };
                }
            }

            return null;
        }
    }
}

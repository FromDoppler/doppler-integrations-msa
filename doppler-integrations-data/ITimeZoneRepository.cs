using DopplerIntegrationsDomain;

namespace DopplerIntegrationsData
{
    public interface ITimeZoneRepository
    {
        UserTimeZone GetByIdUserTimeZone(int idUserTimeZone);
    }
}

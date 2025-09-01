using DopplerIntegrationsDomain;

namespace DopplerIntegrationsData
{
    public interface IUserRepository
    {
        User GetUserById(int idUser);
    }
}

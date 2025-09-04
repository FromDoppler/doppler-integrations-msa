using DopplerIntegrationsData;
using DopplerIntegrationsDomain;

namespace DopplerIntegrationsCore
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int idUser)
        {
            return _userRepository.GetUserById(idUser);
        }
    }
}

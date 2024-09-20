using ContainerManagement.Model;
using ContainerManagement.Repository;

namespace ContainerManagement.Services
{
    public class UserFacade
    {
        private readonly IUserRepository _userRepository;

        public UserFacade()
        {
            _userRepository = UserRepository.Instance;
        }

        public User GetUserByUsername(string username)
        {
            return _userRepository.Get(username);
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }
    }
}

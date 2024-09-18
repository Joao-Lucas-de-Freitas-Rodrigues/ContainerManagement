using ContainerManagement.Model;

namespace ContainerManagement.Services
{
    public class UserFacade
    {
        private readonly IUserRepository _userRepository;

        public UserFacade(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

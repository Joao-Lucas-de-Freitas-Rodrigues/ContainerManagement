using ContainerManagement.Model;
using BC = BCrypt.Net.BCrypt;

namespace ContainerManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private static UserRepository _instance;
        private static readonly object _lock = new object();
        private readonly ConnectionContext _context = ConnectionContext.Instance;

        private UserRepository() { }

        public static UserRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new UserRepository();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Add(User user)
        {
            user.password = BC.HashPassword(user.password);
            _context.Add(user);
            _context.SaveChanges();
        }

        public User Get(string username)
        {
            return _context.Users.FirstOrDefault(x => x.username == username);
        }
    }
}

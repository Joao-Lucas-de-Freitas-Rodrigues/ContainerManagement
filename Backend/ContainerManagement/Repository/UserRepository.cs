using ContainerManagement.Model;
using BC = BCrypt.Net.BCrypt;

namespace ContainerManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(User user)
        {
            user.password = BC.HashPassword(user.password);
            _context.Add(user);
            _context.SaveChanges();
        }

        User IUserRepository.Get(string username)
        {
            User user = _context.Users.FirstOrDefault(x => x.username == username);
            return user;
        }
    }
}

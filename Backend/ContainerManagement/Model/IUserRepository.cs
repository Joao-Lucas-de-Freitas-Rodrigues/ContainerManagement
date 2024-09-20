namespace ContainerManagement.Model
{
    public interface IUserRepository
    {
        void Add(User user);
        User Get(string username);
    }
}

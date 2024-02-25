using ContainerManagement.Model;

namespace ContainerManagement.Infra
{
    public class ContainerRepository : IContainerRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Container container)
        {
            _context.Add(container);
            _context.SaveChanges();
        }

        public List<Container> Get()
        {
            return _context.Containers.ToList();
        }
    }
}

using ContainerManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace ContainerManagement.Repository
{
    public class ContainerRepository : IContainerRepository
    {
        private static ContainerRepository _instance;
        private static readonly object _lock = new object();
        private readonly ConnectionContext _context = ConnectionContext.Instance;

        private ContainerRepository() { }

        public static ContainerRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ContainerRepository();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Add(Container container)
        {
            _context.Add(container);
            _context.SaveChanges();
        }

        public List<Container> Get()
        {
            return _context.Containers
                .Include(c => c.ContainerType)
                .Include(c => c.ContainerStatus)
                .AsNoTracking()
                .ToList();
        }

        public void Put(int id, Container container)
        {
            container.id = id;
            _context.Entry(container).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Container container)
        {
            _context.Containers.Remove(container);
            _context.SaveChanges();
        }
    }
}

using ContainerManagement.Model;
using Microsoft.EntityFrameworkCore;

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
            return _context.Containers
                .Include(ct => ct.ContainerType)
                .Include(cs => cs.ContainerStatus)
                .AsNoTracking()
                .ToList();
        }

        public Container GetById(int id)
        {
            Container container = _context.Containers
                .Include(ct => ct.ContainerType)
                .Include(cs => cs.ContainerStatus)
                .AsNoTracking()
                .FirstOrDefault(ct => ct.id == id);
            return container;
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

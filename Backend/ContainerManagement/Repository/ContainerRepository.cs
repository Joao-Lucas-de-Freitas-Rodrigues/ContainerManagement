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
            var containers = _context.Containers
       .Include(c => c.ContainerType)
       .Include(c => c.ContainerStatus)
       .AsNoTracking()
       .ToList();

            // Itera sobre os containers e verifica o campo da imagem
            foreach (var container in containers)
            {
                if (container.Image == null) // Verifica se a imagem é null, não DBNull
                {
                    // Opcional: Executar alguma ação se a imagem for null, se necessário
                }
            }

            return containers;
        }

        public Container GetById(int id)
        {
            return _context.Containers
                .Include(ct => ct.ContainerType)
                .Include(cs => cs.ContainerStatus)
                .AsNoTracking()
                .FirstOrDefault(c => c.id == id);
        }

        public byte[] GetBlobById(int id)
        {
            return _context.Containers
        .AsNoTracking()
        .Where(c => c.id == id)
        .Select(c => c.Image)  // Supondo que o campo BLOB seja 'Image'
        .FirstOrDefault();
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

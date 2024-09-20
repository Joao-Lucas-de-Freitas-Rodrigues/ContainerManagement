using ContainerManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace ContainerManagement.Repository
{
    public class ContainerTypeRepository : IContainerTypeRepository
    {
        private static ContainerTypeRepository _instance;
        private static readonly object _lock = new object();
        private readonly ConnectionContext _context = ConnectionContext.Instance;

        private ContainerTypeRepository() { }

        public static ContainerTypeRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ContainerTypeRepository();
                        }
                    }
                }
                return _instance;
            }
        }

        public List<ContainerType> Get()
        {
            return _context.ContainerTypes.AsNoTracking().ToList();
        }
    }
}

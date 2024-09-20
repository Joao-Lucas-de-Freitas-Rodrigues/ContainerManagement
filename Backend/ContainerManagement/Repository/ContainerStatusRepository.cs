using ContainerManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace ContainerManagement.Repository
{
    public class ContainerStatusRepository : IContainerStatusRepository
    {
        private static ContainerStatusRepository _instance;
        private static readonly object _lock = new object();
        private readonly ConnectionContext _context = ConnectionContext.Instance;

        private ContainerStatusRepository() { }

        public static ContainerStatusRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ContainerStatusRepository();
                        }
                    }
                }
                return _instance;
            }
        }

        public List<ContainerStatus> Get()
        {
            return _context.ContainersStatus.AsNoTracking().ToList();
        }
    }
}

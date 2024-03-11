using ContainerManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace ContainerManagement.Infra
{
    public class ContainerStatusRepository : IContainerStatusRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public List<ContainerStatus> Get()
        {
            return _context.ContainersStatus.AsNoTracking().ToList();
        }
    }
}

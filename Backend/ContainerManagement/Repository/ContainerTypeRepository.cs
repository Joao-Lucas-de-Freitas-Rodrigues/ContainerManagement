using ContainerManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace ContainerManagement.Repository
{
    public class ContainerTypeRepository : IContainerTypeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public List<ContainerType> Get()
        {
            return _context.ContainerTypes.AsNoTracking().ToList();
        }
    }
}

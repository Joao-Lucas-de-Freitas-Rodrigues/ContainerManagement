using ContainerManagement.Model;
using ContainerManagement.Repository;

namespace ContainerManagement.Services
{
    public class ContainerTypeFacade
    {
        private readonly IContainerTypeRepository _containerTypeRepository;

        public ContainerTypeFacade()
        {
            _containerTypeRepository = ContainerTypeRepository.Instance;
        }

        public IEnumerable<ContainerType> GetAllContainerTypes()
        {
            return _containerTypeRepository.Get();
        }
    }
}

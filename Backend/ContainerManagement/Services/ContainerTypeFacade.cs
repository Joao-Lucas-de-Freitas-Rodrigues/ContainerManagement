using ContainerManagement.Model;

namespace ContainerManagement.Services
{
    public class ContainerTypeFacade
    {
        private readonly IContainerTypeRepository _containerTypeRepository;

        public ContainerTypeFacade(IContainerTypeRepository containerTypeRepository)
        {
            _containerTypeRepository = containerTypeRepository;
        }

        public IEnumerable<ContainerType> GetAllContainerTypes()
        {
            return _containerTypeRepository.Get();
        }
    }
}

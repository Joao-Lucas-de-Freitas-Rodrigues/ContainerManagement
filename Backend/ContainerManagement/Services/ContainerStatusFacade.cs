using ContainerManagement.Model;

namespace ContainerManagement.Services
{
    public class ContainerStatusFacade
    {
        private readonly IContainerStatusRepository _containerStatusRepository;

        public ContainerStatusFacade(IContainerStatusRepository containerStatusRepository)
        {
            _containerStatusRepository = containerStatusRepository;
        }

        public IEnumerable<ContainerStatus> GetAllContainerStatuses()
        {
            return _containerStatusRepository.Get();
        }
    }
}

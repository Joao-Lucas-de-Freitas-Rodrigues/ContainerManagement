using ContainerManagement.Model;
using ContainerManagement.Repository;

namespace ContainerManagement.Services
{
    public class ContainerStatusFacade
    {
        private readonly IContainerStatusRepository _containerStatusRepository;

        public ContainerStatusFacade()
        {
            _containerStatusRepository = ContainerStatusRepository.Instance;
        }

        public IEnumerable<ContainerStatus> GetAllContainerStatuses()
        {
            return _containerStatusRepository.Get();
        }
    }
}

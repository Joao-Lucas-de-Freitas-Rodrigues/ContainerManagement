using ContainerManagement.Model;

namespace ContainerManagement.Services
{
    public class ContainerFacade
    {
        private readonly IContainerRepository _containerRepository;

        public ContainerFacade(IContainerRepository containerRepository)
        {
            _containerRepository = containerRepository;
        }

        public void AddContainer(Container container)
        {
            _containerRepository.Add(container);
        }

        public Container GetContainerById(int id)
        {
            return _containerRepository.GetById(id);
        }

        public List<Container> GetAllContainers()
        {
            return _containerRepository.Get();
        }

        public void UpdateContainer(int id, Container container)
        {
            _containerRepository.Put(id, container);
        }

        public void DeleteContainer(Container container)
        {
            _containerRepository.Delete(container);
        }
    }
}

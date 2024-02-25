namespace ContainerManagement.Model
{
    public interface IContainerRepository
    {

        void Add(Container container);

        List<Container> Get();

    }
}

namespace ContainerManagement.Model
{
    public interface IContainerRepository
    {
        void Add(Container container);
        List<Container> Get();
        Container GetById(int id);
        void Put(int id, Container container);
        void Delete(Container container);
    }
}

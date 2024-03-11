namespace ContainerManagement.Model
{
    public interface IContainerStatusRepository
    {
        List<ContainerStatus> Get();
    }
}

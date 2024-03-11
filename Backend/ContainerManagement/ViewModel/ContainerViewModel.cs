namespace ContainerManagement.ViewModel
{
    public class ContainerViewModel
    {
        public string container_description { get; set; }

        public string container_name { get; set; }

        public int container_type_id { get; set; }

        public int container_status_id { get; set; }

        public ContainerViewModel(string container_description, string container_name, int container_type_id, int container_status_id)
        {
            this.container_description = container_description;
            this.container_name = container_name;
            this.container_type_id = container_type_id;
            this.container_status_id = container_status_id;
        }
    }
}

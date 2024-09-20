using Microsoft.AspNetCore.Http;

namespace ContainerManagement.ViewModel
{
    public class ContainerViewModel
    {
        public string container_description { get; set; }
        public string container_name { get; set; }
        public int container_type_id { get; set; }
        public int container_status_id { get; set; }

        // Campo para receber a imagem
        public IFormFile Image { get; set; }

        // Construtor sem parâmetros para permitir o model binding
        public ContainerViewModel() { }

        // Construtor com parâmetros (opcional)
        public ContainerViewModel(string container_description, string container_name, int container_type_id, int container_status_id, IFormFile image)
        {
            this.container_description = container_description;
            this.container_name = container_name;
            this.container_type_id = container_type_id;
            this.container_status_id = container_status_id;
            this.Image = image;
        }
    }
}

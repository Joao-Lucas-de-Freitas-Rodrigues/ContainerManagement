using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace ContainerManagement.Model
{
    [Table("container")]
    public class Container
    {
        [Key]
        public int id { get; set; }

        public string container_description { get; set; }

        public string container_name { get; set;}

        public int container_type_id { get; set;}

        public int container_status_id { get; set; }

        public byte[]? Image { get; set; }


        [ForeignKey("container_type_id")]
        public ContainerType ContainerType { get; set; }

        [ForeignKey("container_status_id")]
        public ContainerStatus ContainerStatus { get; set; }

        public Container(string container_description, string container_name, int container_type_id, int container_status_id, byte[] image = null)
        {
            this.container_description = container_description;
            this.container_name = container_name;
            this.container_type_id = container_type_id;
            this.container_status_id = container_status_id;
            this.Image = image;
        }
    }
}

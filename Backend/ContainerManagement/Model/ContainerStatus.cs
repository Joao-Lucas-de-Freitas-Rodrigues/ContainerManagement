using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ContainerManagement.Model
{
    [Table("containerstatus")]
    public class ContainerStatus
    {
        [Key]
        public int id { get; set; }

        public string description { get; set; }

        public ContainerStatus(string description)
        {
            this.description = description;
        }
    }
}

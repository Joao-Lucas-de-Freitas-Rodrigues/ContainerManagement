using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ContainerManagement.Model
{
    [Table("containertype")]
    public class ContainerType
    {
        [Key]
        public int id {  get; set; }

        public string description { get; set; }

        public ContainerType(string description)
        { 
            this.description = description;
        }
    }
}

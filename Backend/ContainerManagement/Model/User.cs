using System.ComponentModel.DataAnnotations;

namespace ContainerManagement.Model
{
    public class User
    {
        [Key]
        public int id { get; set; }

        public string? login { get; set; }

        public string? password { get; set; }
    }
}

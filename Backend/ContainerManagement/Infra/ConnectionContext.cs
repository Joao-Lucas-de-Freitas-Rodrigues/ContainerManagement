using ContainerManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace ContainerManagement.Infra
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Container> Containers { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL(
                "Server=localhost;" +
                "Port=3306;Database=container_management;" +
                "User Id=root;" +
                "Password=Cearamor123");
    }
}

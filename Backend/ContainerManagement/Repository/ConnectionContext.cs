using ContainerManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace ContainerManagement.Repository
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Container> Containers { get; set; }
        
        public DbSet<ContainerType> ContainerTypes { get; set; }

        public DbSet<ContainerStatus> ContainersStatus { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Container>().ToTable("container");
            modelBuilder.Entity<ContainerType>().ToTable("container_type");
            modelBuilder.Entity<ContainerStatus>().ToTable("container_status");

            modelBuilder.Entity<Container>()
            .HasOne(c => c.ContainerType)
            .WithMany()
            .HasForeignKey(c => c.container_type_id);

            modelBuilder.Entity<Container>()
                .HasOne(c => c.ContainerStatus)
                .WithMany()
                .HasForeignKey(c => c.container_status_id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL(
                "Server=localhost;" +
                "Port=3306;Database=container_management;" +
                "User Id=root;" +
                "Password=Cearamor123");
    }
}

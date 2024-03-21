using Microsoft.EntityFrameworkCore;
namespace API_AtomHack
{
    using API_AtomHack.Model;
    using Microsoft.EntityFrameworkCore;
    using NuGet.Protocol.Plugins;
    using System.Composition;
    using API_AtomHack.Model;

    public class ApplicationContext : DbContext
    {
        public DbSet<Message1> Messages { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<userHistory> userHistories { get; set; } = null!;
        public DbSet<File1> Files { get; set; } = null!;
        public DbSet<Colony> Colonies { get; set; } = null!;
        public DbSet<System> Systems { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colony>().HasData(
            new Colony { Id = 1, Name = "Акварион" },
            new Colony { Id = 2, Name = "Зеленый лабиринт" },
            new Colony { Id = 3, Name = "Кристалия" },
            new Colony { Id = 4, Name = "Пустынный вихрь" });

            modelBuilder.Entity<System>().HasData(
            new System { Id = 1, Name = "IMS 3.0" },
            new System { Id = 2, Name = "IMS 4.0" },
            new System { Id = 3, Name = "MDP 2.0" },
            new System { Id = 4, Name = "UTS" });


        }
    }
}

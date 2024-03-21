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
        public DbSet<Access> Access { get; set; } = null!;
        public DbSet<Documentation> Documentations { get; set; } = null!;
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

            modelBuilder.Entity<Access>().HasData(
            new Access { Id = 1, FileName = "1.docx", ColonyId = 1, SystemId = 1 },
            new Access { Id = 2, FileName = "1.docx", ColonyId = 1, SystemId = 2 },
            new Access { Id = 3, FileName = "1.docx", ColonyId = 1, SystemId = 3 },
            new Access { Id = 4, FileName = "1.docx", ColonyId = 1, SystemId = 4 },
            new Access { Id = 5, FileName = "1.docx", ColonyId = 2, SystemId = 3 },
            new Access { Id = 6, FileName = "1.docx", ColonyId = 2, SystemId = 4 },
            new Access { Id = 7, FileName = "1.docx", ColonyId = 3, SystemId = 1 },
            new Access { Id = 8, FileName = "1.docx", ColonyId = 3, SystemId = 2 },
            new Access { Id = 9, FileName = "1.docx", ColonyId = 4, SystemId = 2 },
            new Access { Id = 10, FileName = "1.docx", ColonyId = 4, SystemId = 3 });

            modelBuilder.Entity<Documentation>().HasData(
            new Access { Id = 1, FileName = "1.docx", ColonyId = 1, SystemId = 1 },
            new Access { Id = 2, FileName = "1.docx", ColonyId = 1, SystemId = 2 },
            new Access { Id = 3, FileName = "1.docx", ColonyId = 1, SystemId = 3 },
            new Access { Id = 4, FileName = "1.docx", ColonyId = 1, SystemId = 4 },
            new Access { Id = 5, FileName = "1.docx", ColonyId = 2, SystemId = 3 },
            new Access { Id = 6, FileName = "1.docx", ColonyId = 2, SystemId = 4 },
            new Access { Id = 7, FileName = "1.docx", ColonyId = 3, SystemId = 1 },
            new Access { Id = 8, FileName = "1.docx", ColonyId = 3, SystemId = 2 },
            new Access { Id = 9, FileName = "1.docx", ColonyId = 4, SystemId = 2 },
            new Access { Id = 10, FileName = "1.docx", ColonyId = 4, SystemId = 3 });


        }
    }
}

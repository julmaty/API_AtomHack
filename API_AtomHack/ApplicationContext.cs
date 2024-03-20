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
        public DbSet<Model.Message> Messages { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<userHistory> userHistories { get; set; } = null!;
        public DbSet<File> Files { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
    }
}

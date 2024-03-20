using Microsoft.EntityFrameworkCore;
using API_AtomHack;
namespace API_AtomHack
{
    using Microsoft.EntityFrameworkCore;
    using NuGet.Protocol.Plugins;
    using System.Composition;

    public class ApplicationContext : DbContext
    {
        public DbSet<Message> Messages { get; set; } = null!;
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

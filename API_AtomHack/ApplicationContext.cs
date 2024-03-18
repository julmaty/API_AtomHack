namespace API_AtomHack
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : DbContext
    {
        public DbSet<ReportCategory> ReportCategories { get; set; } = default!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReportCategory>().HasData(
            new ReportCategory { Id = 1, Description = "Здоровье" },
            new ReportCategory { Id = 2, Description = "Климат, параметры атмосферы" },
            new ReportCategory { Id = 3, Description = "Исследования, научная база" },
            new ReportCategory { Id = 4, Description = "Ресурсы" }
    );
        }
    }
}

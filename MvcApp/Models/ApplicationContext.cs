using Microsoft.EntityFrameworkCore;

namespace MvcApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cloth> Clothes { get; set; } = null!;
        public DbSet<Cloth_type> Cloth_types { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
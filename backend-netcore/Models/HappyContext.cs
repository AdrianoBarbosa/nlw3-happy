using Microsoft.EntityFrameworkCore;

namespace Happy.Models
{
    public class HappyContext : DbContext
    {
        public HappyContext(DbContextOptions<HappyContext> options)
            : base(options)
        {
        }

        public DbSet<Orphanage> Orphanages { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
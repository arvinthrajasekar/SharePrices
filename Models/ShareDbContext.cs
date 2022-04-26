using Microsoft.EntityFrameworkCore;

namespace SharePrices.Models
{
    public class ShareDbContext : DbContext
    {
        public ShareDbContext(DbContextOptions<ShareDbContext> options) : base(options)
        {

        }

        public DbSet<Shares> Share { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Shares>().HasData(new Shares { Name = "3M India Ltd", Price = 21145 });
            modelBuilder.Entity<Shares>().HasData(new Shares { Name = "Aarti Drugs Ltd", Price = 519 });
            modelBuilder.Entity<Shares>().HasData(new Shares { Name = "Tata Power", Price = 277.8 });
            modelBuilder.Entity<Shares>().HasData(new Shares { Name = "HDFC Bank", Price = 1516.75 });
            modelBuilder.Entity<Shares>().HasData(new Shares { Name = "Zee Entertainment", Price = 284.75 });

        }
    }
}

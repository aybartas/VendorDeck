using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VendorDeck.DataAccess.Mappings;
using VendorDeck.Entities.Concrete;

namespace VendorDeck.DataAccess.Context
{
    public class VendorDeckContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public string ConnectionString { get; set; }
        public VendorDeckContext(IConfiguration configuration)
        {
            ConnectionString = configuration["ConnectionString"];
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new BasketMap());
            modelBuilder.ApplyConfiguration(new BasketItemMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }

    }
}

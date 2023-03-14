using Microsoft.EntityFrameworkCore;
using VendorDeck.DataAccess.Mappings;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Persistence.Context
{
    public class VendorDeckContext : DbContext
    {
        public VendorDeckContext(DbContextOptions options) : base(options)
        {
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

using Microsoft.EntityFrameworkCore;
using VendorDeck.DataAccess.Mappings;
using VendorDeck.Entities.Concrete;

namespace VendorDeck.DataAccess.Context
{
    public class VendorDeckContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "server=TAS\\SQLEXPRESS; database=VendorDeckDb; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketItem>().ToTable("BasketItems");
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new BasketMap());
            modelBuilder.ApplyConfiguration(new BasketItemMap());

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }


    }
}

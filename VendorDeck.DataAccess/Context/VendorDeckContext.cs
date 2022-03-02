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
            modelBuilder.ApplyConfiguration(new ProductMap());
        }

        public DbSet<Product> Products { get; set; }


    }
}

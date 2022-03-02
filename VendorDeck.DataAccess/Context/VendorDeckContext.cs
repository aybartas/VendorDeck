using Microsoft.EntityFrameworkCore;
using VendorDeck.Entities.Concrete;

namespace VendorDeck.DataAccess.Context
{
    public class VendorDeckContext : DbContext
    {
        public VendorDeckContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
              "server=TAS\\SQLEXPRESS; database=VendorDeckDb; integrated security=true;");
        }

        public DbSet<Product> Products { get; set; }


    }
}

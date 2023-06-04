using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using VendorDeck.DataAccess.Mappings;
using VendorDeck.Domain.Entities.Concrete;
using VendorDeck.Persistence.Mappings;

namespace VendorDeck.Persistence.Context
{
    public class VendorDeckContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public VendorDeckContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new BasketMap());
            modelBuilder.ApplyConfiguration(new BasketItemMap());
            modelBuilder.ApplyConfiguration(new AppRoleMap());
            modelBuilder.ApplyConfiguration(new OrderItemMap());
            modelBuilder.ApplyConfiguration(new OrderMap());

            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var baseEntries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entity in baseEntries)
            {
                switch (entity.State)
                {
                    case EntityState.Modified:
                        entity.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entity.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}

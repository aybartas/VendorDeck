using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Persistence.Mappings
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //builder.HasMany(I => I.Addresses).
            //    WithOne(I => I.AppUser).
            //    HasForeignKey(I => I.AppUserId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

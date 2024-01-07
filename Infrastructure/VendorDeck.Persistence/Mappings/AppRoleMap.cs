using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendorDeck.Domain.Constants;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Persistence.Mappings
{
    public class AppRoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole { Id = 1,Name = RoleTypes.Member, NormalizedName = "MEMBER" },
                new AppRole { Id = 2,Name = RoleTypes.Admin, NormalizedName = "ADMIN" });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendorDeck.Domain.Entities.Concrete;
using VendorDeck.Persistence.Context;

namespace VendorDeck.DataAccess.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn(1,1);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.HasData((IEnumerable<object>)VendorDeckDbInitializer.GetSeedProducts());
        }
    }
}

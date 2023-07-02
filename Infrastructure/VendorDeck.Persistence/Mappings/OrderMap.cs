using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Persistence.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(e => e.ShippingAddress).Property(p => p.Details).HasColumnName("ShippingAddressDetails");
            builder.OwnsOne(e => e.ShippingAddress).Property(p => p.Country).HasColumnName("ShippingAddressCountry");
            builder.OwnsOne(e => e.ShippingAddress).Property(p => p.City).HasColumnName("ShippingAddressCity");
            builder.OwnsOne(e => e.ShippingAddress).Property(p => p.State).HasColumnName("ShippingAddressState");
            builder.OwnsOne(e => e.ShippingAddress).Ignore(p => p.CreatedDate);
            builder.OwnsOne(e => e.ShippingAddress).Ignore(p => p.Id);
            builder.OwnsOne(e => e.ShippingAddress).Ignore(p => p.LastModifiedDate);

            builder.HasIndex(e => e.Id).IsUnique();
            builder.HasIndex(e => e.OrderNumber).IsUnique();

        }
    }
}

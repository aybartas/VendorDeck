using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Persistence.Mappings
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(e => e.OrderedProductItem).Property(p => p.Name).HasColumnName("Name");
            builder.OwnsOne(e => e.OrderedProductItem).Property(p => p.PictureUrl).HasColumnName("PictureUrl");
            builder.OwnsOne(e => e.OrderedProductItem).Property(p => p.ProductId).HasColumnName("ProductId");
        }
    }
}

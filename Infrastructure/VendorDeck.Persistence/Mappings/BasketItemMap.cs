using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.DataAccess.Mappings
{
    public class BasketItemMap : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.ToTable("BasketItems");
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Quantity).IsRequired();
            builder.Property(I => I.ProductId).IsRequired();
            builder.Property(I => I.Quantity).IsRequired();
            builder.HasOne(I => I.Basket).WithMany(I => I.BasketItems).HasForeignKey(I => I.BasketId);
        }
    }
}

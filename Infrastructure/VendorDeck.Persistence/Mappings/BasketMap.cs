using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.DataAccess.Mappings
{
    public class BasketMap : IEntityTypeConfiguration<Basket>
    {   
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.BuyerId).IsRequired();
            builder.HasMany(I => I.BasketItems).WithOne(I => I.Basket)
                .HasForeignKey(I => I.BasketId).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}

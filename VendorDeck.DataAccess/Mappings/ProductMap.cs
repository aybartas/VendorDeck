using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.DataAccess.Context;
using VendorDeck.Entities.Concrete;

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

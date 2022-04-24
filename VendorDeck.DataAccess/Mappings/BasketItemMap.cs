using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.DataAccess.Mappings
{
    public class BasketItemMap : IEntityTypeConfiguration<BasketItemMap>
    {
        public void Configure(EntityTypeBuilder<BasketItemMap> builder)
        {
        }
    }
}

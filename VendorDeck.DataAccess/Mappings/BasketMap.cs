using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Entities.Concrete;

namespace VendorDeck.DataAccess.Mappings
{
    public class BasketMap : IEntityTypeConfiguration<Basket>
    {   
        public void Configure(EntityTypeBuilder<Basket> builder)
        {               
        }
    }
}

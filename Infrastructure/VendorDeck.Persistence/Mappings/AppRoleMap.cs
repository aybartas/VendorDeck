﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Persistence.Mappings
{
    public class AppRoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole { Name = "Member", NormalizedName = "MEMBER" },
                new AppRole { Name = "Admin", NormalizedName = "ADMIN" });
        }
    }
}

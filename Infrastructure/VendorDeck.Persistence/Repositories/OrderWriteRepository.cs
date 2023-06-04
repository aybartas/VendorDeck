using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Repositories;
using VendorDeck.Domain.Entities.Concrete;
using VendorDeck.Persistence.Context;

namespace VendorDeck.Persistence.Repositories
{
    public class OrderWriteRepository : WriteRepository<Order>,IOrderWriteRepository
    {
        public OrderWriteRepository(VendorDeckContext context): base(context)
        {
        }

        public override async Task<Order> AddAsync(Order model)
        {
            var response = await Table.AddAsync(model);
            return response.Entity;
        }
    }
}

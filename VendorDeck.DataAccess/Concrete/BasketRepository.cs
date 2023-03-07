using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.DataAccess.Context;
using VendorDeck.DataAccess.Interfaces;
using VendorDeck.Entities.Concrete;

namespace VendorDeck.DataAccess.Concrete
{
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        public BasketRepository(VendorDeckContext context) : base(context)
        {
        }

        public async Task<Basket> GetBasketWithItemsAsync(string buyerId)
        {
            return await _context.Baskets.
                Include(b => b.BasketItems).
                ThenInclude(bi => bi.Product).
                SingleOrDefaultAsync(b => b.BuyerId == buyerId);
        }
    }
}

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

        public async Task<Basket> GetBasketWithItemsAsync(string buyerId)
        {
            using var context = new VendorDeckContext();
            return await context.Baskets
                .Include(I => I.BasketItems)
                .ThenInclude(I => I.Product)
                .Where(I => I.BuyerId == buyerId)
                .FirstOrDefaultAsync();
        }
    }
}

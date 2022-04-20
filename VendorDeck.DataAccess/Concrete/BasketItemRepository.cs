using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.DataAccess.Interfaces;
using VendorDeck.Entities.Concrete;

namespace VendorDeck.DataAccess.Concrete
{
    public class BasketItemRepository : GenericRepository<BasketItem> , IBasketItemRepository
    {
    }
}

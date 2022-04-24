using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Entities.Concrete;

namespace VendorDeck.DataAccess.Interfaces
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketWithItemsAsync(int customerId);
    }
}

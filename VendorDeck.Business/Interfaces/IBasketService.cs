using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Entities.Concrete;

namespace VendorDeck.Business.Interfaces
{
    public interface IBasketService : IGenericService<Basket>
    {
        void AddItemToBasket(Basket basket, Product product, int quantity);
        void RemoveItemFromBasket(Basket basket, Product product, int quantity);

    }
}

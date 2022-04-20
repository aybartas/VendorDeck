using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Business.Interfaces;
using VendorDeck.DataAccess.Interfaces;
using VendorDeck.Entities.Concrete;

namespace VendorDeck.Business.Concrete
{
    public class BasketService : GenericService<Basket> , IBasketService
    {
        public BasketService(IGenericRepository<Basket> genericRepository) : base(genericRepository)
        {  
        }
        public async void AddItemToBasket(Basket basket, Product product, int quantity)
        {
            var existingItem = basket.BasketItems.FirstOrDefault(I => I.ProductId == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                basket.BasketItems.Add(new BasketItem { Product = product, Quantity = quantity });
            }

            await genericRepository.UpdateAsync(basket);

        }
        public async void RemoveItemFromBasket(Basket basket, Product product, int quantity)
        {
            var existingItem = basket.BasketItems.FirstOrDefault(I => I.ProductId == product.Id);
            
            if (existingItem == null) return;
            
            existingItem.Quantity -= quantity;
            
            if( existingItem != null && existingItem.Quantity == 0)
            {
                basket.BasketItems.Remove(existingItem);
            }
            
        }
    }
}

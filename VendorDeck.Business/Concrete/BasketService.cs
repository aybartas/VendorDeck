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
        private readonly IBasketRepository basketRepository;
        private readonly IBasketItemRepository basketItemRepository;   

        public BasketService(IGenericRepository<Basket> genericRepository, IBasketRepository basketRepository, IBasketItemRepository basketItemRepository) : base(genericRepository)
        {
            this.basketRepository = basketRepository;
            this.basketItemRepository = basketItemRepository;
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
            await basketRepository.UpdateAsync(basket);
        }

        public async Task<Basket> GetBasketWithBasketItems(string buyerId)
        {
            return await basketRepository.GetBasketWithItemsAsync(buyerId);
        }

        public async void RemoveItemFromBasket(Basket basket, int productId, int quantity)
        {
            var existingItem = basket.BasketItems.FirstOrDefault(I => I.ProductId == productId);
            
            if (existingItem == null) return;
            
            existingItem.Quantity -= quantity;
            
            // clear basket items on entity
            if(existingItem.Quantity <= 0)
            {
                await basketItemRepository.DeleteAsync(existingItem);
                basket.BasketItems.Remove(existingItem);
                
            }

            await basketRepository.UpdateAsync(basket);
        }
    }
}

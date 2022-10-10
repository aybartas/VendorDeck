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

        private readonly IUnitOfWork _unitOfWork;

        public BasketService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void AddItemToBasket(Basket basket, Product product, int quantity)
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
            _unitOfWork.BasketRepository.Update(basket);
        }

        public async Task<Basket> GetBasketWithBasketItems(string buyerId)
        {
            return await _unitOfWork.BasketRepository.GetBasketWithItemsAsync(buyerId);
        }

        public async Task RemoveItemFromBasket(Basket basket, int productId, int quantity)
        {
            var existingItem = basket.BasketItems.FirstOrDefault(I => I.ProductId == productId);
            
            if (existingItem == null) return;
            
            existingItem.Quantity -= quantity;
            
            // clear basket items on entity
            if(existingItem.Quantity <= 0)
            {
                _unitOfWork.GetGenericRepository<BasketItem>().Remove(existingItem);
                basket.BasketItems.Remove(existingItem);
                
            }

            _unitOfWork.BasketRepository.Update(basket);
            await _unitOfWork.Complete();

        }
    }
}

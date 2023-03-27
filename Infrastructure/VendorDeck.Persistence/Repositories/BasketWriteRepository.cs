using VendorDeck.Application.Repositories;
using VendorDeck.Domain.Entities.Concrete;
using VendorDeck.Persistence.Context;

namespace VendorDeck.Persistence.Repositories
{
    public class BasketWriteRepository : WriteRepository<Basket>, IBasketWriteRepository
    {
        private readonly IWriteRepository<BasketItem> _basketItemWriteRepository;
        public BasketWriteRepository(VendorDeckContext context, IWriteRepository<BasketItem> basketItemWriteRepository) : base(context)
        {
            _basketItemWriteRepository = basketItemWriteRepository;
        }

        public async Task AddItemToBasket(Basket basket, Product product, int quantity)
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
            var result = Table.Update(basket);
            await SaveAsync();
            
        }

        public async  Task RemoveItemFromBasket(Basket basket, int productId, int quantity)
        {
            var existingItem = basket.BasketItems.FirstOrDefault(I => I.ProductId == productId);

            if (existingItem == null) return;

            existingItem.Quantity -= quantity;

            // clear basket items on entity
            if (existingItem.Quantity <= 0)
            {
                await _basketItemWriteRepository.RemoveAsync(existingItem.Id);
                basket.BasketItems.Remove(existingItem);
            }

            Table.Update(basket);
            await SaveAsync();
        }
    }
}

using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Repositories
{
    public interface IBasketWriteRepository : IWriteRepository<Basket>
    {
        Task AddItemToBasket(Basket basket, Product product, int quantity);
        Task RemoveItemFromBasket(Basket basket, int productId, int quantity);

    }
}

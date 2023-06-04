using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Repositories
{
    public interface IOrderWriteRepository : IWriteRepository<Order>
    {
        Task<Order> AddAsync(Order model);

    }
}

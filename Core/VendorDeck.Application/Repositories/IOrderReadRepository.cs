using System.Linq.Expressions;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Repositories
{
    public interface IOrderReadRepository : IReadRepository<Order>
    {
        IQueryable<Order> GetAllOrders(bool useTracking = true, bool includeOrderItems = true);
        Task<Order> GetSingleOrderAsync(Expression<Func<Order, bool>> method, bool useTracking = true, bool includeOrderItems = true);
        Task<Order?> GetOrderByIdAsync(int id, bool includeOrderItems = true, bool useTracking = true);

    }
}

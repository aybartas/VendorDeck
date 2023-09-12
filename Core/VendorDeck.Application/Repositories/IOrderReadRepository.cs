using System.Linq.Expressions;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Repositories
{
    public interface IOrderReadRepository : IReadRepository<Order>
    {
        IQueryable<Order> GetAllOrders(Expression<Func<Order, bool>> method, bool useTracking = true, bool includeOrderItems = true);
        Task<int> GetMaxOrderNumber();

    }
}

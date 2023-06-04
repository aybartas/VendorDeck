using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VendorDeck.Application.Repositories;
using VendorDeck.Domain.Entities.Concrete;
using VendorDeck.Persistence.Context;

namespace VendorDeck.Persistence.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {

        public OrderReadRepository(VendorDeckContext context) :base(context)
        {
        }

        public IQueryable<Order> GetAllOrders(bool useTracking = true, bool includeOrderItems = true)
        {
            var query =  GetAll(useTracking);

            if(includeOrderItems)
                query = query.Include(x => x.OrderItems);
            return query;
        }

        public async Task<Order?> GetOrderByIdAsync(int id, bool includeOrderItems = true, bool useTracking = true)
        {
            var query = Table.AsQueryable();
            if (!useTracking)
                query = query.AsNoTracking();
            if (includeOrderItems)
                query = query.Include(x => x.OrderItems);

            return await query?.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Order> GetSingleOrderAsync(Expression<Func<Order, bool>> method, bool useTracking = true, bool includeOrderItems = true)
        {
            var query = Table.AsQueryable();
            if (!useTracking)
                query = query.AsNoTracking();
            if (includeOrderItems)
                query = query.Include(x => x.OrderItems);

            return await query?.FirstOrDefaultAsync(method);
        }
    }
}

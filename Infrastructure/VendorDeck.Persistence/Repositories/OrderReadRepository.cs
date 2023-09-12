using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;
using VendorDeck.Application.Repositories;
using VendorDeck.Domain.Entities.Concrete;
using VendorDeck.Persistence.Context;

namespace VendorDeck.Persistence.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository
    {
        public OrderReadRepository(VendorDeckContext context) : base(context)
        {
        }

        public IQueryable<Order> GetAllOrders(Expression<Func<Order, bool>> method, bool useTracking = true, bool includeOrderItems = true)
        {
            var query = method is not null ? GetWhere(method, useTracking) : GetAll(useTracking);

            if (includeOrderItems)
                query = query.Include(x => x.OrderItems);
            return query;
        }

        public async Task<int> GetMaxOrderNumber()
        {
            var rowCount = Table.Count();

            if (rowCount == 0)
                return 0;

            var maxOrderNumber = await Table.MaxAsync(order => order.OrderNumber);

            return maxOrderNumber;
        }
  
        public async override Task<Order?> GetByIdAsync(int id)
        {
            var query = Table.AsQueryable().Include(x => x.OrderItems);
         
            return await query?.FirstOrDefaultAsync(x => x.Id == id);
        }

    }
}

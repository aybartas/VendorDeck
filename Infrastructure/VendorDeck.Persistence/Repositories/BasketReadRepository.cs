using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VendorDeck.Application.Repositories;
using VendorDeck.Domain.Entities.Concrete;
using VendorDeck.Persistence.Context;

namespace VendorDeck.Persistence.Repositories
{
    public class BasketReadRepository : ReadRepository<Basket>, IBasketReadRepository
    {
        public BasketReadRepository(VendorDeckContext context) : base(context)
        {
        }

        public IQueryable<Basket> GetAll(bool useTracking = true, bool includeBasketItems = true)
        {
            return GetAll(useTracking).Include(x => x.BasketItems);
        }

         
        public async Task<Basket> GetSingleAsync(Expression<Func<Basket, bool>> method, bool useTracking = true, bool includeBaskettems = true)
        {
            var query = Table.AsQueryable();
            if (!useTracking)
                query = query.AsNoTracking();
            if (includeBaskettems)
                query = query.Include(x => x.BasketItems).ThenInclude(x => x.Product);

            return await query?.FirstOrDefaultAsync(method);
        }

        public Task<Basket?> GetByIdAsync(int id, bool includeBaskettems = true , bool useTracking = true)
        {
            var query = Table.AsQueryable();

            if (includeBaskettems)
                query = query.Include(I => I.BasketItems);

            if (!useTracking)
                query = query.AsNoTracking();

            return query.FirstOrDefaultAsync(I => I.Id == id);
        }
    }
}

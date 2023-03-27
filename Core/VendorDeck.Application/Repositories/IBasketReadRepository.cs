using System.Linq.Expressions;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Repositories
{
    public interface IBasketReadRepository : IReadRepository<Basket>
    {
        IQueryable<Basket> GetAll(bool useTracking = true, bool includeBasketItems = true);
        Task<Basket> GetSingleAsync(Expression<Func<Basket, bool>> method, bool useTracking = true,bool includeBaskettems = true);
        Task<Basket?> GetByIdAsync(int id, bool includeBaskettems = true, bool useTracking = true);

    }
}

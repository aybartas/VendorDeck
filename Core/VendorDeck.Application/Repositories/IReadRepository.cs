using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace VendorDeck.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class 
    {
        DbSet<T> Table { get; }
        IQueryable<T?> GetAll(bool useTracking = true);
        IQueryable<T?> GetWhere(Expression<Func<T,bool>> method, bool useTracking = true);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool useTracking = true);
        Task<T> GetByIdAsync(int id);
    }
}

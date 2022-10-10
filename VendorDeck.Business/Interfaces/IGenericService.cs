using System.Linq.Expressions;

namespace VendorDeck.Business.Interfaces
{
    public interface IGenericService<T>
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        Task Update(T entity);
        Task Remove(T entity);

        Task<T> FindByIdAsync(int id);
    }
}

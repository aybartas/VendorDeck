using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VendorDeck.Application.Repositories;
using VendorDeck.Persistence.Context;

namespace VendorDeck.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly VendorDeckContext _context;

        public ReadRepository(VendorDeckContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public virtual IQueryable<T> GetAll(bool useTracking = true) => useTracking ? Table.AsQueryable() : Table.AsNoTracking();

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public virtual async Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool useTracking = true)
        {
            var query = Table.AsQueryable();
            if (!useTracking)
                query = query.AsNoTracking();

            return await query?.FirstOrDefaultAsync(method);
        }
        
        public virtual IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool useTracking = true)
        {
            var query = Table.Where(method);

            if (!useTracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
    }
}

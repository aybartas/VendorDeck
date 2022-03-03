using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.DataAccess.Context;
using VendorDeck.DataAccess.Interfaces;

namespace VendorDeck.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T :class 
    {
        public async Task AddAsync(T entity)
        {
            using var context = new VendorDeckContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            using var context = new VendorDeckContext();
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            using var context = new VendorDeckContext();
            return await context.FindAsync<T>(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            using var context = new VendorDeckContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            using var context = new VendorDeckContext();
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            using var context = new VendorDeckContext();
            context.Update<T>(entity);
            await context.SaveChangesAsync();
        }
    }
}

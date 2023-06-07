using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Application.Repositories;
using VendorDeck.Persistence.Context;

namespace VendorDeck.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly VendorDeckContext _context;

        public WriteRepository(VendorDeckContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public virtual async Task AddAsync(T model)
        {
           await Table.AddAsync(model);
        }

        public virtual async Task AddRangeAsync(List<T> model)
        {
            await Table.AddRangeAsync(model);
        }

        public virtual void Remove(T model)
        {
            Table.Remove(model);
        }

        public virtual async Task RemoveAsync(int id)
        {
            var entity =  await Table.FindAsync(id);
            Table.Remove(entity);
        }

        public virtual void Update(T model)
        {
            Table.Update(model);
        }

        public virtual void UpdateRange(List<T> models)
        {
            Table.UpdateRange(models);
        }
        public virtual async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}   

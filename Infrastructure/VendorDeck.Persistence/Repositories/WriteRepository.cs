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

        public async Task AddAsync(T model)
        {
           await Table.AddAsync(model);
        }

        public async Task AddRangeAsync(List<T> model)
        {
            await Table.AddRangeAsync(model);
        }

        public void Remove(T model)
        {
            Table.Remove(model);
        }

        public async Task RemoveAsync(int id)
        {
            var entity =  await Table.FindAsync(id);
            Table.Remove(entity);
        }

        public void Update(T model)
        {
            Table.Update(model);

        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}   

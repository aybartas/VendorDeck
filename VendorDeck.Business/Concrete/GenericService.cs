using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Business.Interfaces;
using VendorDeck.DataAccess.Interfaces;

namespace VendorDeck.Business.Concrete
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        public readonly IGenericRepository<T> genericRepository;

        public GenericService(IGenericRepository<T> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task AddAsync(T entity)
        {
            await genericRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await genericRepository.DeleteAsync(entity);
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await genericRepository.FindByIdAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await genericRepository.GetAllAsync();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await genericRepository.GetAsync(filter);
        }

        public async Task UpdateAsync(T entity)
        {
            await genericRepository.UpdateAsync(entity);
        }
    }
}

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

        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> genericRepository;

        public GenericService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            genericRepository = _unitOfWork.GetGenericRepository<T>();
        }

        public async Task AddAsync(T entity)
        {
            await genericRepository.AddAsync(entity);
            await _unitOfWork.Complete();
        }

        public async Task Remove(T entity)
        {
             genericRepository.Remove(entity);
            await _unitOfWork.Complete();
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

        public async Task Update(T entity)
        {
            genericRepository.Update(entity);
            await _unitOfWork.Complete();
        }
    }
}

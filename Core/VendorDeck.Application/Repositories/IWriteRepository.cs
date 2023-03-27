using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task AddAsync(T model);
        Task AddRangeAsync(List<T> model);
        void Remove(T model);
        Task RemoveAsync(int id);
        void Update(T model);
        Task SaveAsync();

    }
}

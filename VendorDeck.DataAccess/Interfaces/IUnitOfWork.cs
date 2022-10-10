using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetGenericRepository<T>() where T : class;
        IBasketRepository BasketRepository { get;}
        IProductRepository ProductRepository { get;}
        Task<int> Complete();
    }
}

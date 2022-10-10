using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.DataAccess.Context;
using VendorDeck.DataAccess.Interfaces;

namespace VendorDeck.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VendorDeckContext _context;

        public IBasketRepository BasketRepository { get;}
        public IProductRepository ProductRepository { get;}


        public UnitOfWork(VendorDeckContext context)
        {
            _context = context;
            BasketRepository = new BasketRepository(_context);
            ProductRepository = new ProductRepository(_context);
        }
        
        public IGenericRepository<T> GetGenericRepository<T>() where T: class
        {
            return new GenericRepository<T>(_context);
        }

        public async Task<int> Complete(){

            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

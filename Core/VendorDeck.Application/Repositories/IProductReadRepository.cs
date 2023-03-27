using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Domain.Entities.Concrete;

namespace VendorDeck.Application.Repositories
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
    }
}

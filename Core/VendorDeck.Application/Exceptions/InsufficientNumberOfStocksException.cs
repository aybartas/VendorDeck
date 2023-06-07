using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.Exceptions
{
    public class InsufficientNumberOfStocksException : Exception
    {
        public InsufficientNumberOfStocksException(int productId, int quantity) : base($"Product {productId} doesn't have sufficient number ({quantity}) of stocks")
        {
            
        }
    }
}

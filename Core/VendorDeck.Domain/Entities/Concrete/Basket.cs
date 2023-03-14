using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Domain.Entities.Interfaces;

namespace VendorDeck.Domain.Entities.Concrete
{
    public class Basket : ITable
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new();

    }
}

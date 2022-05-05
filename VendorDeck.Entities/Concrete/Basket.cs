using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Entities.Interfaces;

namespace VendorDeck.Entities.Concrete
{
    public class Basket : ITable
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItem> BasketItems { get; set; } = new();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendorDeck.Domain.Entities.Interfaces;

namespace VendorDeck.Domain.Entities.Concrete
{
    public class Product : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }

    }
}

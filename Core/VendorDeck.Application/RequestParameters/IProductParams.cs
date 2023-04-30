using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.RequestParameters
{
    public interface IProductParams
    {
        public string SearchText { get; set; }
        public string Brands { get; set; }
        public string Types { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.DataFilters
{
    public class DataFilter
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public List<string> Values { get; set; }
        public string Operation { get; set; }
    }
}

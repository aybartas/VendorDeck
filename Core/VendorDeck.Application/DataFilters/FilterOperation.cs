using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.DataFilters
{
    public class FilterOperation
    {
        public static string Equal=> "eq";
        public static string Contains => "contains";
        public static string GreaterThan => ">";
        public static string GreaterThanOrEqual => ">=";
        public static string LessThanOrEqual => "<=";
        public static string LessThan=> "<";
    }
}

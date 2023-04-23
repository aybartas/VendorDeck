using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.RequestParameters
{
    public interface ISortable<T>
    {
        public bool Ascending { get; set; }
        public string SortBy { get; set; }
        public IQueryable<T> ApplySorting(IQueryable<T> query);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.RequestParameters
{
    public interface ISearchable<T>
    {
        public string SearchText { get; set; }
        public IQueryable<T> ApplySearch(IQueryable<T> query);
    }
}

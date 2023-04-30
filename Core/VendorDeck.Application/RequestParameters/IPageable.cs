using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendorDeck.Application.RequestParameters
{
    public interface IPageable<T>
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public IQueryable<T> ApplyPagination(IQueryable<T> query);
    }
}

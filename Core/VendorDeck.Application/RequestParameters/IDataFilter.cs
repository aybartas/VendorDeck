using VendorDeck.Application.DataFilters;
using System.Linq.Dynamic.Core;

namespace VendorDeck.Application.RequestParameters
{
    public abstract class IDataFilter<T>
    {
        public List<DataFilter> DataFilters { get; set; }
        public virtual IQueryable<T> ApplyFilters(IQueryable<T> query)
        {
            if(DataFilters is null || DataFilters.Count == 0 ) return query;
            foreach (var filter in DataFilters)
            {
                if (filter.Operation == FilterOperation.Equal)
                {
                    query = query.Where($"{filter.Key} = @0", filter.Value);
                }
                else if (filter.Operation == FilterOperation.Contains)
                {
                    query = query.Where($"{filter.Key}.Contains(@0)", filter.Value);

                }
                else if(filter.Operation == FilterOperation.LessThanOrEqual)
                {
                    query = query.Where($"{filter.Key} <= @0",int.Parse(filter.Value));    

                }
                else if (filter.Operation == FilterOperation.LessThan)
                {
                    query = query.Where($"{filter.Key} < @0", int.Parse(filter.Value));

                }
                else if (filter.Operation == FilterOperation.GreaterThan)
                {
                    query = query.Where($"{filter.Key} > @0", int.Parse(filter.Value));
                        
                }
                else if (filter.Operation == FilterOperation.GreaterThanOrEqual)
                {
                    query = query.Where($"{filter.Key} >= @0", int.Parse(filter.Value));
                }
            }

            return query;
        }

    }
}

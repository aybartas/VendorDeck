namespace VendorDeck.Application.Features.Queries.Product.GetAllProduct
{
    public interface IPagination<T>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        IQueryable<T> ApplyPagination(IQueryable<T> query);
    }
}
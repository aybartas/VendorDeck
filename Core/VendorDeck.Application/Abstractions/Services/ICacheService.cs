namespace VendorDeck.Application.Abstractions.Services
{
    public interface ICacheService
    {
         Task<T> GetData<T>(string key);
         Task RemoveData(string key);
         Task SetData<T>(string key, T value, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpiration = null);
    }
}

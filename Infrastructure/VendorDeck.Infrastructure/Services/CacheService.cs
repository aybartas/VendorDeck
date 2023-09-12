using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using VendorDeck.Application.Abstractions.Services;

namespace VendorDeck.Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cacheDb;

        public CacheService(IDistributedCache cacheDb)
        {
            _cacheDb = cacheDb;
        }
        public async Task<T> GetData<T>(string key)
        {
            var value = await _cacheDb.GetStringAsync(key);
            
            if (!string.IsNullOrEmpty(value))
                return JsonSerializer.Deserialize<T>(value);

            return default;
        }

        public async Task RemoveData(string key)
        {
            var exists = _cacheDb.GetString(key);
            if (!string.IsNullOrEmpty(exists))
            {
                await _cacheDb.RemoveAsync(key);
            }
        }

        public async Task SetData<T>(string key, T value, TimeSpan? absoluteExpireTime = null, TimeSpan? slidingExpiration = null)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60),
                SlidingExpiration = slidingExpiration
            };

            var serializedString = JsonSerializer.Serialize(value);

            await _cacheDb.SetStringAsync(key,serializedString, options);

        }
    }
}

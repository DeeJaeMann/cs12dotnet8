using Microsoft.EntityFrameworkCore.ChangeTracking; // For EntityEntry<T>
using Northwind.EntityModels; // For Customer
using Microsoft.Extensions.Caching.Memory; // For IMemoryCache
using Microsoft.EntityFrameworkCore; // For ToArrayAsync

namespace Northwind.WebApi.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheEntryOptions = new()
        {
            SlidingExpiration = TimeSpan.FromMinutes(30)
        };

        // Use an instance data context field because it should not be cached due to the data context having interal caching
        private NorthwindContext _db;

        public CustomerRepository(NorthwindContext db, IMemoryCache memoryCache)
        {
            _db = db;
            _memoryCache = memoryCache;
        }

        public async Task<Customer?> CreateAsync(Customer c)
        {
            c.CustomerId = c.CustomerId.ToUpper();
            EntityEntry<Customer> added = await _db.Customers.AddAsync(c);
            int affected = await _db.SaveChangesAsync();

            if (affected == 1)
            {
                // if saved, store in cache
                _memoryCache.Set(c.CustomerId, c, _cacheEntryOptions);
                return c;
            }
            return null;
        }

        public Task<Customer[]> RetrieveAllAsync()
        {
            return _db.Customers.ToArrayAsync();
        }

        public Task<Customer?> RetrieveAsync(string id)
        {
            id = id.ToUpper();

            // Try from cache first
            if (_memoryCache.TryGetValue(id, out Customer? fromCache))
                return Task.FromResult(fromCache);

            // Try to get from db
            Customer? fromDb = _db.Customers.FirstOrDefault(c => c.CustomerId == id);

            // If not -in db then return null result
            if (fromDb is null) return Task.FromResult(fromDb);

            // If in db, store in cache and return customer
            _memoryCache.Set(fromDb.CustomerId, fromDb, _cacheEntryOptions);
            return Task.FromResult(fromDb)!;
        }

        public async Task<Customer?> UpdateAsync(Customer c)
        {
            c.CustomerId = c.CustomerId.ToUpper();

            _db.Customers.Update(c);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
            {
                _memoryCache.Set(c.CustomerId, c, _cacheEntryOptions);
                return c;
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(string id)
        {
            id = id.ToUpper();

            Customer? c = await _db.Customers.FindAsync(id);
            if (c is null) return null;

            _db.Customers.Remove(c);
            int affected = await _db.SaveChangesAsync();
            if (affected == 1)
            {
                _memoryCache.Remove(c.CustomerId);
                return true;
            }
            return null;
        }
    }
}

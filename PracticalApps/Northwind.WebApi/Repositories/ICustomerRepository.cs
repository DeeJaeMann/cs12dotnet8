﻿using Northwind.EntityModels; // For Customer

namespace Northwind.WebApi.Repositories
{
    // Interface with CRUD methods
    public interface ICustomerRepository
    {

        Task<Customer?> CreateAsync(Customer c);
        Task<Customer[]> RetrieveAllAsync();
        Task<Customer?> RetrieveAsync(string id);
        Task<Customer?> UpdateAsync(Customer c);
        Task<bool?> DeleteAsync(string id);
    }
}

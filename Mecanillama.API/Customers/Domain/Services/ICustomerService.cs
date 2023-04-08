using Mecanillama.API.Customers.Domain.Model;
using Mecanillama.API.Customers.Domain.Services.Communication;
using Mecanillama.API.Security.Domain.Services.Communication;

namespace Mecanillama.API.Customers.Domain.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>> ListAsync();
    Task<Customer> GetByIdAsync(long id);
    Task<CustomerResponse> FindById(int id);
    Task RegisterAsync(RegisterCustomerRequest request);
    Task UpdateAsync(int id, UpdateCustomerRequest request);
    Task DeleteAsync(int id);
}
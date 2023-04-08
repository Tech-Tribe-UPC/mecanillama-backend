using Mecanillama.API.Customers.Domain.Model;

namespace Mecanillama.API.Customers.Domain.Repositories;

public interface ICustomerRepository {
    Task<IEnumerable<Customer>> ListAsync();
    Task AddAsync(Customer customer);
    Task<Customer> FindByIdAsync(int id);
    Customer FindById(int id);
    Task<Customer> FindByEmailAsync(string email);
    public bool ExistsByEmail(string email);
    void Update(Customer customer);
    void Remove(Customer customer);
}
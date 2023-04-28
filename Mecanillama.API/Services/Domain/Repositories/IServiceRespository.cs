using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Services.Domain.Models;

namespace Mecanillama.API.Services.Domain.Repositories;

public interface IServiceRespository
{
    Task<IEnumerable<Service>> ListAsync();
    Task AddAsync(Service service);
    Task<Service> FindByIdAsync(int id);
    Service FindById(int id);
    void Update(Service service);
    void Remove(Service service);
}
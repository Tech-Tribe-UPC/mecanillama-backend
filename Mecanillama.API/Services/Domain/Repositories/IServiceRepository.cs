using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Services.Domain.Models;

namespace Mecanillama.API.Services.Domain.Repositories;

public interface IServiceRepository
{
    Task<IEnumerable<Service>> ListAsync();
    Task<IEnumerable<Service>> ListByMechanicId(int mechanicId);
    Task AddAsync(Service service);
    Task<Service> FindByIdAsync(int id);
    void Update(Service service);
    void Remove(Service service);
}
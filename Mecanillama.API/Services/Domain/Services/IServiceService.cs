using Mecanillama.API.Services.Domain.Models;
using Mecanillama.API.Services.Domain.Services.Communication;

namespace Mecanillama.API.Services.Domain.Services;

public interface IServiceService
{
    Task<IEnumerable<Service>> ListAsync();
    Task<IEnumerable<Service>> ListByMechanicIdAsync(int mechanicId);
    Task<ServiceResponse> GetByIdAsync(int id);
    Task<ServiceResponse> SaveAsync(Service service);
    Task<ServiceResponse> UpdateAsync(int id, Service service);
    Task<ServiceResponse> DeleteAsync(int id);
}
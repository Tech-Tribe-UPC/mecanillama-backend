using Mecanillama.API.Services.Domain.Models;
using Mecanillama.API.Services.Domain.Services.Communication;

namespace Mecanillama.API.Services.Domain.Services;

public interface IServiceService
{
    Task<IEnumerable<Service>> ListAsync();
    Task<Service> GetByIdAsync(int id);
    Task RegisterAsync(SaveServiceResource request);
    Task UpdateAsync(int id, UpdateServiceRequest request);
    Task DeleteAsync(int id);
    Task<ServiceResponse> FindById(int id);
}
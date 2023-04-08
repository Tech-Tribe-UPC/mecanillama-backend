using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Mechanics.Domain.Services.Communication;
using Mecanillama.API.Mechanics.Resources;
using Mecanillama.API.Security.Domain.Services.Communication;

namespace Mecanillama.API.Mechanics.Domain.Services;

public interface IMechanicService
{
    Task<IEnumerable<Mechanic>> ListAsync();
    Task<Mechanic> GetByIdAsync(int id);
    Task RegisterAsync(SaveMechanicResource request);
    Task UpdateAsync(int id, UpdateMechanicRequest request);
    Task DeleteAsync(int id);
    Task<MechanicResponse> FindById(int id);
}
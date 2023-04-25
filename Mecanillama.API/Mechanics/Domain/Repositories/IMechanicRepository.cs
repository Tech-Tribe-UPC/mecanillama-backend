using Mecanillama.API.Mechanics.Domain.Models;

namespace Mecanillama.API.Mechanics.Domain.Repositories;

public interface IMechanicRepository
{
    Task<IEnumerable<Mechanic>> ListAsync();
    Task AddAsync(Mechanic mechanic);
    Task<Mechanic> FindByIdAsync(int id);
    Mechanic FindById(int id);
    Task<Mechanic> FindByEmailAsync(string email);
    public bool ExistsByEmail(string email);
    void Update(Mechanic mechanic);
    void Remove(Mechanic mechanic);
}
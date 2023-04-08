using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Customers.Domain.Model;


namespace Mecanillama.API.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(Customer customer);
    public string GenerateToken(Mechanic mechanic);
    public int? ValidateToken(string token);
}
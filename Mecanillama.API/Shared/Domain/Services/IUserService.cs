using Mecanillama.API.Security.Domain.Services.Communication;

namespace Mecanillama.API.Shared.Domain.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    }
}
using Mecanillama.API.Services.Domain.Models;
using Mecanillama.API.Shared.Domain.Services.Communication;

namespace Mecanillama.API.Services.Domain.Services.Communication;

public class ServiceResponse : BaseResponse<Service>
{
    public ServiceResponse(Service resource) : base(resource) { }

    public ServiceResponse(string message) : base(message) { }
}
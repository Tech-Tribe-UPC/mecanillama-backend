using AutoMapper;
using Mecanillama.API.Services.Domain.Models;
using Mecanillama.API.Services.Domain.Services;
using Mecanillama.API.Services.Resources;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Mecanillama.API.Mechanics.Controllers;

[Produces("application/json")]
[ApiController]
[Route("/api/v1/mechanics/{mechanicId}/services")]
[SwaggerTag("Create, read, update and delete Mechanics")]

public class MechanicServiceController: ControllerBase
{
    private readonly IServiceService _serviceService;
    private readonly IMapper _mapper;

    public MechanicServiceController(IServiceService serviceService, IMapper mapper)
    {
        _serviceService = serviceService;
        _mapper = mapper;
    }
    
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All Services by Mechanic ID",
        Description = "Get All Services already stored by mechanic Id",
        Tags = new[] {"Services"})]
    public async Task<IEnumerable<ServiceResource>> GetAllAsyncByMechanicId([FromRoute] int mechanicId)
    {
        var services = await _serviceService.ListByMechanicIdAsync(mechanicId);
        var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);
        return resources;
    }
    
}
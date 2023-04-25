using AutoMapper;
using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Mechanics.Domain.Services;
using Mecanillama.API.Mechanics.Resources;
using Mecanillama.API.Security.Authorization.Attributes;
using Mecanillama.API.Security.Domain.Services.Communication;
using Mecanillama.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Mecanillama.API.Mechanics.Controllers;

[Produces("application/json")]
[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Create, read, update and delete Mechanics")]
public class MechanicsController : ControllerBase
{
    private readonly IMechanicService _mechanicService;
    private readonly IMapper _mapper;

    public MechanicsController(IMechanicService mechanicService, IMapper mapper)
    {
        _mechanicService = mechanicService;
        _mapper = mapper;
    }

    [SwaggerOperation(
        Summary = "Get all Mechanics",
        Description = "Get Method for all Mechanics",
        OperationId = "GetAllMechanics")]

    [HttpGet]
    public async Task<IEnumerable<MechanicResource>> GetAllAsync()
    {
        var mechanics = await _mechanicService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Mechanic>, IEnumerable<MechanicResource>>(mechanics);

        return resources;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
            Summary = "Get a mechanic by Id",
            Description = "Get a mechanic Data already stored",
            Tags = new[] { "Mechanics" })]

    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var mechanic = await _mechanicService.GetByIdAsync(id);
        var resources = _mapper.Map<Mechanic, MechanicResource>(mechanic);
        return Ok(resources);
    }

    [AllowAnonymous]
    [HttpPost("auth/sign-up")]
    [SwaggerOperation(
    Summary = "Register a new mechanic",
    Description = "register a new mechanic in the database",
    Tags = new[] { "Mechanics" })]
    public async Task<IActionResult> Register(SaveMechanicResource request)
    {
        await _mechanicService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
    Summary = "Edit a mechanic",
    Description = "Updates the data of a stored mechanic given its id",
    Tags = new[] { "Mechanics" })]
    public async Task<IActionResult> Update(int id, UpdateMechanicRequest request)
    {
        await _mechanicService.UpdateAsync(id, request);
        return Ok(new { message = "Mechanic updated successfully" });
    }
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a mechanic",
        Description = "Delete the data of a stored mechanic given its id",
        Tags = new[] { "Mechanics" })]
    public async Task<IActionResult> Delete(int id)
    {
        await _mechanicService.DeleteAsync(id);
        return Ok(new { message = "Mechanic deleted successfully" });
    }
}

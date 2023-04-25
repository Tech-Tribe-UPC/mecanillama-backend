using AutoMapper;
using Mecanillama.API.Customers.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Mecanillama.API.Customers.Domain.Services;
using Mecanillama.API.Customers.Resources;
using Mecanillama.API.Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using Mecanillama.API.Security.Authorization.Attributes;
using Mecanillama.API.Security.Domain.Services.Communication;

namespace Mecanillama.API.Customers.Controllers;

[Produces("application/json")]
[ApiController]
[Route("/api/v1/[controller]")]
[SwaggerTag("Create, read, update and delete Customers")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomersController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [SwaggerOperation(
        Summary = "Get all Customers",
        Description = "Get All The Customers From The Database.",
        Tags = new[] { "Customers" })]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);

        return Ok(resources);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get Customer By Id",
        Description = "Get A Customer From The Database By Id.",
        Tags = new[] { "Customers" })]
    public async Task<IActionResult> GetById(int id)
    {
        var customer = await _customerService.GetByIdAsync(id);
        var resources = _mapper.Map<Customer, CustomerResource>(customer);
        return Ok(resources);
    }

    [AllowAnonymous]
    [HttpPost("auth/sign-up")]
    [SwaggerOperation(
        Summary = "Register A Customer",
        Description = "Add A Customer To The Database.",
        Tags = new[] { "Customers" })]
    public async Task<IActionResult> Register(RegisterCustomerRequest request)
    {
        await _customerService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
    Summary = "Edit A Customer",
    Description = "Edit The Information Of A Customer Identified By Id.",
    Tags = new[] { "Customers" })]
    public async Task<IActionResult> Update(int id, UpdateCustomerRequest request)
    {
        await _customerService.UpdateAsync(id, request);
        return Ok(new { message = "Customer updated successfully" });
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
    Summary = "Delete A Customer",
    Description = "Delete The Information Of A Customer Identified By Id.",
    Tags = new[] { "Customers" })]
    public async Task<IActionResult> Delete(int id)
    {
        await _customerService.DeleteAsync(id);
        return Ok(new { message = "Customer deleted successfully" });
    }
}
using AutoMapper;
using Mecanillama.API.Services.Domain.Models;
using Mecanillama.API.Services.Domain.Services;
using Mecanillama.API.Services.Resources;
using Mecanillama.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Mecanillama.API.Services.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;

        public ServicesController(IServiceService serviceService, IMapper mapper)
        {
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [SwaggerOperation(
            Summary = "Get All Services",
            Description = "Get All Services already stored",
            Tags = new[] {"Services"})]
        [HttpGet]
        public async Task<IEnumerable<ServiceResource>> GetAllAsync()
        {
            var services = await _serviceService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Service>, IEnumerable<ServiceResource>>(services);
            return resources;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get All Services",
            Description = "Get All Services already stored",
            Tags = new[] {"Services"})]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _serviceService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Resource);
        }
        
        [HttpPost]
        [SwaggerOperation(
            Summary = "Register a new service from an agency",
            Description = "Register a new service",
            Tags = new[] {"Services"})]
        public async Task<IActionResult> PostAsync([FromBody] SaveServiceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var service = _mapper.Map<SaveServiceResource, Service>(resource);
            var result = await _serviceService.SaveAsync(service);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);

            return Ok(serviceResource);
        }
        
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update a service from an agency",
            Description = "Update a service",
            Tags = new[] {"Services"})]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveServiceResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            
            var service = _mapper.Map<SaveServiceResource, Service>(resource);

            var result = await _serviceService.UpdateAsync(id, service);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);

            return Ok(serviceResource);
        }
        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Unregister a service from an agency",
            Description = "Delete a service",
            Tags = new[] {"Services"})]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _serviceService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            
            var serviceResource = _mapper.Map<Service, ServiceResource>(result.Resource);
            
            return Ok(serviceResource);
        }
    }
}
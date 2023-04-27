using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Mecanillama.API.Security.Authorization.Attributes;
using Mecanillama.API.Security.Domain.Services.Communication;
using Mecanillama.API.Shared.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace Mecanillama.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Records a user login",
            Description = "Returns the data of an application user along with a hash password that identifies it.",
            Tags = new[] {"Users"})]
        [HttpPost("auth/sign-in")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var response = await _userService.Authenticate(request);
            if (response.Email == null)
                return Ok(response);
            if (response.CarMake == null)
            {
                var resourceMechanic = _mapper.Map<AuthenticateResponse, AuthenticateMechanicResponse>(response);
                return Ok(resourceMechanic);
            }
            var resourcesCustomer = _mapper.Map<AuthenticateResponse, AuthenticateCustomerResponse>(response);
            return Ok(resourcesCustomer);
        }

    }
}
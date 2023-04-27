using System;
using System.Threading.Tasks;
using AutoMapper;
using Mecanillama.API.Customers.Domain.Repositories;
using Mecanillama.API.Mechanics.Domain.Repositories;
using Mecanillama.API.Security.Authorization.Handlers.Interfaces;
using Mecanillama.API.Security.Domain.Services.Communication;
using Mecanillama.API.Security.Exceptions;
using Mecanillama.API.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Mecanillama.API.Shared.Domain.Services;
    public class UserService : IUserService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMechanicRepository _mechanicRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        public UserService(ICustomerRepository customerRepository, IMechanicRepository mechanicRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mechanicRepository = mechanicRepository;
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var customer = await _customerRepository.FindByEmailAsync(request.Email);
            var mechanic = await _mechanicRepository.FindByEmailAsync(request.Email);

            //Validate
            if (customer == null || !BCryptNet.Verify(request.Password, customer.PasswordHash))
            {
                if (mechanic == null || !BCryptNet.Verify(request.Password, mechanic.PasswordHash))
                    throw new AppException("Email or password is incorrect.");
                
                //Authentication successful
                var responseMechanic = _mapper.Map<AuthenticateResponse>(mechanic);
                responseMechanic.Token = _jwtHandler.GenerateToken(mechanic);
                return responseMechanic;
            }

            //Authentication successful
            var responseCustomer = _mapper.Map<AuthenticateResponse>(customer);
            responseCustomer.Token = _jwtHandler.GenerateToken(customer);
            return responseCustomer;
        }
    }

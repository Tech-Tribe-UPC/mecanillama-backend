using AutoMapper;
using Mecanillama.API.Customers.Domain.Repositories;
using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Mechanics.Domain.Repositories;
using Mecanillama.API.Mechanics.Domain.Services;
using Mecanillama.API.Mechanics.Domain.Services.Communication;
using Mecanillama.API.Mechanics.Resources;
using Mecanillama.API.Security.Authorization.Handlers.Interfaces;
using Mecanillama.API.Security.Domain.Services.Communication;
using Mecanillama.API.Security.Exceptions;
using Mecanillama.API.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Mecanillama.API.Mechanics.Services;

public class MechanicService : IMechanicService
{
    private readonly IMechanicRepository _mechanicRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtHandler _jwtHandler;
    private readonly IMapper _mapper;

    public MechanicService(IMechanicRepository mechanicRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
    {
        _mechanicRepository = mechanicRepository;
        _unitOfWork = unitOfWork;
        _jwtHandler = jwtHandler;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Mechanic>> ListAsync()
    {
        return await _mechanicRepository.ListAsync();
    }

    public async Task<Mechanic> GetByIdAsync(int id)
    {
        var mechanic = await _mechanicRepository.FindByIdAsync(id);
        if (mechanic == null) throw new KeyNotFoundException("Mechanic not found.");
        return mechanic;
    }

    public async Task RegisterAsync(SaveMechanicResource request)
    {
        //Validate
        if (_mechanicRepository.ExistsByEmail(request.Email))
            throw new AppException($"Email {request.Email} is already taken.");

        //Map request to customer
        var customer = _mapper.Map<Mechanic>(request);

        //Hash Password
        customer.PasswordHash = BCryptNet.HashPassword(request.Password);

        //Save customer
        try
        {
            await _mechanicRepository.AddAsync(customer);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the mechanic: {e.Message}");
        }
    }


    public async Task UpdateAsync(int id, UpdateMechanicRequest request)
    {
        var mechanic = GetById(id);

        //Validate
        if (_mechanicRepository.ExistsByEmail(request.Email))
            throw new AppException($"Email {request.Email} is already taken.");

        //Hash Password if entered
        if (!string.IsNullOrEmpty(request.Password))
            mechanic.PasswordHash = BCryptNet.HashPassword(request.Password);

        //Map request to Customer
        _mapper.Map(request, mechanic);

        try
        {
            _mechanicRepository.Update(mechanic);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the mechanic: {e.Message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var mechanic = GetById(id);

        try
        {
            _mechanicRepository.Remove(mechanic);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while deleting the mechanic: {e.Message}");
        }
    }
    public async Task<MechanicResponse> FindById(int id)
    {
        var existingMechanic = await _mechanicRepository.FindByIdAsync(id);

        if (existingMechanic == null)
            return new MechanicResponse("Mechanic not found.");

        return new MechanicResponse(existingMechanic);
    }

    private Mechanic GetById(int id)
    {
        var mechanic = _mechanicRepository.FindById(id);
        if (mechanic == null) throw new KeyNotFoundException("Mechanic not found.");
        return mechanic;
    }
}
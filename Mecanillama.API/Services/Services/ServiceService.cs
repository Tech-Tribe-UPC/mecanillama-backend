
using Mecanillama.API.Mechanics.Domain.Repositories;
using Mecanillama.API.Services.Domain.Models;
using Mecanillama.API.Services.Domain.Repositories;
using Mecanillama.API.Services.Domain.Services;
using Mecanillama.API.Services.Domain.Services.Communication;
using Mecanillama.API.Shared.Domain.Repositories;

namespace Mecanillama.API.Services.Resources;
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMechanicRepository _mechanicRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceService(IServiceRepository serviceRepository, IUnitOfWork unitOfWork, IMechanicRepository mechanicRepository)
        {
            _serviceRepository = serviceRepository;
            _unitOfWork = unitOfWork;
            _mechanicRepository = mechanicRepository;
        }

        public async Task<IEnumerable<Service>> ListAsync()
        {
            return await _serviceRepository.ListAsync();
        }

        public async Task<ServiceResponse> GetByIdAsync(int id)
        {
            var existingService = _serviceRepository.FindByIdAsync(id);
            if (existingService.Result == null)
                return new ServiceResponse("The service does not exist.");
            
            return new ServiceResponse(existingService.Result);
        }

        public async Task<IEnumerable<Service>> ListByMechanicIdAsync(int mechanicId)
        {
            return await _serviceRepository.ListByMechanicId(mechanicId);
        }
        
        public async Task<ServiceResponse> SaveAsync(Service service)
        {
            try
            {
                await _serviceRepository.AddAsync(service);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse(service);
            }
            catch (Exception e)
            {
                return new ServiceResponse($"An error occurred while saving the Service: {e.Message}");
            }
        }

        public async Task<ServiceResponse> UpdateAsync(int id, Service service)
        {
            var existingService = await _serviceRepository.FindByIdAsync(id);
            if (existingService == null)
                return new ServiceResponse("Service not found");
            existingService.Name = service.Name;
            existingService.Price = service.Price;
            existingService.Photos = service.Photos;
            existingService.Description = service.Description;
            try
            {
                _serviceRepository.Update(existingService);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse(existingService);
            }
            catch (Exception e)
            {
                return new ServiceResponse($"An error occurred while updating the Service: {e.Message}");
            }
        }

        public async Task<ServiceResponse> DeleteAsync(int id)
        {
            var existingService = await _serviceRepository.FindByIdAsync(id);
            if (existingService == null)
                return new ServiceResponse("Service not found");
            try
            {
                _serviceRepository.Remove(existingService);
                await _unitOfWork.CompleteAsync();
                return new ServiceResponse(existingService);
            }
            catch (Exception e)
            {
                return new ServiceResponse($"An error occurred while deleting the Service: {e.Message}");
            }
        }
    }
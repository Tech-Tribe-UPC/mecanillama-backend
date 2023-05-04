using AutoMapper;
using Mecanillama.API.Appointments.Domain.Models;
using Mecanillama.API.Appointments.Resources;
using Mecanillama.API.Customers.Domain.Model;
using Mecanillama.API.Customers.Resources;
using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Mechanics.Resources;
using Mecanillama.API.Reviews.Domain.Models;
using Mecanillama.API.Reviews.Resources;
using Mecanillama.API.Security.Domain.Services.Communication;
using Mecanillama.API.Services.Domain.Models;
using Mecanillama.API.Services.Resources;

namespace Mecanillama.API.Customers.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Customer, CustomerResource>();
        CreateMap<Customer, AuthenticateResponse>();
        CreateMap<Mechanic, MechanicResource>();
        CreateMap<Appointment, AppointmentResource>();
        CreateMap<Mechanic, AuthenticateResponse>();
        CreateMap<Review, ReviewResource>();
        CreateMap<Service, ServiceResource>();
        CreateMap<AuthenticateResponse, AuthenticateMechanicResponse>();
        CreateMap<AuthenticateResponse, AuthenticateCustomerResponse>();
    }

}
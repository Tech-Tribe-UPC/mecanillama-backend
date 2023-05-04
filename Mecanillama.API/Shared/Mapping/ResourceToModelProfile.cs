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

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterCustomerRequest, Customer>();
        CreateMap<SaveCustomerResource, Customer>();
        CreateMap<SaveMechanicResource, Mechanic>();
        CreateMap<SaveAppointmentResource, Appointment>();
        CreateMap<SaveReviewResource, Review>();
        CreateMap<SaveServiceResource, Service>();
        CreateMap<UpdateCustomerRequest, Customer>()
        .ForAllMembers(options => options.Condition(
            (source, Target, property) =>
            {
                if (property == null) return false;
                if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                return true;
            }));
    }
}
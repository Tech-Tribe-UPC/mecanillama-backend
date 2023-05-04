using System.Text.Json.Serialization;
using Mecanillama.API.Appointments.Domain.Models;
using Mecanillama.API.Reviews.Domain.Models;
using Mecanillama.API.Services.Domain.Models;

namespace Mecanillama.API.Mechanics.Domain.Models;

public class Mechanic
{
    //Properties
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public long Phone { get; set; }
    public string Email { get; set; }
    [JsonIgnore]
    public string PasswordHash { get; set; }
    //Relationships
    public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
    public IList<Review> Reviews {get; set;} = new List<Review>();
    public IList<Service> Services {get; set;}
}
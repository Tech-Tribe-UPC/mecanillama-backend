using Mecanillama.API.Mechanics.Domain.Models;

namespace Mecanillama.API.Services.Domain.Models;

public class Service
{
    //Properties
    public int Id { get; set; }
    public string Name {get; set;}
    public string Description { get; set; }
    public int Price { get; set; }
    public string Photos {get; set;}
    public int MechanicId {get; set;}
    public Mechanic Mechanic {get; set;}

}
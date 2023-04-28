namespace Mecanillama.API.Services.Domain.Models;

public class Service
{
    //Properties
    public int Id { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Id_Customer{ get; set; }
    public int Id_Mechanic{ get; set; }

   
}
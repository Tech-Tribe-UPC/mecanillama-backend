namespace Mecanillama.API.Security.Domain.Services.Communication;

public class AuthenticateCustomerResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email {get; set;}
    public string Address { get; set; }
    public string CarMake { get; set; }
    public string Token { get; set; }
}
namespace Mecanillama.API.Security.Domain.Services.Communication;
public class AuthenticateMechanicResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public long Phone { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}
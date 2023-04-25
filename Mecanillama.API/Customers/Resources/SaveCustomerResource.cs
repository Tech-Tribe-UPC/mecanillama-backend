using System.ComponentModel.DataAnnotations;

namespace Mecanillama.API.Customers.Resources;

public class SaveCustomerResource
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    [Required]
    [MaxLength(250)]
    public string Email { get; set; }

    [Required]
    [MaxLength(25)]
    public string Password { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Address { get; set; }
    
    [Required]
    [MaxLength(40)]
    public string CarMake { get; set; }

}
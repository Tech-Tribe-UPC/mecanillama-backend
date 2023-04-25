using System.ComponentModel.DataAnnotations;

namespace Mecanillama.API.Mechanics.Resources;

public class SaveMechanicResource
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    [MaxLength(200)]
    public string Address { get; set; }

    [Required]
    [MaxLength(300)]
    public string Description { get; set; }

    [Required]
    public long Phone { get; set; }

}
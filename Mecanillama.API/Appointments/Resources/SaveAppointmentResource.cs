using System.ComponentModel.DataAnnotations;

namespace Mecanillama.API.Appointments.Resources;

public class SaveAppointmentResource
{
    [Required]
    public string Date { get; set; }
        
    [Required]
    public string Time { get; set; }

    [Required]
    public int CustomerId { get; set; }

    [Required]
    public int MechanicId { get; set; }
    
}
namespace Mecanillama.API.Appointments.Resources;

public class AppointmentResource
{
    public int Id { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public int CustomerId { get; set; }
    public int MechanicId { get; set; }
}
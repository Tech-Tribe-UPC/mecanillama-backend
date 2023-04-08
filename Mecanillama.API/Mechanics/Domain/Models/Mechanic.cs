﻿using Mecanillama.API.Appointments.Domain.Models;
using Mecanillama.API.Reviews.Domain.Models;

namespace Mecanillama.API.Mechanics.Domain.Models;

public class Mechanic
{
    //Properties
    public long Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public long Phone { get; set; }
    public long UserId { get; set; }

    //Relationships
    public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
    
    public IList<Review> Reviews {get; set;} = new List<Review>();
}
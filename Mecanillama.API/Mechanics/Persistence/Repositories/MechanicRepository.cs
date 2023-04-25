﻿using Mecanillama.API.Appointments.Domain.Repositories;
using Mecanillama.API.Mechanics.Domain.Models;
using Mecanillama.API.Mechanics.Domain.Repositories;
using Mecanillama.API.Shared.Domain.Repositories;
using Mecanillama.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Mecanillama.API.Mechanics.Persistence.Repositories;

public class MechanicRepository : BaseRepository, IMechanicRepository
{
    public MechanicRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Mechanic>> ListAsync()
    {
        return await _context.Mechanics.ToListAsync();
    }

    public async Task AddAsync(Mechanic mechanic)
    {
        await _context.Mechanics.AddAsync(mechanic);
    }

    public async Task<Mechanic> FindByIdAsync(int id)
    {
        return await _context.Mechanics.FindAsync(id);
    }

    public Mechanic FindById(int id)
    {
        return _context.Mechanics.Find(id);
    }

    public async Task<Mechanic> FindByEmailAsync(string email)
    {
        return await _context.Mechanics.SingleOrDefaultAsync(C => C.Email == email);
    }

    public bool ExistsByEmail(string email)
    {
        return _context.Mechanics.Any(c => c.Email == email);
    }

    public void Update(Mechanic mechanic)
    {
        _context.Mechanics.Update(mechanic);
    }

    public void Remove(Mechanic mechanic)
    {
        _context.Mechanics.Remove(mechanic);
    }
}
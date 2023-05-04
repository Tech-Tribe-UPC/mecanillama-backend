using Mecanillama.API.Services.Domain.Models;
using Mecanillama.API.Services.Domain.Repositories;
using Mecanillama.API.Shared.Domain.Repositories;
using Mecanillama.API.Shared.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace Mecanillama.API.Services.Resources;
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Service>> ListAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<IEnumerable<Service>> ListByMechanicId(int mechanicId)
        {
            return await _context.Services.Where(b => b.MechanicId == mechanicId).Include(b => b.Mechanic).ToListAsync();
        }

        public async Task<IEnumerable<Service>> ListById(int id)
        {
            return await _context.Services.Where(p => p.Id == id).ToListAsync();
        }

        public async Task<Service> FindByIdAsync(int id)
        {
            return await _context.Services.FindAsync(id);
        }
        
        public async Task AddAsync(Service service)
        {
            await _context.Services.AddAsync(service);
        }

        public void Update(Service service)
        {
            _context.Services.Update(service);
        }

        public void Remove(Service service)
        {
            _context.Services.Remove(service);
        }
    }
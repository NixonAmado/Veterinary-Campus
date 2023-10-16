using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

    public class AppointmentRepository : GenericRepository<Appointment>, IAppointment
    {
        private readonly DbAppContext _context;

        public AppointmentRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                                .Include(p => p.Pet)
                                .ThenInclude(p => p.Species)
                                .ThenInclude(p => p.Breeds)
                                .Include(p => p.Veterinarian)
                                .ThenInclude(p => p.Especiality)
                                .ToListAsync();
        }
        
    }

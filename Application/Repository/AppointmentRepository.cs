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
        public override async Task<(int totalRegistros, IEnumerable<Appointment> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.Appointments as IQueryable<Appointment>;

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Pet.Name.ToUpper() == search.ToUpper());
            }

            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Pet)
                .ThenInclude(p => p.Species)
                .ThenInclude(p => p.Breeds)
                .Include(p => p.Veterinarian)
                .ThenInclude(p => p.Especiality)

                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
        }
    }

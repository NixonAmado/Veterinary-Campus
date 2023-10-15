using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.Repository;

    public class AppointmentRepository : GenericRepository<Appointment>, IAppointment
    {
        private readonly DbAppContext _context;

        public AppointmentRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    }

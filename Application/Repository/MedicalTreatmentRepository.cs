using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.Repository;

    public class MedicalTreatmentRepository : GenericRepository<MedicalTreatment>, IMedicalTreatment
    {
        private readonly DbAppContext _context;

        public MedicalTreatmentRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    }

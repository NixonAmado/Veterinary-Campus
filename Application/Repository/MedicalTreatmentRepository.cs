using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

    public class MedicalTreatmentRepository : GenericRepository<MedicalTreatment>, IMedicalTreatment
    {
        private readonly DbAppContext _context;

        public MedicalTreatmentRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
        public override async Task<MedicalTreatment> GetByIdAsync(int id)
        {
            return await _context.MedicalTreatments
                                .Include(p => p.Product)
                                .FirstOrDefaultAsync();
        }
        public override async Task<IEnumerable<MedicalTreatment>> GetAllAsync()
        {
            return await _context.MedicalTreatments
                                .Include(p => p.Product)
                                .ToListAsync();
        }
        public override async Task<(int totalRegistros, IEnumerable<MedicalTreatment> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
        {
            var query = _context.MedicalTreatments as IQueryable<MedicalTreatment>;

            if(!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Id.ToString() == search);
            }

            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(p => p.Product)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
        }
    }

using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.Repository;

    public class LaboratoryRepository : GenericRepository<Laboratory>, ILaboratory
    {
        private readonly DbAppContext _context;

        public LaboratoryRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    }

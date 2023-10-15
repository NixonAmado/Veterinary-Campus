using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.Repository;
    public class SpeciesRepository : GenericRepository<Species>, ISpecies
    {
        private readonly DbAppContext _context;

        public SpeciesRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    }

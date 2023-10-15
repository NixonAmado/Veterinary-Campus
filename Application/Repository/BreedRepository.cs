using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.Repository;

    public class BreedRepository : GenericRepository<Breed>, IBreed
    {
        private readonly DbAppContext _context;

        public BreedRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    }

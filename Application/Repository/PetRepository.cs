using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.Repository;

    public class PetRepository : GenericRepository<Pet>, IPet
    {
        private readonly DbAppContext _context;

        public PetRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    }

using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.Repository;

    public class MovementTypeRepository : GenericRepository<MovementType>, IMovementType
    {
        private readonly DbAppContext _context;

        public MovementTypeRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    }

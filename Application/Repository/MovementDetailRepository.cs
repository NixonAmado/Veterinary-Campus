using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.Repository;

    public class MovementDetailRepository : GenericRepository<MovementDetail>, IMovementDetail
    {
        private readonly DbAppContext _context;

        public MovementDetailRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    }

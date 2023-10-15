using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;

namespace Application.Repository;

    public class ProductMovementRepository : GenericRepository<ProductMovement>, IProductMovement
    {
        private readonly DbAppContext _context;

        public ProductMovementRepository(DbAppContext context): base(context)
        {
            _context = context;
        }

    }

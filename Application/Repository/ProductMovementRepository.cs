using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Application.Repository;

    public class ProductMovementRepository : GenericRepository<ProductMovement>, IProductMovement
    {
        private readonly DbAppContext _context;

        public ProductMovementRepository(DbAppContext context): base(context)
        {
            _context = context;
        }
        //Listar todos los movimientos de medicamentos y el valor total de cada movimiento. --Ok
        public async Task<IEnumerable<ProductMovement>> GetProductMovement()
        {
            return await _context.ProductMovements
                                .Include(p => p.Product)
                                .Select(p => new ProductMovement
                                {
                                    Product = p.Product,
                                    Quantity = p.Quantity,
                                    Date = p.Date,
                                    TotalPrice = p.Product.Price * p.Quantity
                                })
                                .ToListAsync();
        }
    }
